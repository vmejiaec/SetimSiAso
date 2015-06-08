using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;

using forDNN.Modules.DataExporter.Business;

namespace forDNN.Modules.DataExporter
{

	partial class ViewDataExporter : PortalModuleBase
	{

		#region "Event Handlers"

		protected void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				InitForm();
			}

			catch (Exception exc)
			{
				//Module failed to load 
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		private void InitForm()
		{
			if (!IsPostBack)
			{
				try
				{
					ddlTables.DataSource = Business.CommonController.GetListOfTables();
					ddlTables.DataTextField = "Title";
					ddlTables.DataValueField = "ObjectName";
					ddlTables.DataBind();
				}
				catch (Exception Exc)
				{
					DotNetNuke.UI.Skins.Skin.AddModuleMessage(this, 
						"Tables Error: " + Exc.Message, 
						DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError); 
				}

				try
				{
					ddlViews.DataSource = Business.CommonController.GetListOfViews();
					ddlViews.DataTextField = "Title";
					ddlViews.DataValueField = "ObjectName";
					ddlViews.DataBind();
				}
				catch (Exception Exc)
				{
					DotNetNuke.UI.Skins.Skin.AddModuleMessage(this, 
						"Views Error: " + Exc.Message, 
						DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError);
				}

				ddlSource.Attributes.Add("onchange", "javascript:sourceChanged();");
			}

			lblIcon.Visible = true;
			lblIcon.Style["display"] = "block";
            //lblIcon.Text = "<a href=\"http://forDNN.com\" target=\"_blank\"><img src=\"http://forDNN.com/forDNNTeam.gif\" border=\"0\"/></a>";
            lblIcon.Text = ".";

			ddlTables.Style["display"] = "none";
			ddlViews.Style["display"] = "none";
			tbQuery.Style["display"] = "none";

			switch (ddlSource.SelectedValue)
			{
				case "0":
					ddlTables.Style["display"] = "block";
					break;
				case "1":
					ddlViews.Style["display"] = "block";
					break;
				case "2":
					tbQuery.Style["display"] = "block";
					break;
			}
		}
		
		#endregion

		protected void btnExport_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ddlSource.SelectedValue)
				{
					case "0":
						Business.CommonController.ExportData(SourceOfData.Table,
							ddlTables.SelectedValue,
							(ExportType)Convert.ToInt32(rblExportType.SelectedValue));
						break;
					case "1":
						Business.CommonController.ExportData(SourceOfData.View,
							ddlViews.SelectedValue,
							(ExportType)Convert.ToInt32(rblExportType.SelectedValue));
						break;
					case "2":
						Business.CommonController.ExportData(SourceOfData.Query,
							tbQuery.Text,
							(ExportType)Convert.ToInt32(rblExportType.SelectedValue));
						break;
				}
			}
			catch (Exception Exc)
			{
				DotNetNuke.UI.Skins.Skin.AddModuleMessage(this, Exc.Message, DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError);
			}
		}

	}

}