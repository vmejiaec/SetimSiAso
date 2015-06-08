using System;
using System.Data;
using DotNetNuke;

namespace forDNN.Modules.DataExporter
{

	/// ----------------------------------------------------------------------------- 
	/// <summary> 
	/// An abstract class for the data access layer 
	/// </summary> 
	/// <remarks> 
	/// </remarks> 
	/// <history> 
	/// </history> 
	/// ----------------------------------------------------------------------------- 
	public abstract class DataProvider
	{

		#region "Shared/Static Methods"

		/// <summary>
		/// singleton reference to the instantiated object 
		/// </summary>
		private static DataProvider objProvider = null;

		/// <summary>
		/// constructor
		/// </summary>
		static DataProvider()
		{
			CreateProvider();
		}

		/// <summary>
		/// dynamically create provider 
		/// </summary>
		private static void CreateProvider()
		{
			objProvider = (DataProvider)DotNetNuke.Framework.Reflection.CreateObject("data", "forDNN.Modules.DataExporter", "");
		}

		/// <summary>
		/// return the provider 
		/// </summary>
		/// <returns></returns>
		public static DataProvider Instance()
		{
			return objProvider;
		}

		#endregion

		#region "Abstract methods"

		public abstract IDataReader GetListOfTables();
		public abstract IDataReader GetListOfViews();
		public abstract IDataReader ExecDynamicQuery(string Query);

		#endregion

	}
}