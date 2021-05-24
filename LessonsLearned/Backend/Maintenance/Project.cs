using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Backend.DataAccess;
using PetroCanada.CorpExec.DataAccess;
//using PetroCanada.CorpExec.Maintenance;

namespace Backend.Maintenance
{
    public class Project : LLBusinessObjectBase
    {
        public Project()
        {
            m_dataTableName = "LL_PROJECT";
        }

        private object m_projectid          = DBNull.Value;
        private object m_name_e             = DBNull.Value;
        private object m_name_f             = DBNull.Value;
        private object m_desc_e             = DBNull.Value;
        private object m_desc_f             = DBNull.Value;
        private object m_active             = DBNull.Value;
        private object m_lastChangedBy      = DBNull.Value;
        private object m_lastChangedDate    = DBNull.Value;
        private object m_buid               = DBNull.Value;

        public object LastChangedBy
        {
            get
            {
                return m_lastChangedBy;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.String tmp = String.Empty;
                try
                {
                    tmp = (System.String)value;
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "LastChangedBy ", ex);
                    throw newEx;
                }
                if (tmp.Length > 25)
                {
                    System.InvalidCastException newEx = new InvalidCastException("LastChangedBy is larger then the allowable 25 characters");
                    throw newEx;
                }
                m_lastChangedBy = value;
            }
        }

        public object LastChangedDate
        {
            get
            {
                return m_lastChangedDate;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.DateTime tmp = new System.DateTime();
                try
                {
                    tmp = (System.DateTime)value;
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "LastChangedDate ", ex);
                    throw newEx;
                }

