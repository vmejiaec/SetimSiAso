using System;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Xml;
using DotNetNuke.Common.Utilities;

namespace forDNN.Modules.DataExporter.Business
{
	public class CommonController
	{
		#region Basic
		public static ArrayList GetListOfTables()
		{
			return CBO.FillCollection(DataProvider.Instance().GetListOfTables(), typeof(Business.ObjectInfo));
		}

		public static ArrayList GetListOfViews()
		{
			ArrayList lstViews = CBO.FillCollection(DataProvider.Instance().GetListOfViews(), typeof(Business.ObjectInfo));
			string Query = "";
			foreach (ObjectInfo objInfo in lstViews)
			{
				Query = string.Format(
@"{0} {2} 
SELECT	'{1}' ObjectName,
			COUNT(*) RowsCount
FROM [{1}] 
",
				Query,
				objInfo.ObjectName,
				Query == "" ? "" : "UNION");
			}
			Query = string.Format("{0} ORDER BY ObjectName;", Query);

			lstViews = CBO.FillCollection(DataProvider.Instance().ExecDynamicQuery(Query), typeof(Business.ObjectInfo));
			return lstViews;
		}

		public static DataTable ExecDynamicQuery(string Query)
		{
			DataTable dtResult = DotNetNuke.Common.Globals.ConvertDataReaderToDataTable(DataProvider.Instance().ExecDynamicQuery(Query));
			return dtResult;
		}
		#endregion

		#region Primary Export

		public static DataTable GetDataForExport(SourceOfData objType, string ObjectName)
		{
			string Query = "";
			switch (objType)
			{
				case SourceOfData.Table:
				case SourceOfData.View:
					Query = string.Format("SELECT * FROM [{0}];", ObjectName);
					break;
				case SourceOfData.Query:
					Query = ObjectName;
					break;
			}
			DataTable dtResult = Business.CommonController.ExecDynamicQuery(Query);
			return dtResult;
		}

		public static void ExportData(SourceOfData objSourceType, string ObjectName, ExportType objExportType)
		{
			DataTable dtResult = GetDataForExport(objSourceType, ObjectName);
			string ResultName = string.Format("{0}_{1}", ObjectName, DateTime.Now.Ticks);
			if (objSourceType == SourceOfData.Query)
			{
				ResultName = string.Format("CustomQuery_{0}", DateTime.Now.Ticks);
			}
			switch (objExportType)
			{
				case ExportType.Excel:
					ExportToExcel(dtResult, ResultName);
					break;
				case ExportType.XML:
					ExportToXML(dtResult, ResultName);
					break;
				case ExportType.CSV:
					ExportToCSV(dtResult, ResultName);
					break;
			}
		}

		#endregion

		#region Export

		private static void ExportToExcel(DataTable dtSource, string FileName)
		{
			XmlDocument objDoc = new XmlDocument();

			XmlProcessingInstruction objInstructionXml =
				objDoc.CreateProcessingInstruction("xml", " version=\"1.0\" encoding=\"utf-8\"");
			objDoc.AppendChild(objInstructionXml);

			XmlProcessingInstruction objInstruction =
				objDoc.CreateProcessingInstruction("mso-application", "progid=\"Excel.Sheet\"");
			objDoc.AppendChild(objInstruction);

			XmlElement objRoot = objDoc.CreateElement("Workbook", "urn:schemas-microsoft-com:office:spreadsheet");

			XmlAttribute objHtml = objDoc.CreateAttribute("xmlns:html");
			objHtml.Value = "http://www.w3.org/TR/REC-html40";
			objRoot.Attributes.Append(objHtml);

			XmlAttribute objO = objDoc.CreateAttribute("xmlns:o");
			objO.Value = "urn:schemas-microsoft-com:office:office";
			objRoot.Attributes.Append(objO);

			XmlAttribute objX = objDoc.CreateAttribute("xmlns:x");
			objX.Value = "urn:schemas-microsoft-com:office:excel";
			objRoot.Attributes.Append(objX);

			XmlAttribute objMs = objDoc.CreateAttribute("xmlns:ms");
			objMs.Value = "urn:schemas-microsoft-com:xslt";
			objRoot.Attributes.Append(objMs);

			XmlAttribute objSs = objDoc.CreateAttribute("xmlns:ss");
			objSs.Value = "urn:schemas-microsoft-com:office:spreadsheet";
			objRoot.Attributes.Append(objSs);

			XmlElement objWorksheet =
				objDoc.CreateElement("Worksheet", "urn:schemas-microsoft-com:office:spreadsheet");
			XmlAttribute objWorksheetName =
				objDoc.CreateAttribute(null, "Name", "urn:schemas-microsoft-com:office:spreadsheet");
			if (FileName.Length > 30)
			{
				objWorksheetName.Value = FileName.Substring(0, 30);
			}
			else
			{
				objWorksheetName.Value = FileName;
			}
			objWorksheet.Attributes.Append(objWorksheetName);

			XmlElement objTable = objDoc.CreateElement("Table", "urn:schemas-microsoft-com:office:spreadsheet");

			//Header
			XmlElement objTitleRow = objDoc.CreateElement("Row", "urn:schemas-microsoft-com:office:spreadsheet");
			foreach (DataColumn dc in dtSource.Columns)
			{
				XmlElement objTitleCell = objDoc.CreateElement("Cell", "urn:schemas-microsoft-com:office:spreadsheet");

				XmlElement objTitleData =
					objDoc.CreateElement("Data", "urn:schemas-microsoft-com:office:spreadsheet");
				XmlAttribute objTitleDataType =
					objDoc.CreateAttribute(null, "Type", "urn:schemas-microsoft-com:office:spreadsheet");
				objTitleDataType.Value = "String";
				objTitleData.InnerXml = dc.ColumnName;
				objTitleData.Attributes.Append(objTitleDataType);

				objTitleCell.AppendChild(objTitleData);
				objTitleRow.AppendChild(objTitleCell);
			}
			objTable.AppendChild(objTitleRow);

			//Data
			foreach (DataRow dr in dtSource.Rows)
			{
				try
				{
					XmlElement objRow = objDoc.CreateElement("Row", "urn:schemas-microsoft-com:office:spreadsheet");
					foreach (DataColumn dc in dtSource.Columns)
					{
						XmlElement objCell =
							objDoc.CreateElement("Cell", "urn:schemas-microsoft-com:office:spreadsheet");
						XmlElement objData =
							objDoc.CreateElement("Data", "urn:schemas-microsoft-com:office:spreadsheet");
						XmlAttribute objDataType =
							objDoc.CreateAttribute(null, "Type", "urn:schemas-microsoft-com:office:spreadsheet");
						objDataType.Value = "String";
						objData.InnerXml = string.Format("{0}", dr[dc.ColumnName]);
						objData.Attributes.Append(objDataType);

						objCell.AppendChild(objData);
						objRow.AppendChild(objCell);
					}
					objTable.AppendChild(objRow);
				}
				catch
				{ }
			}

			objWorksheet.AppendChild(objTable);
			objRoot.AppendChild(objWorksheet);
			objDoc.AppendChild(objRoot);

			ResponseWrite(objDoc.InnerXml, string.Format("{0}.xls", FileName), "application/excel");
		}

