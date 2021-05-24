
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Backend.DataAccess;
using PetroCanada.CorpExec.DataAccess;
using System.Data.OleDb;
//using PetroCanada.CorpExec.Maintenance;

namespace Backend.Maintenance
{
    public class User : LLBusinessObjectBase
    {
        public User()
        {
            m_dataTableName = "LL_USER";
        }

        private object m_lanid      = DBNull.Value;
        private object m_empno      = DBNull.Value;
        private object m_emptype    = DBNull.Value;
        private object m_email      = DBNull.Value;
        private object m_phone      = DBNull.Value;
        private object m_lastname   = DBNull.Value;
        private object m_firstname  = DBNull.Value;
        private object m_fullname   = DBNull.Value;
        private object m_department = DBNull.Value;
        private object m_orgid      = DBNull.Value;
        private object m_ll_coordinator = DBNull.Value;

       
        public object LANID
        {
            get
            {
                return m_lanid;
            }
            set
            {
                System.String tmp = String.Empty;
                try
                {
                    tmp = (System.String)value;
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "LAN ID ", ex);
                    throw newEx;
                }

                m_lanid = value;
            }
        }

        public object EmpNo
        {
            get
            {
                return m_empno;
            }
            set
            {
                  System.String tmp = String.Empty;
                try
                {
                    tmp = (System.String)value;
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Emp No.  ", ex);
                    throw newEx;
                }

                m_empno = value;
            }
        }

        public object EmployeeType
        {
            get
            {
                return m_emptype;
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

                m_emptype = value;
            }
        }

        public object EmailAddress
        {
            get
            {
                return m_email;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Email ", ex);
                    throw newEx;
                }

                m_email = value;
            }
        }

        public object Phone
        {
            get
            {
                return m_phone;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Phone ", ex);
                    throw newEx;
                }

                m_phone = value;
            }
        }

        public object LastName
        {
            get
            {
                return m_lastname;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Last Name ", ex);
                    throw newEx;
                }

                m_lastname = value;
            }
        }

        public object FirstName
        {
            get
            {
                return m_firstname;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "First Name ", ex);
                    throw newEx;
                }

                m_firstname = value;
            }
        }

        public object FullName
        {
            get
            {
                return m_fullname;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Full Name ", ex);
                    throw newEx;
                }

                m_fullname = value;
            }
        }

        public object Department
        {
            get
            {
                return m_department;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Department ", ex);
                    throw newEx;
                }

                m_department = value;
            }
        }

        public object OrgID
        {
            get
            {
                return m_orgid;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Org ID ", ex);
                    throw newEx;
                }

                m_orgid = value;
            }
        }

        public object LLCoordinator
        {
            get
            {
                return m_ll_coordinator;
            }
            set
            {
                System.String tmp = String.Empty;
                try
                {
                    tmp = (System.String)value;
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "LL Coordinator ", ex);
                    throw newEx;
                }

                m_ll_coordinator = value;
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

        public void GetByPk(System.String lanid)
        {
            IDbCommand cmd = null;
         
            IDataReader reader = null;

            cmd = DBConnection.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LL_USER_PKG.GET_USER";
            CreateParameter(ref cmd, "planId", ParameterDirection.Input, DbType.String, "LAN_ID");
            ((IDbDataParameter)cmd.Parameters["planId"]).Value = lanid;
            
            try
            {
                reader = cmd.ExecuteReader();

                //By casting it to an OleDbDataReader we can use the "HasRows" method to check against zero rows returned
                OleDbDataReader newReader = (OleDbDataReader)reader;


                if (reader.IsClosed)
                {
                    throw new ApplicationException("Primary Keys returned no rows from HedgeContactGetByPk");
                }

                if (newReader.HasRows)
                {
                    reader.Read();

                    m_lanid         = reader["LAN_ID"];
                    m_empno         = reader["EMP_NUMBER"];
                    m_emptype       = reader["EMP_TYPE"];
                    m_email         = reader["EMAIL"];
                    m_phone         = reader["PHONE"];
                    m_lastname      = reader["LAST_NAME"];
                    m_firstname     = reader["FIRST_NAME"];
                    m_department    = reader["DEPARTMENT"];
                    m_orgid         = reader["ORG_ID"];
                    m_fullname      = reader["FULL_NAME"];
                    m_ll_coordinator = reader["COORDINATOR"];
                }
                else
                {
                    m_lanid         = DBNull.Value;
                    m_empno         = DBNull.Value;
                    m_emptype       = DBNull.Value;
                    m_email         = DBNull.Value;
                    m_phone         = DBNull.Value;
                    m_lastname      = DBNull.Value;
                    m_firstname     = DBNull.Value;
                    m_department    = DBNull.Value;
                    m_orgid         = DBNull.Value;
                    m_fullname      = DBNull.Value;
                    m_ll_coordinator = DBNull.Value;                
                }

                if (newReader != null)
                {
                    if (!newReader.IsClosed)
                        newReader.Close();
                    newReader.Dispose();
                }

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
                return false;
            }
        }
    }
}






     