                m_lastChangedDate = value;
            }
        }

        public object ProjectId
        {
            get
            {
                return m_projectid;
            }
            set
            {
                System.Decimal tmp = new System.Decimal();
                try
                {
                    tmp = System.Decimal.Parse(value.ToString());
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Project ID ", ex);
                    throw newEx;
                }

                m_projectid = value;
            }
        }

        public object BUId
        {
            get
            {
                return m_buid;
            }
            set
            {
                System.Decimal tmp = new System.Decimal();
                try
                {
                    tmp = System.Decimal.Parse(value.ToString());
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "BU ID ", ex);
                    throw newEx;
                }

                m_buid = value;
            }
        }

        public object NameEnglish
        {
            get
            {
                return m_name_e;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.String tmp = String.Empty;
                try
                {
                    tmp = (System.String)value;
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Name English ", ex);
                    throw newEx;
                }

                m_name_e = value;
            }
        }

        public object NameFrench
        {
            get
            {
                return m_name_f;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.String tmp = String.Empty;
                try
                {
                    tmp = (System.String)value;
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Name French ", ex);
                    throw newEx;
                }

                m_name_f = value;
            }
        }

        public object DescEnglish
        {
            get
            {
                return m_desc_e;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.String tmp = String.Empty;
                try
                {
                    tmp = (System.String)value;
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Desc English ", ex);
                    throw newEx;
                }

                m_desc_e = value;
            }
        }

        public object DescFrench
        {
            get
            {
                return m_desc_f;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.String tmp = String.Empty;
                try
                {
                    tmp = (System.String)value;
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Desc French ", ex);
                    throw newEx;
                }

                m_desc_f = value;
            }
        }

        public object Active
        {
            get
            {
                return m_active;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.String tmp = String.Empty;
                try
                {
                    tmp = (System.String)value;
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Active ", ex);
                    throw newEx;
                }

                m_active = value;
            }
        }

        public void Add()
        {
            //not needed from the web app
        }

        public void Delete()
        {
            //not needed from the web app
        }

        public void Update()
        {
            //not needed from the web app
        }

        public DataSet GetAllRecords()
        {
            return AllRecords;
        }

        public DataSet GetAllActiveRecords()
        {
            return AllActiveRecords;
        }

        public DataSet GetRecordsbyBU()
        {
            return AllRecordsbyBU;
        }

        public DataSet AllActiveRecords
        {
            get
            {
                ICustomDataAdapter customDataAdapter = null;
                customDataAdapter = DataAccess.GetCustomDataAdapter();
                customDataAdapter.SelectCommand = SelectActiveCommand;
                DataSet ds = GetEmptyDataSet();
                try
                {
                    customDataAdapter.Fill(ds, m_dataTableName);
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

        public DataSet AllRecordsbyBU
        {
            get
            {
                ICustomDataAdapter customDataAdapter = null;
                customDataAdapter = DataAccess.GetCustomDataAdapter();
                customDataAdapter.SelectCommand = SelectActiveCommandbyBU;
                DataSet ds = GetEmptyDataSet();
                try
                {
                    customDataAdapter.Fill(ds, m_dataTableName);
                    decimal x = ds.Tables[0].Rows.Count;
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

        protected override IDbCommand InsertCommand
        {
            get
            {
                //NOT NEEDED FOR WEB APP
                IDbCommand cmd;
                cmd = DBConnection.CreateCommand();

                return cmd;
            }
        }

        protected override IDbCommand UpdateCommand
        {
            get
            {
               
                IDbCommand cmd;
                cmd = DBConnection.CreateCommand();


                return cmd;
            }
        }

        protected override IDbCommand DeleteCommand
        {
            get
            {
                //NOT NEEDED FOR WEB APP

                IDbCommand cmd;
                cmd = DBConnection.CreateCommand();
                return cmd;
            }
        }

        protected override IDbCommand SelectCommand
        {
            get
            {
                IDbCommand cmd;

                cmd = DBConnection.CreateCommand();
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "PKG_DIVISION.SP_GET_ALL";		
                return cmd;
            }
        }

        protected IDbCommand SelectActiveCommand
        {
            get
            {
                IDbCommand cmd;

                cmd = DBConnection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LL_PROJECT_PKG.GET_PROJECT_ALL";
                return cmd;
            }
        }

        protected IDbCommand SelectActiveCommandbyBU
        {
            get
            {
                IDbCommand cmd;

                cmd = DBConnection.CreateCommand();

                CreateParameter(ref cmd, "userId", ParameterDirection.Input, DbType.String, "USER_ID");
                CreateParameter(ref cmd, "buId", ParameterDirection.Input, DbType.Decimal, "BU_ID");

                ((IDbDataParameter)cmd.Parameters["userId"]).Value = CurrentUser;
                ((IDbDataParameter)cmd.Parameters["buId"]).Value = BUId;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LL_PROJECT_PKG.GET_PROJECT_by_BU";
                return cmd;
            }
        }

        protected override IDbCommand SelectByPkCommand
        {
            get
            {
                IDbCommand cmd;
               
                cmd = DBConnection.CreateCommand();

               
                return cmd;
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        public void Update(DataSet ds)
        {
            UpdateDatabase(ds);
        }

        public void GetByPk(System.String division)
        {
            IDbCommand cmd = null;
            IDbDataParameter param = null;
            IDataReader reader = null;

            cmd = SelectByPkCommand;
            param = (IDbDataParameter)cmd.Parameters["puserid"];
            param.Value = CurrentUser.ToString();
            param = (IDbDataParameter)cmd.Parameters["pid"];
            param.Value = division.ToString();

            try
            {
                reader = cmd.ExecuteReader();

                if (reader.IsClosed)
                {
                    throw new ApplicationException("Primary Keys returned no rows from HedgeContactGetByPk");
                }
                reader.Read();

                //m_divisionid            = reader["DIVISION_ID"];
                //m_description           = reader["DESCRIPTION"];
                //m_deleted               = reader["DELETED"];
                //m_lastChangedBy         = reader["LAST_UPDATED_BY"];
                //m_lastChangedDate       = reader["LAST_UPDATED_DATE"];
                //m_pendingAuth           = reader["PENDINGAUTH"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                        cmd.Connection.Close();

                    cmd.Connection.Dispose();
                    //rpp cmd.Dispose();
                    cmd = null;
                }

                if (reader != null)
                {
                    if (!reader.IsClosed)
                        reader.Close();
                    reader.Dispose();
                }
            }
        }

        public override void Save()
        {
            IDbCommand cmd; // TODO: This implements the dispose pattern. It could be in a using block.
            cmd = UpdateCommand;

        }

        public override void DeleteEntity()
        {

        }

        public override bool ReferencedByAnotherEntity()
        {
            return false;
        }

        public override bool CanDelete
        {
            get
            {
                //if (m_hedgeContactId != null && !Convert.IsDBNull(m_hedgeContactId) && m_hedgeContactEffDt != null && !Convert.IsDBNull(m_hedgeContactEffDt))
                //{
                //return !ReferencedByAnotherEntity();
                //}
                //else
                //{
                return false;
                //}
            }
        }
    }
}


