﻿// Contains catalog information and stored procedure wrapper classes.
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using FistCore.Common;
using FistCore.Core;

namespace Fistnet.FistBot.DAL
{
    /// <summary>
    /// Catalog used by classes in the Fistnet.FistBot.DAL namespace.
    /// Reads information from *.config file.
    /// </summary>
    [Serializable]
    public sealed class Catalog : ICatalog
    {
        #region ICatalog.

        private static readonly DbmsType dbmsType;
        private static readonly string connectionString;

        static Catalog()
        {
            string cfgDbmsType = ConfigurationManager.AppSettings["Fistnet.FistBot.DbmsType"];
            if (cfgDbmsType != null)
                dbmsType = (DbmsType)Enum.Parse(typeof(DbmsType), cfgDbmsType);

            if ((ConfigurationManager.ConnectionStrings != null) && (ConfigurationManager.ConnectionStrings["Fistnet.FistBot.ConnectionString"] != null))
                connectionString = ConfigurationManager.ConnectionStrings["Fistnet.FistBot.ConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Gets database type.
        /// </summary>
        public DbmsType DbmsType
        {
            get { return dbmsType; }
        }

        /// <summary>
        /// Gets connection string.
        /// </summary>
        public string ConnectionString
        {
            get { return connectionString; }
        }

        /// <summary>
        /// Creates a connection provider for this catalog.
        /// </summary>
        /// <returns>Connection provider that connects to this catalog.</returns>
        public IConnectionProvider CreateConnectionProvider()
        {
            DbmsType dbms = this.DbmsType;
            string connString = this.ConnectionString;

            switch (dbms)
            {
                case DbmsType.SqlServer_2008:
                case DbmsType.SqlServer_2005:
                case DbmsType.SqlServer_2000:
                case DbmsType.SqlServer_7:
                    // SqlServerConnectionProvider(DbmsType, string, IsolationLevel) constructor overload can be used to specify a custom default isolation level for BeginTransaction() method.
                    // BeginTransaction() method will use .NET defaults if a constructor which doesn't accept custom IsolationLevel value is used.
                    return new global::FistCore.Core.SqlServer.SqlServerConnectionProvider(dbms, connString);

                //case DbmsType.Oracle_11g:
                //case DbmsType.Oracle_10g:
                //case DbmsType.Oracle_9i:
                //// OracleConnectionProvider(DbmsType, string, IsolationLevel) constructor overload can be used to specify a custom default isolation level for BeginTransaction() method.
                //// BeginTransaction() method will use .NET defaults if a constructor which doesn't accept custom IsolationLevel value is used.
                //return new global::FistCore.Core.Oracle.OracleConnectionProvider(dbms, connString);

                //FistCore.Core.MySql.dll assembly must be referenced.
                //case DbmsType.MySql_5:
                //return new global::FistCore.Core.MySql.MySqlConnectionProvider(dbms, connString);

                //FistCore.Core.PostgreSql.dll, Npgsql.dll and Mono.Security assemblies must be referenced.
                //case DbmsType.PostgreSql_9:
                //return new global::FistCore.Core.PostgreSql.PostgreSqlConnectionProvider(dbms, connString);

                //FistCore.Core.Firebird.dll and FirebirdSql.Data.FirebirdClient.dll assemblies must be referenced.
                //case DbmsType.Firebird_2:
                //return new global::FistCore.Core.Firebird.FirebirdConnectionProvider(dbms, connString);

                //FistCore.Core.SQLite.dll and System.Data.SQLite.dll assemblies must be referenced. SQLite.Interop.dll must be coppied to execution directory.
                //case DbmsType.SQLite_3:
                //return new global::FistCore.Core.SQLite.SQLiteConnectionProvider(dbms, connString);

                //FistCore.Core.SqlServerCe.dll assembly must be referenced.
                //case DbmsType.SqlServerCe_4:
                //return new global::FistCore.Core.SqlServerCe.SqlServerCeConnectionProvider(dbms, connString);

                case DbmsType.OdbcGeneric:
                    return new global::FistCore.Core.Odbc.OdbcConnectionProvider(dbms, connString);

                case DbmsType.OleGeneric:
                    return new global::FistCore.Core.OleDb.OleDbConnectionProvider(dbms, connString);

                default:
                    throw new Exception("Unsupported DBMS type: " + dbms.ToString() + ".");
            }
        }

        #endregion ICatalog.

        #region Configuration - overriden/obfuscated table and column names.

        private const string TableNameOverrideKeyFormat = "Fistnet.FistBot.DAL.{0}.TableName";

        /// <summary>Gets overriden/obfuscated table name from application's configuration file.</summary>
        internal static string GetTableNameOverride(string tableName)
        {
            string settingsKey = string.Format(TableNameOverrideKeyFormat, tableName);
            return ConfigurationManager.AppSettings[settingsKey];
        }

        private const string ColumnNameOverrideKeyFormat = "Fistnet.FistBot.DAL.{0}.{1}.ColumnName";

        /// <summary>Gets overriden/obfuscated column name from application's configuration file.</summary>
        internal static string GetColumnNameOverride(string tableName, string columnName)
        {
            string settingsKey = string.Format(ColumnNameOverrideKeyFormat, tableName, columnName);
            return ConfigurationManager.AppSettings[settingsKey];
        }

        #endregion Configuration - overriden/obfuscated table and column names.
    }

    /// <summary>
    /// Contains stored procedure calls.
    /// </summary>
    public static class SP
    {
        #region TakeNextStrategy.

        /// <summary>
        /// Executes stored procedure TakeNextStrategy. Opens new connection.
        /// </summary>
        /// <returns>Data retrieved by stored procedure.</returns>
        public static StoredProcedureResult TakeNextStrategy()
        {
            IConnectionProvider conn = new Catalog().CreateConnectionProvider();
            try
            {
                StoredProcedureResult result = TakeNextStrategy(conn);
                return result;
            }
            finally
            {
                conn.Dispose();
            }
        }

        /// <summary>
        /// Executes stored procedure TakeNextStrategy. Uses given connection.
        /// </summary>
        /// <param name="conn">ConnectionProvider.</param>
        /// <returns>Data retrieved by stored procedure.</returns>
        public static StoredProcedureResult TakeNextStrategy(IConnectionProvider conn)
        {
            DbParameterCollection parameters = new DbParameterCollection();

            // Return value is fetched as Varchar but it will be converted to integer.
            // This is because some DBMSs also support return types other than integer.
            // Setting SqlDbType to int would throw an exception in such cases.
            parameters.Add(new DbParameter("ReturnValue", DbType.AnsiString, 1000, ParameterDirection.ReturnValue, true, 0, 0, null, DataRowVersion.Proposed, null));

            // Execute stored procedure.
            DataSet data = DbUtil.ExecuteMultiQuery(conn, "TakeNextStrategy", parameters, CommandType.StoredProcedure, 30);

            // Fetch return value.
            object retval = (parameters["ReturnValue"].Value == DBNull.Value) ? null : parameters["ReturnValue"].Value;

            return new StoredProcedureResult(data, retval);
        }

        #endregion TakeNextStrategy.

        #region TakeStrategy.

        /// <summary>
        /// Executes stored procedure TakeStrategy. Opens new connection.
        /// </summary>
        /// <param name="id">Input parameter: id.</param>
        /// <returns>Data retrieved by stored procedure.</returns>
        public static StoredProcedureResult TakeStrategy(int? id)
        {
            IConnectionProvider conn = new Catalog().CreateConnectionProvider();
            try
            {
                StoredProcedureResult result = TakeStrategy(conn, id);
                return result;
            }
            finally
            {
                conn.Dispose();
            }
        }

        /// <summary>
        /// Executes stored procedure TakeStrategy. Uses given connection.
        /// </summary>
        /// <param name="conn">ConnectionProvider.</param>
        /// <param name="id">Input parameter: id.</param>
        /// <returns>Data retrieved by stored procedure.</returns>
        public static StoredProcedureResult TakeStrategy(IConnectionProvider conn, int? id)
        {
            DbParameterCollection parameters = new DbParameterCollection();
            parameters.Add(new DbParameter("id", DbType.Int32, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Proposed, ((id == null) ? (object)DBNull.Value : (object)id.Value)));

            // Return value is fetched as Varchar but it will be converted to integer.
            // This is because some DBMSs also support return types other than integer.
            // Setting SqlDbType to int would throw an exception in such cases.
            parameters.Add(new DbParameter("ReturnValue", DbType.AnsiString, 1000, ParameterDirection.ReturnValue, true, 0, 0, null, DataRowVersion.Proposed, null));

            // Execute stored procedure.
            DataSet data = DbUtil.ExecuteMultiQuery(conn, "TakeStrategy", parameters, CommandType.StoredProcedure, 30);

            // Fetch return value.
            object retval = (parameters["ReturnValue"].Value == DBNull.Value) ? null : parameters["ReturnValue"].Value;

            return new StoredProcedureResult(data, retval);
        }

        #endregion TakeStrategy.
    }
}