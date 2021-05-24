using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using PetroCanada.CorpExec.DataAccess;

namespace Backend.DataAccess
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class DataAccessConnection : DataConnectionBase
    {
        //Default time out for all commands being executed is five minutes.
        public const int CommandTimeOut = 350;

        private const string dbConnectionString = "OleDBConnectionString";
        private const string OraConnectionString = "OracleConnectionString";

        public DataAccessConnection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataAccessConnection(IDbConnection connection)
            : base()
        {
            m_connection = connection;
            if (m_connection.State == ConnectionState.Closed)
            {
                try
                {
                    m_connection.Open();
                }
                catch (Exception ex)
                {
                    //If we get here we have had an unknown error occur,
                    //so we will throw the exception up the call stack.
                    ApplicationException newEx = new ApplicationException("Error creating Fast DataAccess connection, connection to the database has not been established", ex);
                    throw newEx;
                }
            }
        }

        protected override string GetLoginName()
        {
            //Get the login name of the current user and return it, we
            //are simpling go return the user name that we have had 
            //previously set on us.  Returning the Database user name
            //has no value as we are in disconnected state and FAST controls
            //user authentication from the security assembly, so the username
            //we have must be the authenticated one...  WASSA cjs.
            return m_currentUser;
        }

        public static string ConnectionString
        {
            get
            {
                //return System.Configuration.ConfigurationSettings.AppSettings[dbConnectionString];
                return ConfigurationManager.AppSettings[dbConnectionString];
            }
        }

        public static string OracleConnectionString
        {
            get
            {
                //return System.Configuration.ConfigurationSettings.AppSettings[dbConnectionString];
                return ConfigurationManager.AppSettings[OraConnectionString];
            }
        }

        protected override IDbConnection CreateAndEstablishConnection()
        {
            OleDbConnection con = null;
            try
            {
                string conStr = ConfigurationManager.AppSettings[dbConnectionString];
                if (conStr == string.Empty)
                {
                    ApplicationException ex = new ApplicationException("Error reading database connection string from application configuration file " + dbConnectionString);
                    throw ex;
                }

                con = new OleDbConnection(conStr);
            }
            catch (Exception ex)
            {
                //Catch all exceptions, and add our error message then throw
                //it up the call stack for our caller to process.
                ApplicationException newEx = new ApplicationException("Error while creating a new OLEDB Connection object", ex);
            }

            if (con.State == ConnectionState.Closed)
            {
                try
                {
                    con.Open();
                }
                catch (OleDbException ex)
                {
                    ApplicationException newEx = new ApplicationException("Error while establishing a connection to the database", ex);
                    throw newEx; //Propigate up so the user may decide what to do.
                }
            }

            return con;
        }

        public override ICustomDataAdapter GetCustomDataAdapter()
        {
            return new LLCustomDataAdapter();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
