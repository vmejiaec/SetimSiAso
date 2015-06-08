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

namespace forDNN.Modules.DataExporter.Business
{
	public class ObjectInfo
	{
		#region Private Members

		private int _RowsCount;
		private string _ObjectName;

		#endregion

		#region Constructors
		public ObjectInfo()
		{
		}
		#endregion

		#region Public Properties

		public int RowsCount
		{
			get
			{
				return _RowsCount;
			}
			set
			{
				_RowsCount = value;
			}
		}

		public string ObjectName
		{
			get
			{
				return _ObjectName;
			}
			set
			{
				_ObjectName = value;
			}
		}

		public string Title
		{
			get
			{
				return string.Format("{0} ({1} records)", _ObjectName, _RowsCount);
			}
		}

		#endregion
	}
}
