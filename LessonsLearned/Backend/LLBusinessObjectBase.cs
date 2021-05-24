using System;
using System.Data;
using System.Text;
using PetroCanada.CorpExec.DataAccess;
using Backend.DataAccess;


namespace Backend
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public abstract class LLBusinessObjectBase : object, IDisposable
    {
        private DataAccessConnection m_dataAccessConnection = null;
        /// <summary>
        /// The name that will be used for all operations that 
        /// populate or work with datatables in anyway.
        /// </summary>
        protected string m_dataTableName = "Table1";
        protected string m_currentUser = null;
        protected const int m_ContentionErrorCode = -20001;
        protected const string m_userContentionErrorCode = "ORA-20001";
        protected string m_securityFunctionPointName = string.Empty;

        public string SecurityFunctionPointName
        {
            get
            {
                return m_securityFunctionPointName;
            }
        }

        public LLBusinessObjectBase()
            : base()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string CurrentUser
        {
            get
            {
                if (m_currentUser == null)
                {
                    throw new ApplicationException("No current user specified");
                }
                return m_currentUser;
            }
            set
            {
                m_currentUser = value;
            }
        }

        protected DataAccessConnection DataAccess
        {
            get
            {
                return DataAccessUtil.GetDataAccessObject();
            }
        }
        /// <summary>
        /// Returns a connected database connection.  The database
        /// connection will be of the correct instanciated connection
        /// i.e. OleDbConnection if using OLEDB Dataproviders.
        /// cjs July 2002
        /// </summary>
        protected IDbConnection DBConnection
        {
            get
            {
                //The DataAccessConnection takes care of all of the house
                //keeping to create and establish a connection.
                return DataAccess.Connection;
            }
        }

        /// <summary>
        /// Override this function in order to return a strongly
        /// typed dataset.  By default a loosly typed dataset is
        /// returned.
        /// </summary>
        /// <returns>A newly created dataset</returns>
        protected virtual DataSet GetEmptyDataSet()
        {
            return new DataSet();
        }

        public DataSet AllRecords
        {
            get
            {
                ICustomDataAdapter customDataAdapter = null;
                customDataAdapter = DataAccess.GetCustomDataAdapter();
                customDataAdapter.SelectCommand = SelectCommand;
                DataSet ds = GetEmptyDataSet();
                try
                {
                    customDataAdapter.Fill(ds, m_dataTableName);
                    //DataAccess = null;
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (customDataAdapter != null)
                    {
                        if (customDataAdapter.SelectCommand != null)
                        {
                            if (customDataAdapter.SelectCommand.Connection != null)
                            {
                                customDataAdapter.SelectCommand.Connection.Close();
                                customDataAdapter.SelectCommand.Connection.Dispose();
                            }

                            customDataAdapter.SelectCommand.Dispose();
                        }
                        customDataAdapter.Dispose();
                    }
                }
            }
        }



        protected abstract IDbCommand InsertCommand
        {
            get;
        }

        protected abstract IDbCommand UpdateCommand
        {
            get;
        }

        protected abstract IDbCommand DeleteCommand
        {
            get;
        }

        protected abstract IDbCommand SelectCommand
        {
            get;
        }

        protected abstract IDbCommand SelectByPkCommand
        {
            get;
        }

        protected virtual IDbCommand UsageCountCommand
        {
            get
            {
                IDbCommand countCommand = DataAccess.GetNewCommand();
                IDataParameter param;

                countCommand.CommandText = "GEN_UTIL.SP_IS_ROW_REFERENCED";
                countCommand.CommandType = CommandType.StoredProcedure;

                param = countCommand.CreateParameter();
                param.DbType = DbType.String;
                param.SourceColumn = "TABLE_NAME";
                param.Direction = System.Data.ParameterDirection.Input;
                param.ParameterName = "tableName";
                countCommand.Parameters.Add(param);

                param = countCommand.CreateParameter();
                param.DbType = DbType.Decimal;
                param.SourceColumn = "PRIMARY_KEY_ID";
                param.Direction = System.Data.ParameterDirection.Input;
                param.ParameterName = "primaryKeyId";
                countCommand.Parameters.Add(param);

                param = countCommand.CreateParameter();
                param.DbType = DbType.DateTime;
                param.SourceColumn = "PRIMARY_KEY_DT";
                param.Direction = System.Data.ParameterDirection.Input;
                param.ParameterName = "primaryKeyDt";
                countCommand.Parameters.Add(param);

                param = countCommand.CreateParameter();
                param.DbType = DbType.Decimal;
                param.SourceColumn = "USAGE_COUNT";
                param.Direction = System.Data.ParameterDirection.Output;
                param.ParameterName = "usageCount";
                countCommand.Parameters.Add(param);

                return countCommand;
            }
        }

        protected virtual void UpdateDatabase(DataSet ds)
        {
            //Update the underlying database using a dataset
            //as opposed to individual commands.
            ICustomDataAdapter da = DataAccess.GetCustomDataAdapter();

            da.SelectCommand = SelectCommand;
            da.UpdateCommand = UpdateCommand;
            da.DeleteCommand = DeleteCommand;
            da.InsertCommand = InsertCommand;

            try
            {
                da.Update(ds, m_dataTableName);

            }
            catch (System.Exception ex)
            {
                if (ex.Message.IndexOf(m_userContentionErrorCode) > -1)
                {
                    //User contention error, perculate the error to the calling
                    //application as such.
                    throw new DBConcurrencyException(ErrorStringContention, ex);
                }

                System.ApplicationException newEx = new ApplicationException("Error in performing add operation on: " +
                    "Portfolio", ex);
                //Perculate our exception up the call stack.
                throw newEx;
            }
            finally
            {
                da.Dispose();
            }
        }

        public virtual void Dispose()
        {
            if (m_dataAccessConnection != null)
                m_dataAccessConnection.Dispose();

            m_dataAccessConnection = null;
        }

        /// <summary>
        /// Return the correct database comparison clause for the where clause.
        /// If the string contains * then we are doing a wildcard search,
        /// otherwise we are looking for an exact match
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        protected string GetWildCardString(string searchString)
        {
            if (searchString.IndexOf("*") != -1)
                return " LIKE " + "'" + searchString.Replace("*", "%").ToUpper() + "'";
            else
                return " = " + "'" + searchString.ToUpper() + "'";
        }

        protected StringBuilder AddExpiryRangeToQuery(StringBuilder queryStr, Object From, Object To, bool AllowNullExpiry, string expiryDateColumnName)
        {
            DateTime effectiveFrom = DateTime.Now, effectiveTo = DateTime.Now;

            try
            {
                if (From != null && Convert.IsDBNull(From))
                {
                    //Must provide a starting date for the query.
                    throw new ApplicationException("A start date for the effective dated query must be provided");
                }

                effectiveFrom = (DateTime)From;

                //A ending date for the range is optional, so only 
                //convert the object parameter if its not null.
                if (To != null && !Convert.IsDBNull(To))
                {
                    effectiveTo = (DateTime)To;
                }
            }
            catch (InvalidCastException ex)
            {
                //We will continue to throw the exception up, as this
                //should be a developer related issue and not a data entry
                //error.
                throw ex;
            }

            queryStr.Append("		AND (((" + expiryDateColumnName + " >= TO_DATE('");
            queryStr.Append(effectiveFrom.ToString("yyyy/MM/dd"));
            queryStr.Append("','YYYY/MM/DD')");

            //We will only append the to range should the parameter be
            //non-database null.
            if (To != null && !Convert.IsDBNull(To))
            {
                queryStr.Append("		AND " + expiryDateColumnName + " <= TO_DATE('");
                queryStr.Append(effectiveTo.ToString("yyyy/MM/dd"));
                queryStr.Append("','YYYY/MM/DD'))");
            }
            else
            {
                queryStr.Append(" ) ");
            }

            if (AllowNullExpiry)
            {
                queryStr.Append(" OR " + expiryDateColumnName + " IS NULL )");
            }
            else
            {
                queryStr.Append(")");
            }

            queryStr.Append(") ");

            return queryStr;
        }


        /// <summary>
        /// The standard call to add an effective date range to a sql query.  From
        /// date is mandatory, will throw error if it is missing
        /// </summary>
        /// <param name="queryStr"></param>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <param name="effectiveDateColumnName"></param>
        /// <returns></returns>
        public static StringBuilder AddEffectiveRangeToQuery(StringBuilder queryStr, Object From, Object To, string effectiveDateColumnName)
        {
            return AddEffectiveRangeToQuery(queryStr, From, true, To, effectiveDateColumnName);
        }

        /// <summary>
        /// Overload, allows the caller to decide if the from date is mandatory or not. 
        /// It can be passed in as null if the mandatory flag is set to false
        /// </summary>
        /// <param name="queryStr"></param>
        /// <param name="From"></param>
        /// <param name="FromIsMandatory"></param>
        /// <param name="To"></param>
        /// <param name="effectiveDateColumnName"></param>
        /// <returns></returns>
        public static StringBuilder AddEffectiveRangeToQuery(StringBuilder queryStr, Object From, bool FromIsMandatory, Object To, string effectiveDateColumnName)
        {
            DateTime effectiveFrom = DateTime.Now, effectiveTo = DateTime.Now;

            try
            {
                if (From != null && !Convert.IsDBNull(From))
                {
                    effectiveFrom = (DateTime)From;
                }
                else
                {
                    if (FromIsMandatory)
                    {
                        //Must provide a starting date for the query.
                        throw new ApplicationException("A start date for the effective dated query must be provided");
                    }
                }


                //A ending date for the range is optional, so only 
                //convert the object parameter if its not null.
                if (To != null && !Convert.IsDBNull(To))
                {
                    effectiveTo = (DateTime)To;
                }
            }
            catch (InvalidCastException ex)
            {
                //We will continue to throw the exception up, as this
                //should be a developer related issue and not a data entry
                //error.
                throw ex;
            }

            //We will only append the from range should the parameter be
            //non-database null.
            if (From != null && !Convert.IsDBNull(From))
            {
                queryStr.Append("		AND " + effectiveDateColumnName + " >= TO_DATE('");
                queryStr.Append(effectiveFrom.ToString("yyyy/MM/dd"));
                queryStr.Append("','YYYY/MM/DD')");
            }

            //We will only append the to range should the parameter be
            //non-database null.
            if (To != null && !Convert.IsDBNull(To))
            {
                queryStr.Append("		AND " + effectiveDateColumnName + " <= TO_DATE('");
                queryStr.Append(effectiveTo.ToString("yyyy/MM/dd"));
                queryStr.Append("','YYYY/MM/DD')");
            }

            return queryStr;
        }

        /// <summary>
        /// Returns a standardized string explaining in user's terms that there has been a 
        /// contention issue with the object. 
        /// </summary>
        public string ErrorStringContention
        {
            get
            {
                string errString = "Another user has modified the data between the time you loaded the OBJECT and the time you tried to save the OBJECT.  Please refresh the OBJECT and try applying your changes again.";
                return errString.Replace("OBJECT", this.m_dataTableName);
            }
        }

        /// <summary>
        /// Returns a standardized string explaining in user's terms that they may not  
        /// delete the object because it is in use. 
        /// </summary>
        public virtual string ErrorStringInUse
        {
            get
            {
                string errString = "The OBJECT is in use and has other records associated with it.  You may only delete this OBJECT after deleting all of its associated records.";
                return errString.Replace("OBJECT", this.m_dataTableName);
            }
        }

        public virtual bool ReferencedByAnotherEntity()
        {
            return true;
        }

        public virtual bool CanEdit
        {
            get
            {
                return false;
            }
        }

        public virtual bool CanDelete
        {
            get
            {
                return false;
            }
        }

        public abstract void Save();
        public abstract void DeleteEntity();

        protected IDbCommand CreateParameter(ref IDbCommand cmd, String parametername, ParameterDirection type, DbType dbtype, String sourceCol)
        {
            IDbDataParameter param;

            param = (IDbDataParameter)cmd.CreateParameter();
            param.ParameterName = parametername;
            param.Direction = type;
            param.SourceColumn = sourceCol;
            param.DbType = dbtype;

            cmd.Parameters.Add(param);

            return cmd;

        }

        protected string GetBooleanDbFlag(string value)
        {
            string correctFlag = string.Empty;

            if (value != string.Empty)
            {
                switch (value.ToUpper())
                {
                    case "ON":
                        correctFlag = "Y";
                        break;
                    case "OFF":
                        correctFlag = "N";
                        break;
                    case "TRUE":
                        correctFlag = "Y";
                        break;
                    case "FALSE":
                        correctFlag = "N";
                        break;
                    case "Y":
                        correctFlag = value;
                        break;
                    case "N":
                        correctFlag = value;
                        break;
                    case "YES":
                        correctFlag = "Y";
                        break;
                    case "NO":
                        correctFlag = "N";
                        break;
                }
            }
            return correctFlag;
        }
    }
}