		private static void ExportToXML(DataTable dtSource, string FileName)
		{
			XmlDocument objDoc = new XmlDocument();
			XmlElement objRoot = objDoc.CreateElement("root");

			for (int i = 0; i < dtSource.Rows.Count; i++)
			{
				try
				{
					XmlElement objItem = objDoc.CreateElement(FileName);
					DataRow dr = dtSource.Rows[i];
					for (int j = 0; j < dtSource.Columns.Count; j++)
					{
						XmlAttribute objAttr = objDoc.CreateAttribute(dtSource.Columns[j].ColumnName);
						objAttr.Value = string.Format("{0}", dr[j]);
						objItem.Attributes.Append(objAttr);
					}
					objRoot.AppendChild(objItem);
				}
				catch
				{ }
			}
			objDoc.AppendChild(objRoot);

			ResponseWrite(objDoc.InnerXml, string.Format("{0}.xml", FileName), "text/xml");
		}

		private static string FixCSVString(string Source)
		{
			return Source.Replace("\"", "\"\"");
		}

		private static void ExportToCSV(DataTable dtSource, string FileName)
		{
			string Result = ToCSV(dtSource, true, ",");

			ResponseWrite(Result, string.Format("{0}.csv", FileName), "text/csv");
		}

		public static string ToCSV(DataTable dt, bool includeHeaderAsFirstRow, string separator)
		{
			StringBuilder csvRows = new StringBuilder();
			StringBuilder sb = null;
			int ColumnsCount = dt.Columns.Count;

			if (includeHeaderAsFirstRow)
			{
				sb = new StringBuilder();
				for (int index = 0; index < ColumnsCount; index++)
				{
					if (dt.Columns[index].ColumnName != null)
						sb.Append(dt.Columns[index].ColumnName);

					if (index < ColumnsCount - 1)
						sb.Append(separator);
				}
				csvRows.AppendLine(sb.ToString());
			}

			foreach (DataRow dr in dt.Rows)
			{
				sb = new StringBuilder();
				for (int index = 0; index < ColumnsCount; index++)
				{
					string value = string.Format(string.Format("{0}", dr[index]));
					if (dt.Columns[index].DataType == typeof(String))
					{
						//If double quotes are used in value, ensure each are replaced but 2.
						if (value.IndexOf("\"") >= 0)
							value = value.Replace("\"", "\"\"");

						//If separtor are is in value, ensure it is put in double quotes.
						if (value.IndexOf(separator) >= 0)
							value = "\"" + value + "\"";
					}
					sb.Append(value);

					if (index < ColumnsCount - 1)
						sb.Append(separator);
				}

				csvRows.AppendLine(sb.ToString());
			}
			sb = null;
			return csvRows.ToString();
		}


		private static void ResponseWrite(string Result, string FileName, string ContentType)
		{
			System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;

			byte[] lstByte = System.Text.Encoding.UTF8.GetBytes(Result);

			Response.ClearHeaders();
			Response.ClearContent();
			Response.ContentType = string.Format("{0}; charset=utf-8", ContentType);
			Response.AppendHeader("Content-disposition", string.Format("attachment; filename=\"{0}\"", FileName));
			Response.AppendHeader("Content-Length", lstByte.Length.ToString());
			Response.BinaryWrite(lstByte);
			Response.Flush();
			Response.End();
		}

		#endregion
	}

	public enum SourceOfData
	{
		Table = 0,
		View = 1,
		Query = 2
	}

	public enum ExportType
	{
		Excel = 0,
		XML = 1,
		CSV = 2
	}
}
