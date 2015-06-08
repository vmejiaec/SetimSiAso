using System;
using System.Web.UI;

using DotNetNuke;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

namespace forDNN.Modules.DataExporter
{

	partial class Settings : ModuleSettingsBase
	{

		#region "Base Method Implementations"

		/// ----------------------------------------------------------------------------- 
		/// <summary> 
		/// LoadSettings loads the settings from the Database and displays them 
		/// </summary> 
		/// <remarks> 
		/// </remarks> 
		/// <history> 
		/// </history> 
		/// ----------------------------------------------------------------------------- 
		public override void LoadSettings()
		{
			try
			{
				if (!IsPostBack)
				{
					//if ((string)TabModuleSettings["template"] != "")
					//{
					//    txtTemplate.Text = (string)TabModuleSettings["template"];
					//}
				}
			}
			catch (Exception exc)
			{
				//Module failed to load 
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		/// ----------------------------------------------------------------------------- 
		/// <summary> 
		/// UpdateSettings saves the modified settings to the Database 
		/// </summary> 
		/// <remarks> 
		/// </remarks> 
		/// <history> 
		/// </history> 
		/// ----------------------------------------------------------------------------- 
		public override void UpdateSettings()
		{
			try
			{
				ModuleController objModules = new ModuleController();

				//objModules.UpdateTabModuleSetting(TabModuleId, "template", txtTemplate.Text);
			}

			catch (Exception exc)
			{
				//Module failed to load 
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		#endregion

	}

}

