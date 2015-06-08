using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.Framework.Providers;

namespace forDNN.Modules.DataExporter
{

	/// ----------------------------------------------------------------------------- 
	/// <summary> 
	/// SQL Server implementation of the abstract DataProvider class 
	/// </summary> 
	/// <remarks> 
	/// </remarks> 
	/// <history> 
	/// </history> 
	/// ----------------------------------------------------------------------------- 
	public class SqlDataProvider : DataProvider
	{


		#region "Private Members"

		private const string ProviderType = "data";
		private const string ModuleQualifier = "YourCompany_";

		private ProviderConfiguration _providerConfiguration = ProviderConfiguration.GetProviderConfiguration(ProviderType);
		private string _connectionString;
		private string _providerPath;
		private string _objectQualifier;
		private string _databaseOwner;

		#endregion

		#region "Constructors"

		public SqlDataProvider()
		{

			// Read the configuration specific information for this provider 
			Provider objProvider = (Provider)_providerConfiguration.Providers[_providerConfiguration.DefaultProvider];

			// Read the attributes for this provider 

			//Get Connection string from web.config 
			_connectionString = Config.GetConnectionString();

			if (_connectionString == "")
			{
				// Use connection string specified in provider 
				_connectionString = objProvider.Attributes["connectionString"];
			}

			_providerPath = objProvider.Attributes["providerPath"];

			_objectQualifier = objProvider.Attributes["objectQualifier"];
			if (_objectQualifier != "" & _objectQualifier.EndsWith("_") == false)
			{
				_objectQualifier += "_";
			}

			_databaseOwner = objProvider.Attributes["databaseOwner"];
			if (_databaseOwner != "" & _databaseOwner.EndsWith(".") == false)
			{
				_databaseOwner += ".";
			}

		}

		#endregion

		#region "Properties"

		public string ConnectionString
		{
			get { return _connectionString; }
		}

		public string ProviderPath
		{
			get { return _providerPath; }
		}

		public string ObjectQualifier
		{
			get { return _objectQualifier; }
		}

		public string DatabaseOwner
		{
			get { return _databaseOwner; }
		}

		#endregion

		#region "Private Methods"

		private string GetFullyQualifiedName(string name)
		{
			return DatabaseOwner + ObjectQualifier + ModuleQualifier + name;
		}

		private object GetNull(object Field)
		{
			return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value);
		}

		#endregion

		#region "Public Methods"

		public override IDataReader GetListOfTables()
		{
			return (IDataReader)SqlHelper.ExecuteReader(ConnectionString,
				DatabaseOwner + ObjectQualifier + "forDNN_GetListOfTables");
		}

		public override IDataReader GetListOfViews()
		{
			return (IDataReader)SqlHelper.ExecuteReader(ConnectionString,
				DatabaseOwner + ObjectQualifier + "forDNN_GetListOfViews");
		}

		public override IDataReader ExecDynamicQuery(string Query)
		{
			return (IDataReader)SqlHelper.ExecuteReader(ConnectionString,
				DatabaseOwner + ObjectQualifier + "forDNN_ExecDynamicQuery",
				Query);
		}

		#endregion

	}
}