
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Backend.DataAccess;
using PetroCanada.CorpExec.DataAccess;

namespace Backend.Maintenance
{
    public class Attachment : LLBusinessObjectBase
    {
        public Attachment()
        {
            m_dataTableName = "LL_Attachment";
        }

        private object  m_llid              = System.DBNull.Value;
		private object	m_attachmentid 	    = System.DBNull.Value;
		private object	m_url               = System.DBNull.Value;
        private object  m_description       = System.DBNull.Value;
        private object	m_filewithpath      = System.DBNull.Value;
        private object  m_filetitle         = System.DBNull.Value;
        private object  m_foldername        = System.DBNull.Value;
        private object  m_lastChangedBy     = System.DBNull.Value;
        private object  m_lastChangedDate   = System.DBNull.Value;
        
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
		
		public object AttachmentId
		{
			get
			{
                return m_attachmentid;
			}	
			set
			{
                System.Decimal tmp = new System.Decimal();
                try
                {
                    tmp = System.Decimal.Parse(value.ToString());
                }
				catch(Exception ex)
				{
					System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Attachment ID ", ex);				
					throw newEx;
				}

                m_attachmentid = value;
			}
		}

        public object LLId
        {
            get
            {
                return m_llid;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "LL ID ", ex);
                    throw newEx;
                }

                m_llid = value;
            }
        }


		
		public object URL
        {
            get
            {
                return m_url;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "URL ", ex);
                    throw newEx;
                }

                m_url = value;
            }
        }

        public object Description
        {
            get
            {
                return m_description;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Description ", ex);
                    throw newEx;
                }

                m_description = value;
            }
        }

        public object FileWithPath
        {
            get
            {
                return m_filewithpath;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "File with Path ", ex);
                    throw newEx;
                }

                m_filewithpath = value;
            }
        }

        public object Filetitle
        {
            get
            {
                return m_filetitle;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "File Title ", ex);
                    throw newEx;
                }

                m_filetitle = value;
            }
        }

        public object FolderName
        {
            get
            {
                return m_foldername;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Folder Name ", ex);
                    throw newEx;
                }

                m_foldername = value;
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
		
		protected override IDbCommand InsertCommand
		{
			get
			{
				//NOT NEEDED FOR WEB APP
                IDbCommand cmd;
                cmd = DBConnection.CreateCommand();

                CreateParameter(ref cmd, "userId", ParameterDirection.Input, DbType.String, "USER_ID");
                CreateParameter(ref cmd, "action", ParameterDirection.Input, DbType.String, "ACTION");
                CreateParameter(ref cmd, "attachmentid", ParameterDirection.Input, DbType.Decimal, "ID");
                CreateParameter(ref cmd, "llId", ParameterDirection.Input, DbType.Decimal, "LL_ID");
                CreateParameter(ref cmd, "url", ParameterDirection.Input, DbType.String, "URL");
                CreateParameter(ref cmd, "description", ParameterDirection.Input, DbType.String, "DESCRIPTION");
                CreateParameter(ref cmd, "filewithpath", ParameterDirection.Input, DbType.String, "FILE_WITH_PATH");
                CreateParameter(ref cmd, "filetitle", ParameterDirection.Input, DbType.String, "FILE_TITLE");
                CreateParameter(ref cmd, "foldername", ParameterDirection.Input, DbType.String, "FOLDER_NAME");

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LL_ATTACHMENT_PKG.SAVE_ATTACHMENT";

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
                cmd.CommandText = "ll_attachment_pkg.GET_ATTACHMENT";
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
            catch(Exception ex)
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
				
                if(reader != null)
                {
                    if(!reader.IsClosed)
                        reader.Close();
                    reader.Dispose();
                }
            }
		}
		
		public override void Save()
		{
            IDbCommand cmd; // TODO: This implements the dispose pattern. It could be in a using block.
            cmd = InsertCommand;

            try
            {

                ((IDbDataParameter)cmd.Parameters["userId"]).Value = CurrentUser;
                if (Convert.IsDBNull(m_attachmentid))
                {
                    ((IDbDataParameter)cmd.Parameters["action"]).Value = "INSERT";
                    ((IDbDataParameter)cmd.Parameters["attachmentId"]).Value = 0;
                }
                else
                {
                    ((IDbDataParameter)cmd.Parameters["action"]).Value = "UPDATE";
                    ((IDbDataParameter)cmd.Parameters["attachmentId"]).Value = m_attachmentid;
                }


                ((IDbDataParameter)cmd.Parameters["llId"]).Value = LLId.ToString();
                ((IDbDataParameter)cmd.Parameters["url"]).Value = URL.ToString();
                ((IDbDataParameter)cmd.Parameters["description"]).Value = Description.ToString();
                ((IDbDataParameter)cmd.Parameters["filewithpath"]).Value = FileWithPath.ToString();
                ((IDbDataParameter)cmd.Parameters["filetitle"]).Value = Filetitle.ToString();
                ((IDbDataParameter)cmd.Parameters["foldername"]).Value = FolderName.ToString();
             
                cmd.Transaction = cmd.Connection.BeginTransaction();
                cmd.ExecuteNonQuery();

                //Update our output parameters
                //LLId = ((IDbDataParameter)cmd.Parameters["llId"]).Value;

                cmd.Transaction.Commit();
            }
            catch (System.Exception ex)
            {
                if (cmd != null)
                {
                    if (cmd.Transaction != null)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
                else
                {
                    System.ApplicationException newEx = new ApplicationException("Error in performing the update operation on: " +
                        "Lessons Learned", ex);
                    //Perculate our exception up the call stack.
                    throw newEx;
                }
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    cmd.Dispose();
                }
            } 

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


