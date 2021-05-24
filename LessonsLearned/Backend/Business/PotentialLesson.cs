using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Backend.DataAccess;
//using PetroCanada.CorpExec.Security;
using PetroCanada.CorpExec.DataAccess;
using Backend;
//using Backend.Reference;


namespace Backend.Business
{
    public class PotentialLesson : LLBusinessObjectBase
    {
        public PotentialLesson()
        {
            m_dataTableName = "LL_POTENTIAL";
        }

        private object m_llId              = System.DBNull.Value;
        private object m_statusId          = System.DBNull.Value;
        private object m_username          = System.DBNull.Value;
        private object m_firstname         = System.DBNull.Value;
        private object m_lastname          = System.DBNull.Value;
        private object m_phone             = System.DBNull.Value;
        private object m_location          = System.DBNull.Value;
        private object m_sbuid             = System.DBNull.Value;
        private object m_buid              = System.DBNull.Value;
        private object m_projectId         = System.DBNull.Value;
        private object m_projectother      = System.DBNull.Value;
        private object m_title             = System.DBNull.Value;
        private object m_statement         = System.DBNull.Value;
        private object m_background        = System.DBNull.Value;
        private object m_response          = System.DBNull.Value;
        private object m_comments          = System.DBNull.Value;
        private object m_typeID            = System.DBNull.Value;
        private object m_impactId          = System.DBNull.Value;
        private object m_frequencyId       = System.DBNull.Value;
        private object m_subjectmatterID   = System.DBNull.Value;
        private object m_disciplineId      = System.DBNull.Value;
        private object m_categoryId        = System.DBNull.Value;
        private object m_stageId           = System.DBNull.Value;
        private object m_createdby         = System.DBNull.Value;
        private object m_createddate       = System.DBNull.Value;
        private object m_lastChangedBy     = System.DBNull.Value;
        private object m_lastChangedDate   = System.DBNull.Value;
        private object m_reference         = System.DBNull.Value;
        private object m_typeother         = System.DBNull.Value;
        private object m_financialimpactId = System.DBNull.Value;
        private object m_importfromExcel   = System.DBNull.Value;

        private object m_description        = DBNull.Value;
        //private PetroCanada.CorpExec.Security.Account m_account = null;
       
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

        public object LLId
        {
            get
            {
                return m_llId;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.Decimal tmp = new System.Decimal();
                try
                {
                    tmp = System.Decimal.Parse(value.ToString());
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "LL Id ", ex);
                    throw newEx;
                }

                m_llId = value;
            }
        }

        public object StatusId
        {
            get
            {
                return m_statusId;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.Decimal tmp = new System.Decimal();
                try
                {
                    tmp = System.Decimal.Parse(value.ToString());
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Status Id ", ex);
                    throw newEx;
                }

                m_statusId = value;
            }
        }

        public object UserName
        {
            get
            {
                return m_username;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "User Name ", ex);
                    throw newEx;
                }

                m_username = value;
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

        public object Location
        {
            get
            {
                return m_location;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Location ", ex);
                    throw newEx;
                }
                m_location = value;
            }
        }

        public object SBUId
        {
            get
            {
                return m_sbuid;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.Decimal tmp = new System.Decimal();
                try
                {
                    tmp = System.Decimal.Parse(value.ToString());
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Project Id ", ex);
                    throw newEx;
                }

                m_sbuid = value;
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
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.Decimal tmp = new System.Decimal();
                try
                {
                    tmp = System.Decimal.Parse(value.ToString());
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Project Id ", ex);
                    throw newEx;
                }

                m_buid = value;
            }
        }

        public object ProjectId
        {
            get
            {
                return m_projectId;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.Decimal tmp = new System.Decimal();
                try
                {
                    tmp = System.Decimal.Parse(value.ToString());
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Project Id ", ex);
                    throw newEx;
                }

                m_projectId = value;
            }
        }

        public object ProjectOther
        {
            get
            {
                return m_projectother;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Project Other ", ex);
                    throw newEx;
                }
                m_projectother = value;
            }
        }

        public object Title
        {
            get
            {
                return m_title;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Title ", ex);
                    throw newEx;
                }
                m_title = value;
            }
        }

        public object Statement
        {
            get
            {
                return m_statement;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Statement ", ex);
                    throw newEx;
                }
                m_statement = value;
            }
        }

        public object Background
        {
            get
            {
                return m_background;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Background ", ex);
                    throw newEx;
                }
                m_background = value;
            }
        }

        public object Response
        {
            get
            {
                return m_response;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Response ", ex);
                    throw newEx;
                }
                m_response = value;
            }
        }

        public object Reference
        {
            get
            {
                return m_reference;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Reference ", ex);
                    throw newEx;
                }
                m_reference = value;
            }
        }

        public object ImportfromExcel
        {
            get
            {
                return m_importfromExcel;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Import from Excel ", ex);
                    throw newEx;
                }
                m_importfromExcel = value;
            }
        }

        public object Comments
        {
            get
            {
                return m_comments;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Comments ", ex);
                    throw newEx;
                }
                m_comments = value;
            }
        }

        public object TypeId
        {
            get
            {
                return m_typeID;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.Decimal tmp = new System.Decimal();
                try
                {
                    tmp = System.Decimal.Parse(value.ToString());
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Type Id ", ex);
                    throw newEx;
                }

                m_typeID = value;
            }
        }

        public object TypeOther
        {
            get
            {
                return m_typeother;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Type Other ", ex);
                    throw newEx;
                }
                m_typeother = value;
            }
        }

        public object ImpactId
        {
            get
            {
                return m_impactId;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.Decimal tmp = new System.Decimal();
                try
                {
                    tmp = System.Decimal.Parse(value.ToString());
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Impact Id ", ex);
                    throw newEx;
                }

                m_impactId = value;
            }
        }

        public object FinancialImpactId
        {
            get
            {
                return m_financialimpactId;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.Decimal tmp = new System.Decimal();
                try
                {
                    tmp = System.Decimal.Parse(value.ToString());
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Financial Impact Id ", ex);
                    throw newEx;
                }

                m_financialimpactId = value;
            }
        }

        public object FrequencyId
        {
            get
            {
                return m_frequencyId;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.Decimal tmp = new System.Decimal();
                try
                {
                    tmp = System.Decimal.Parse(value.ToString());
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Frequency Id ", ex);
                    throw newEx;
                }

                m_frequencyId = value;
            }
        }

        public object SubjectMatterId
        {
            get
            {
                return m_subjectmatterID;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.Decimal tmp = new System.Decimal();
                try
                {
                    tmp = System.Decimal.Parse(value.ToString());
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Subject Matter Id ", ex);
                    throw newEx;
                }

                m_subjectmatterID = value;
            }
        }

        public object DisciplineId
        {
            get
            {
                return m_disciplineId;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.Decimal tmp = new System.Decimal();
                try
                {
                    tmp = System.Decimal.Parse(value.ToString());
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Discipline Id ", ex);
                    throw newEx;
                }

                m_disciplineId = value;
            }
        }

        public object CategoryId
        {
            get
            {
                return m_categoryId;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.Decimal tmp = new System.Decimal();
                try
                {
                    tmp = System.Decimal.Parse(value.ToString());
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Category Id ", ex);
                    throw newEx;
                }

                m_categoryId = value;
            }
        }

        public object StageId
        {
            get
            {
                return m_stageId;
            }
            set
            {
                //Do very basic validatiion such as is the object convertable to what we 
                //need?
                System.Decimal tmp = new System.Decimal();
                try
                {
                    tmp = System.Decimal.Parse(value.ToString());
                }
                catch (Exception ex)
                {
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Stage Id ", ex);
                    throw newEx;
                }

                m_stageId = value;
            }
        }
       


       
        public override void Save()
        {

            IDbCommand cmd; // TODO: This implements the dispose pattern. It could be in a using block.
            cmd = InsertCommand;

            try
            {

                ((IDbDataParameter)cmd.Parameters["userId"]).Value = CurrentUser;
                if (Convert.IsDBNull(m_llId))
                {
                    ((IDbDataParameter)cmd.Parameters["action"]).Value = "INSERT";
                    ((IDbDataParameter)cmd.Parameters["llId"]).Value = 0;
                }
                else
                {
                    ((IDbDataParameter)cmd.Parameters["action"]).Value = "UPDATE";
                    ((IDbDataParameter)cmd.Parameters["llId"]).Value = m_llId;
                }


                ((IDbDataParameter)cmd.Parameters["statusId"]).Value                = StatusId;
                ((IDbDataParameter)cmd.Parameters["userName"]).Value                = UserName.ToString();
                ((IDbDataParameter)cmd.Parameters["firstName"]).Value               = FirstName.ToString();
                ((IDbDataParameter)cmd.Parameters["lastName"]).Value                = LastName.ToString();
                ((IDbDataParameter)cmd.Parameters["phone"]).Value                   = Phone.ToString();
                ((IDbDataParameter)cmd.Parameters["location"]).Value                = Location.ToString();
                ((IDbDataParameter)cmd.Parameters["sbuid"]).Value                   = SBUId;
                ((IDbDataParameter)cmd.Parameters["buid"]).Value                    = BUId;
                ((IDbDataParameter)cmd.Parameters["projectId"]).Value               = ProjectId;
                ((IDbDataParameter)cmd.Parameters["projectother"]).Value            = ProjectOther;

                ((IDbDataParameter)cmd.Parameters["title"]).Value                   = Title.ToString();
                ((IDbDataParameter)cmd.Parameters["statement"]).Value               = Statement.ToString();
                ((IDbDataParameter)cmd.Parameters["background"]).Value              = Background.ToString();
                ((IDbDataParameter)cmd.Parameters["response"]).Value                = Response.ToString();
                ((IDbDataParameter)cmd.Parameters["comments"]).Value                = Comments.ToString();
                ((IDbDataParameter)cmd.Parameters["typeId"]).Value                  = TypeId;
                ((IDbDataParameter)cmd.Parameters["impactId"]).Value                = ImpactId;
                ((IDbDataParameter)cmd.Parameters["frequencyId"]).Value             = FrequencyId;

                ((IDbDataParameter)cmd.Parameters["reference"]).Value               = Reference;
                ((IDbDataParameter)cmd.Parameters["typeother"]).Value               = TypeOther;
                ((IDbDataParameter)cmd.Parameters["financialimpactid"]).Value       = FinancialImpactId;
                ((IDbDataParameter)cmd.Parameters["importfromexcel"]).Value         = ImportfromExcel.ToString();
                
                cmd.Transaction = cmd.Connection.BeginTransaction();
                cmd.ExecuteNonQuery();

                //Update our output parameters
                LLId = ((IDbDataParameter)cmd.Parameters["llId"]).Value;

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
                throw new Backend.LLException("Failed to save document.", ex);
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

        public void SaveSubjectMatterInfo()
        {

            IDbCommand cmd;
            cmd = SaveSubjectMatterCommand;

            try
            {
                ((IDbDataParameter)cmd.Parameters["userId"]).Value = CurrentUser;
                ((IDbDataParameter)cmd.Parameters["llid"]).Value = LLId;
                ((IDbDataParameter)cmd.Parameters["subjectmatterId"]).Value = SubjectMatterId;
                ((IDbDataParameter)cmd.Parameters["description"]).Value = m_description;

                cmd.Transaction = cmd.Connection.BeginTransaction();
                cmd.ExecuteNonQuery();
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
                        "LessonLearned Subject Matter Expert", ex);
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

        public void SaveCategoryInfo()
        {

            IDbCommand cmd;
            cmd = SaveCategoryCommand;

            try
            {
                ((IDbDataParameter)cmd.Parameters["userId"]).Value = CurrentUser;
                ((IDbDataParameter)cmd.Parameters["llid"]).Value = LLId;
                ((IDbDataParameter)cmd.Parameters["categoryId"]).Value = CategoryId;

                cmd.Transaction = cmd.Connection.BeginTransaction();
                cmd.ExecuteNonQuery();
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
                        "LessonLearned Category", ex);
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

        public void SaveStageInfo()
        {

            IDbCommand cmd;
            cmd = SaveStageCommand;

            try
            {
                ((IDbDataParameter)cmd.Parameters["userId"]).Value = CurrentUser;
                ((IDbDataParameter)cmd.Parameters["llid"]).Value = LLId;
                ((IDbDataParameter)cmd.Parameters["stageId"]).Value = StageId;
                ((IDbDataParameter)cmd.Parameters["description"]).Value = m_description;

                cmd.Transaction = cmd.Connection.BeginTransaction();
                cmd.ExecuteNonQuery();
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
                        "LessonLearned Stage", ex);
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

        protected override IDbCommand SelectCommand
        {
            get { throw new Exception("The method or operation is not implemented.");  }
        }

        protected override IDbCommand UpdateCommand
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override void DeleteEntity()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Delete()
        {
            //IDbCommand cmd;
            //cmd = DeleteCommand;
            //try
            //{
            //    ((IDbDataParameter)cmd.Parameters["locId"]).Value = LocId.ToString();
            //    ((IDbDataParameter)cmd.Parameters["UserId"]).Value = CurrentUser.ToString();
                
            //    cmd.Transaction = cmd.Connection.BeginTransaction();
            //    cmd.ExecuteNonQuery();

            //}
            //catch (Exception ex)
            //{
            //    if (cmd != null)
            //    {
            //        if (cmd.Transaction != null)
            //        {
            //            cmd.Transaction.Rollback();
            //        }
            //        cmd.Dispose();
            //    }
            //    ApplicationException newEx = new ApplicationException("Error in performing the delete operation on: " +
            //        "Letter Of Credit", ex);
            //    throw newEx;
            //}
            //finally
            //{
            //    if (cmd != null)
            //    {
            //        cmd.Transaction.Commit();
            //        cmd.Connection.Close();
            //        cmd.Dispose();
            //        cmd.Dispose();
            //    }
            //}
        }

       

        protected override IDbCommand InsertCommand
        {
            get
            {
                IDbCommand cmd;
                cmd = DBConnection.CreateCommand();

                CreateParameter(ref cmd,"userId",     ParameterDirection.Input,DbType.String,  "USER_ID");
                CreateParameter(ref cmd, "action", ParameterDirection.Input, DbType.String, "ACTION");
                CreateParameter(ref cmd, "llId", ParameterDirection.InputOutput, DbType.Decimal, "LL_ID");
                CreateParameter(ref cmd, "statusId", ParameterDirection.Input, DbType.Decimal, "STATUS_ID");
                CreateParameter(ref cmd, "userName", ParameterDirection.Input, DbType.String, "USER_NAME");
                CreateParameter(ref cmd, "firstName", ParameterDirection.Input, DbType.String, "FIRST_NAME");
                CreateParameter(ref cmd, "lastName", ParameterDirection.Input, DbType.String, "LAST_NAME");
                CreateParameter(ref cmd, "phone", ParameterDirection.Input, DbType.String, "PHONE");

                CreateParameter(ref cmd, "location", ParameterDirection.Input, DbType.String, "LOCATION");
                CreateParameter(ref cmd, "sbuid", ParameterDirection.Input, DbType.Decimal, "SBU_ID");
                CreateParameter(ref cmd, "buid", ParameterDirection.Input, DbType.Decimal, "BU_ID");
                CreateParameter(ref cmd, "projectId", ParameterDirection.Input, DbType.Decimal, "PROJECT_ID");
                CreateParameter(ref cmd, "projectother", ParameterDirection.Input, DbType.String, "PROJECT_OTHER");

                CreateParameter(ref cmd, "title", ParameterDirection.Input, DbType.String, "TITLE");
                CreateParameter(ref cmd, "statement", ParameterDirection.Input, DbType.String, "STATEMENT");
                CreateParameter(ref cmd, "background", ParameterDirection.Input, DbType.String, "BACKGROUND");
                CreateParameter(ref cmd, "response", ParameterDirection.Input, DbType.String, "RESPONSE");

                CreateParameter(ref cmd, "comments", ParameterDirection.Input, DbType.String, "COMMENTS");
                CreateParameter(ref cmd, "typeId", ParameterDirection.Input, DbType.Decimal, "TYPE_ID");
                CreateParameter(ref cmd, "impactId", ParameterDirection.Input, DbType.Decimal, "IMPACT_ID");
                CreateParameter(ref cmd, "frequencyId", ParameterDirection.Input, DbType.Decimal, "FREQUENCY_ID");

                CreateParameter(ref cmd, "reference", ParameterDirection.Input, DbType.String, "REFERENCE");
                CreateParameter(ref cmd, "typeother", ParameterDirection.Input, DbType.String, "TYPE_OTHER");
                CreateParameter(ref cmd, "financialimpactid", ParameterDirection.Input, DbType.Decimal, "FINANCIAL_IMPACT_ID");
                CreateParameter(ref cmd, "importfromexcel", ParameterDirection.Input, DbType.String, "IMPORT_FROM_EXCEL");

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LL_POTENTIAL_PKG.LL_POTENTIAL_SAVE";

                return cmd;
            }
        }

        protected IDbCommand SaveSubjectMatterCommand
        {
            get
            {
                IDbCommand cmd;
                cmd = DBConnection.CreateCommand();

                CreateParameter(ref cmd, "userId", ParameterDirection.Input, DbType.String, "USER_ID");
                CreateParameter(ref cmd, "llId", ParameterDirection.Input, DbType.Decimal, "LL_ID");
                CreateParameter(ref cmd, "subjectmatterId", ParameterDirection.Input, DbType.Decimal, "SUBJECT_MATTER_ID");
                CreateParameter(ref cmd, "description", ParameterDirection.Input, DbType.Decimal, "DESCRIPTION");

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LL_POTENTIAL_PKG.LL_POTENTIAL_SUBJECT_MAT_SAVE";

                return cmd;
            }
        }

        protected IDbCommand SaveCategoryCommand
        {
            get
            {
                IDbCommand cmd;
                cmd = DBConnection.CreateCommand();

                CreateParameter(ref cmd, "userId", ParameterDirection.Input, DbType.String, "USER_ID");
                CreateParameter(ref cmd, "llId", ParameterDirection.Input, DbType.Decimal, "LL_ID");
                CreateParameter(ref cmd, "categoryId", ParameterDirection.Input, DbType.Decimal, "CATEGORY_ID");


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LL_POTENTIAL_PKG.LL_POTENTIAL_CATEGORY_SAVE";

                return cmd;
            }
        }


        protected IDbCommand SaveStageCommand
        {
            get
            {
                IDbCommand cmd;
                cmd = DBConnection.CreateCommand();

                CreateParameter(ref cmd, "userId", ParameterDirection.Input, DbType.String, "USER_ID");
                CreateParameter(ref cmd, "llId", ParameterDirection.Input, DbType.Decimal, "LL_ID");
                CreateParameter(ref cmd, "stageId", ParameterDirection.Input, DbType.Decimal, "STAGE_ID");
                CreateParameter(ref cmd, "description", ParameterDirection.Input, DbType.String, "DESCRIPTION");


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LL_POTENTIAL_PKG.LL_POTENTIAL_STAGE_SAVE";

                return cmd;
            }
        }

        protected override IDbCommand DeleteCommand
        {
            get
            {
                IDbCommand cmd;
                IDbDataParameter param;

                cmd = DBConnection.CreateCommand();

                param = (IDbDataParameter)cmd.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "UserId";
                param.Direction = ParameterDirection.Input;
                param.SourceColumn = "USER_ID";
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.DbType = DbType.Decimal;
                param.ParameterName = "locId";
                param.Direction = ParameterDirection.Input;
                param.SourceColumn = "LOC_ID";
                param.DbType = DbType.Decimal;
                cmd.Parameters.Add(param);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_LETTEROFCREDIT.LOC_LETTEROFCREDIT_DELETE";
                return cmd;
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        //protected Account AccountObject
        //{
        //    get
        //    {
        //        return new PetroCanada.CorpExec.Security.Account(DataAccessUtil.ConnectionString);
        //    }
        //}

        private void PopulateClassAttributes(IDataReader reader)
        {
            if (reader.IsClosed)
            {
                throw new ApplicationException("Primary Keys returned no rows from HedgeGetByPk");
            }

            reader.Read();

            //m_locId             = reader["LOC_ID"];
            //m_letternumber      = reader["LETTER_NUMBER"];
            //m_prevletternumber  = reader["PREV_LETTER_NUMBER"];
            //m_beneficiary       = reader["BENEFICIARY"];
            //m_bunit             = reader["BUSINESS_UNIT"];
            //m_regionDivision    = reader["REGION_DIVISION"];
            //m_regionDivisionID  = reader["REGION_DIVISION_ID"];
            //m_leadcontact       = reader["LEAD_CONTACT"];
            //m_type              = reader["LC_TYPE"];
            //m_cpty              = reader["COUNTER_PARTY"];
            //m_creditline        = reader["CREDIT_FACILITY"];
            ////m_curr              = reader["CURRENCY"];
            //m_deletedflag       = reader["DELETED_FLAG"];
            ////m_issuancefee       = reader["ISSUANCE_FEE"];
            //m_notes             = reader["NOTES"];
            //m_outletcostcenter  = reader["OUTLET_COST_CENTER"];
            //m_lastChangedBy     = reader["LAST_UPDATED_BY"];
            //m_lastChangedDate   = reader["LAST_UPDATE_DATE"];
            //m_department        = reader["DEPARTMENT"];
            //m_amendmentId       = reader["AMENDMENT_ID"];
            //m_maxAmendmentSeq   = reader["MAXAMENDMDENT"];
            //m_dailFeeCalc       = reader["DAILY_FEE_CALC"];

           

        }

        public DataSet FindLOC( object lcnumber, object prvlcnumber, object amount, object issuancedate,
                                object expirydate, object amendmentdate, object beneficiary, object businessunit,
                                object regiondivision, object department, object leadcontact, object lctype, 
                                object parental, object counter, object counterparty, object creditfacility)

        {
            //string effDateColumn = "hg.HEDGE_EFF_DT";
            //string expDateColumn = "hg.HEDGE_EXP_DT";

            StringBuilder selectBuilder = new StringBuilder();

            //Build the string for the query

            selectBuilder.Append("Select    loc.id             LOC_ID,                 ");
            selectBuilder.Append("          loc.LETTERNUMBER   LC_NUMBER,            ");
            selectBuilder.Append("          loc.PREV_LETTER_NUMBER  PREV_LC_NUMBER,  ");
            selectBuilder.Append("          amen.Amount        AMOUNT,               ");
            selectBuilder.Append("          amen.ISSUANCEDATE  ISSUANCE_DATE,        ");
            selectBuilder.Append("          amen.EXPIRYDATE    EXPIRY_DATE,          ");       
            selectBuilder.Append("          amen.AMENDMENTDATE AMENDMENT_DATE,       ");
            selectBuilder.Append("          loc.BENEFICIARY    BENEFICIARY,          ");
            selectBuilder.Append("          loc.BUNIT          BUSINESS_UNIT,        ");
            selectBuilder.Append("          reg.DESCRIPTION    DESCRIPTION,          ");
            selectBuilder.Append("          loc.LEADCONTACT    LEAD_CONTACT,         ");
            selectBuilder.Append("          loc.Type           TYPE,                 ");
            selectBuilder.Append("          loc.Cpty           COUNTER_PARTY,        ");
            selectBuilder.Append("          loc.CREDITLINE     CREDIT_FACILITY       ");
            selectBuilder.Append("     FROM LOC_LETTEROFCREDIT loc,                  ");
            selectBuilder.Append("          LOC_REGION reg,                          ");
            selectBuilder.Append("          LOC_AMENDMENT amen                       ");
            selectBuilder.Append("    WHERE loc.REGIONID = reg.id(+)                 ");
            selectBuilder.Append("      AND loc.id = amen.lcid(+)                    ");
            selectBuilder.Append("      AND loc.deletedflag = 'N'                    ");
            selectBuilder.Append("      AND amen.amendmentseq = (Select max(amendmentseq)  ");
            selectBuilder.Append("                            from loc_amendment b   ");
            selectBuilder.Append("                           where b.lcid = amen.lcid) ");
            if (!Convert.IsDBNull(lcnumber))
            {
                selectBuilder.Append("		and upper(loc.LETTERNUMBER) " + GetWildCardString(lcnumber.ToString()));
            }

            if (!Convert.IsDBNull(prvlcnumber))
            {
                selectBuilder.Append("		and upper(loc.PREV_LETTER_NUMBER) " + GetWildCardString(prvlcnumber.ToString()));
            }

            if (!Convert.IsDBNull(amount))
            {
                selectBuilder.Append("		and amen.Amount " + GetWildCardString(amount.ToString()));
            }

            if (issuancedate != null)
            {
                selectBuilder.Append("		and amen.ISSUANCEDATE " + GetWildCardString(issuancedate.ToString()));
            }
             if (expirydate != null)
            {
                selectBuilder.Append("		and amen.EXPIRYDATE " + GetWildCardString(expirydate.ToString()));
            }
             if (amendmentdate != null)
            {
                selectBuilder.Append("		and amen.AMENDMENTDATE " + GetWildCardString(amendmentdate.ToString()));
            }
             if (!Convert.IsDBNull(beneficiary))
            {
                selectBuilder.Append("		and upper(loc.BENEFICIARY) " + GetWildCardString(beneficiary.ToString()));
            }

            if (!Convert.IsDBNull(businessunit))
            {
                selectBuilder.Append("		and upper(loc.BUNIT) " + GetWildCardString(businessunit.ToString()));
            }

            if (!Convert.IsDBNull(regiondivision))
            {
                selectBuilder.Append("		and upper(reg.ID) " + GetWildCardString(regiondivision.ToString()));
            }

            if (!Convert.IsDBNull(department))
            {
                selectBuilder.Append("		and upper(loc.DEPARTMENT) " + GetWildCardString(department.ToString()));
            }

            if (!Convert.IsDBNull(leadcontact))
            {
                selectBuilder.Append("		and upper(loc.LEADCONTACT) " + GetWildCardString(leadcontact.ToString()));
            }

            if (!Convert.IsDBNull(lctype))
            {
                selectBuilder.Append("		and upper(loc.Type) " + GetWildCardString(lctype.ToString()));
            }
            if (!Convert.IsDBNull(counterparty))
            { 
                selectBuilder.Append("      and upper(loc.CPTY) " + GetWildCardString(counterparty.ToString()));
            }

            if (!Convert.IsDBNull(creditfacility))
            {
                selectBuilder.Append("		and upper(loc.CREDITLINE) " + GetWildCardString(creditfacility.ToString()));
            }
            

            
            //else if (includeHistoricalRecords)
            //{
            //    selectBuilder = AddEffectiveRangeToQuery(selectBuilder, From, To, effDateColumn);
            //    selectBuilder = AddExpiryRangeToQuery(selectBuilder, From, To, false, expDateColumn);
            //}
            //else
            //{
            //    //Assume by default to only include latest records,
            //    //because if we get here the callee has set the 
            //    //includeHistoricalRecords to false as well as the
            //    //includeLatestRecords to false, which would produce
            //    //a mixed result set and we don't want that by default.
            //    //So we assume latest records only.
            //    selectBuilder.Append(" AND HG.HEDGE_EXP_DT IS NULL ");
            //}
            selectBuilder.Append("  group by loc.ID, loc.letternumber,prev_letter_number, amount, issuancedate, expirydate, amen.amendmentdate, beneficiary,loc.bunit,description, loc.leadcontact,TYPE,loc.cpty, loc.creditline");

            selectBuilder.Append(" order by LC_NUMBER, PREV_LC_NUMBER, AMOUNT, ISSUANCE_DATE, EXPIRY_DATE, AMENDMENT_DATE, BENEFICIARY, BUSINESS_UNIT, DESCRIPTION, LEAD_CONTACT, TYPE, COUNTER_PARTY, CREDIT_FACILITY");

            DataSet ds = GetEmptyDataSet();
            ICustomDataAdapter da = DataAccess.GetCustomDataAdapter();
            IDbCommand cmd = DataAccess.GetNewCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandTimeout = DataAccessConnection.CommandTimeOut;
            cmd.CommandText = selectBuilder.ToString().Replace("\t", "    ");
            try
            {
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                //If we get an error opening the result for the stored
                //procedure, we likely have a a farily major problem.  
                //Permissions issues or something of the kind.  We will
                //percolate the call back up the stack so the front end
                //may report it and thus the user can log the error
                //for repair.
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    cmd.Dispose();
                    cmd = null;
                }

                if (da != null)
                {
                    da.Dispose();
                    da = null;
                }
            }
            return ds;
        }

        public DataSet GetDetailsByPk(System.Decimal locId)
        {
            ICustomDataAdapter da = DataAccess.GetCustomDataAdapter();
            DataSet results = new DataSet();  //make sure we use a loosely typed dataset as there will be more columns returned than just from the hedge table

            IDbCommand cmd;
            IDbDataParameter param;

            cmd = SelectDetailsByPkCommand;
            param = (IDbDataParameter)cmd.Parameters["locId"];
            param.Value = locId;

            param = (IDbDataParameter)cmd.Parameters["UserId"];
            param.Value = CurrentUser;
          
            try
            {
                da.SelectCommand = cmd;
                da.Fill(results);
            }
            catch (Exception ex)
            {
                //If we get an error opening the result for the stored
                //procedure, we likely have a a farily major problem.  
                //Permissions issues or something of the kind.  We will
                //percolate the call back up the stack so the front end
                //may report it and thus the user can log the error
                //for repair.
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    cmd.Dispose();
                    cmd = null;
                }

                if (da != null)
                {
                    da.Dispose();
                    da = null;
                }
            }

            return results;
        }

        protected IDbCommand SelectDetailsByPkCommand
        {
            get
            {
                IDbCommand cmd;
                IDbDataParameter param;

                cmd = DBConnection.CreateCommand();

                param = (IDbDataParameter)cmd.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "UserId";
                param.Direction = ParameterDirection.Input;
                param.SourceColumn = "USER_ID";
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.DbType = DbType.Decimal;
                param.ParameterName = "locId";
                param.Direction = ParameterDirection.Input;
                param.SourceColumn = "LOC_ID";
                param.DbType = DbType.Decimal;
                cmd.Parameters.Add(param);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_LETTEROFCREDIT.SP_GET_LOC_DETAILS";
                return cmd;
            }
        }

        public void GetByPk(System.Decimal locId)
        {
            IDbCommand cmd;
            IDbDataParameter param;
            IDataReader reader = null;

            cmd = SelectByPkCommand;
            param = (IDbDataParameter)cmd.Parameters["locId"];
            param.Value = locId;
            param = (IDbDataParameter)cmd.Parameters["UserId"];
            param.Value = CurrentUser;

            try
            {
                reader = cmd.ExecuteReader();
                PopulateClassAttributes(reader);
            }
            catch (Exception ex)
            {
                //If we get an error opening the result for the stored
                //procedure, we likely have a a farily major problem.  
                //Permissions issues or something of the kind.  We will
                //percolate the call back up the stack so the front end
                //may report it and thus the user can log the error
                //for repair.
                throw ex;
            }
            finally
            {
                //Cleanup the reader we used.
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }
                if (cmd != null)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    cmd.Dispose();
                    cmd = null;
                }
            }
        }

        public DataSet GetByPkDataSet(System.Decimal locId)
        {
            ICustomDataAdapter da = DataAccess.GetCustomDataAdapter();
            DataSet results = new DataSet();  //make sure we use a loosely typed dataset as there will be more columns returned than just from the hedge table

            IDbCommand cmd;
            IDbDataParameter param;

            cmd = SelectByPkCommand;
            param = (IDbDataParameter)cmd.Parameters["locId"];
            param.Value = locId;

            param = (IDbDataParameter)cmd.Parameters["UserId"];
            param.Value = CurrentUser;

            try
            {
                da.SelectCommand = cmd;
                da.Fill(results);
            }
            catch (Exception ex)
            {
                //If we get an error opening the result for the stored
                //procedure, we likely have a a farily major problem.  
                //Permissions issues or something of the kind.  We will
                //percolate the call back up the stack so the front end
                //may report it and thus the user can log the error
                //for repair.
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    cmd.Dispose();
                    cmd = null;
                }

                if (da != null)
                {
                    da.Dispose();
                    da = null;
                }
            }
            return results;
        }

        protected override IDbCommand SelectByPkCommand
        {
            get
            {
                IDbCommand cmd;
                IDbDataParameter param;

                cmd = DBConnection.CreateCommand();

                param = (IDbDataParameter)cmd.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "UserId";
                param.Direction = ParameterDirection.Input;
                param.SourceColumn = "USER_ID";
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.DbType = DbType.Decimal;
                param.ParameterName = "locId";
                param.Direction = ParameterDirection.Input;
                param.SourceColumn = "LOC_ID";
                param.DbType = DbType.Decimal;
                cmd.Parameters.Add(param);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_LETTEROFCREDIT.SP_GET_LOC";
                return cmd;
            }
        }


        public DataSet GetLOCHistoryByPk(System.Decimal locId)
        {
            ICustomDataAdapter da = DataAccess.GetCustomDataAdapter();
            DataSet results = new DataSet();  //make sure we use a loosely typed dataset as there will be more columns returned than just from the hedge table

            IDbCommand cmd;
            IDbDataParameter param;

            cmd = SelectHistoryDetailsByPkCommand;
            param = (IDbDataParameter)cmd.Parameters["locId"];
            param.Value = locId;

            param = (IDbDataParameter)cmd.Parameters["UserId"];
            param.Value = CurrentUser;

            try
            {
                da.SelectCommand = cmd;
                da.Fill(results);
            }
            catch (Exception ex)
            {
                //If we get an error opening the result for the stored
                //procedure, we likely have a a farily major problem.  
                //Permissions issues or something of the kind.  We will
                //percolate the call back up the stack so the front end
                //may report it and thus the user can log the error
                //for repair.
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    cmd.Dispose();
                    cmd = null;
                }

                if (da != null)
                {
                    da.Dispose();
                    da = null;
                }
            }

            return results;
        }

        protected IDbCommand SelectHistoryDetailsByPkCommand
        {
            get
            {
                IDbCommand cmd;
                IDbDataParameter param;

                cmd = DBConnection.CreateCommand();

                param = (IDbDataParameter)cmd.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "UserId";
                param.Direction = ParameterDirection.Input;
                param.SourceColumn = "USER_ID";
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.DbType = DbType.Decimal;
                param.ParameterName = "locId";
                param.Direction = ParameterDirection.Input;
                param.SourceColumn = "LOC_ID";
                param.DbType = DbType.Decimal;
                cmd.Parameters.Add(param);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_LETTEROFCREDIT.SP_GET_LOC_HISTORY";
                return cmd;
            }
        }

        public DataSet GetLOCbyRollingExpiry(String expiryfrom, String expiryto)
        {
            ICustomDataAdapter da = DataAccess.GetCustomDataAdapter();
            DataSet results = new DataSet();  //make sure we use a loosely typed dataset as there will be more columns returned than just from the hedge table

            IDbCommand cmd;
            IDbDataParameter param;

            cmd = SelectLOCbyRollingExpiryCommand;
            
            param = (IDbDataParameter)cmd.Parameters["puserid"];
            param.Value = CurrentUser;

            param = (IDbDataParameter)cmd.Parameters["pexpiryfrom"];
            param.Value = expiryfrom;

            param = (IDbDataParameter)cmd.Parameters["pexpiryto"];
            param.Value = expiryto;

            try
            {
                da.SelectCommand = cmd;
                da.Fill(results);
            }
            catch (Exception ex)
            {
                //If we get an error opening the result for the stored
                //procedure, we likely have a a farily major problem.  
                //Permissions issues or something of the kind.  We will
                //percolate the call back up the stack so the front end
                //may report it and thus the user can log the error
                //for repair.
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    cmd.Dispose();
                    cmd = null;
                }

                if (da != null)
                {
                    da.Dispose();
                    da = null;
                }
            }

            return results;
        }

        protected IDbCommand SelectLOCbyRollingExpiryCommand
        {
            get
            {
                IDbCommand cmd;
                IDbDataParameter param;

                cmd = DBConnection.CreateCommand();

                param = (IDbDataParameter)cmd.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "puserid";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.DbType = DbType.Date;
                param.ParameterName = "pexpiryfrom";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = cmd.CreateParameter();
                param.DbType = DbType.Date;
                param.Direction = ParameterDirection.Input;
                param.ParameterName = "pexpiryto";
                cmd.Parameters.Add(param);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_LETTEROFCREDIT.SP_GET_LOC_ROLLING_EXPIRY";
                return cmd;
            }
        }

        public DataSet GetDetailsfromSearch( object lcnumber, object prvlcnumber, object amount, object issuanceFromdate,
                                object expiryFromdate, object amendmentFromdate, object beneficiary, object businessunit,
                                object regiondivision, object department, object leadcontact, object lctype, 
                                object parental, object counter, object counterparty, object creditfacility,
                                object issuanceTodate, object expiryTodate, object amendmentTodate, object currency,object cancelled)
        {
            ICustomDataAdapter da = DataAccess.GetCustomDataAdapter();
            DataSet results = new DataSet();  //make sure we use a loosely typed dataset as there will be more columns returned than just from the hedge table

            IDbCommand cmd;
            IDbDataParameter param;

            cmd = SearchCommand;


            param = (IDbDataParameter)cmd.Parameters["puserId"];
            param.Value = CurrentUser;

            param = (IDbDataParameter)cmd.Parameters["pletterNumber"];
            if (lcnumber != null && lcnumber.ToString() != string.Empty)
                param.Value = AppendPercent(lcnumber.ToString());
            else
                param.Value = System.DBNull.Value;

            param = (IDbDataParameter)cmd.Parameters["pprevLcNumber"];
            if (prvlcnumber != null && prvlcnumber.ToString() != string.Empty)
                param.Value = AppendPercent(prvlcnumber.ToString());
            else
                param.Value = System.DBNull.Value;


            param = (IDbDataParameter)cmd.Parameters["pamount"];
            String aa;
            if (amount != null && amount.ToString() != string.Empty)
            {
                aa = AppendPercent(amount.ToString());
                param.Value = aa.Replace(".00", "");
            }
            else
                param.Value = System.DBNull.Value;

            param = (IDbDataParameter)cmd.Parameters["pissuancefrom"];
            if (issuanceFromdate != null)
                param.Value = issuanceFromdate;
            else
                param.Value = DBNull.Value;

            param = (IDbDataParameter)cmd.Parameters["pexpiryfrom"];
            if (expiryFromdate != null)
                param.Value = expiryFromdate;
            else
                param.Value = DBNull.Value;            

            param = (IDbDataParameter)cmd.Parameters["pamendmentfrom"];
            if (amendmentFromdate != null)
                param.Value = amendmentFromdate;
            else
                param.Value = DBNull.Value;            

            param = (IDbDataParameter)cmd.Parameters["pbeneficiary"];
            if (beneficiary != null && beneficiary.ToString() != string.Empty)
                param.Value = AppendPercent(beneficiary.ToString());
            else
                param.Value = System.DBNull.Value;

            param = (IDbDataParameter)cmd.Parameters["pbunitId"];
            if (businessunit != null && businessunit.ToString() != string.Empty)
                param.Value = businessunit.ToString();
            else
                param.Value = System.DBNull.Value;


            param = (IDbDataParameter)cmd.Parameters["pdivision"];
            if (regiondivision != null)
                param.Value = regiondivision;
            else
                param.Value = System.DBNull.Value;

            param = (IDbDataParameter)cmd.Parameters["pdepartment"];
            if (department != null && department.ToString() != string.Empty)
                param.Value = AppendPercent(department.ToString());
            else
                param.Value = System.DBNull.Value;


            param = (IDbDataParameter)cmd.Parameters["pleadContact"];
            if (leadcontact != null && leadcontact.ToString() != string.Empty)
                param.Value = AppendPercent(leadcontact.ToString());
            else
                param.Value = System.DBNull.Value;

            param = (IDbDataParameter)cmd.Parameters["plcType"];
            if (lctype != null && lctype.ToString() != string.Empty)
                param.Value = lctype.ToString();
            else
                param.Value = System.DBNull.Value;

            param = (IDbDataParameter)cmd.Parameters["pcounterguarantee"];
            if (counter != null && counter.ToString() != string.Empty)
                param.Value = AppendPercent(counter.ToString());
            else
                param.Value = System.DBNull.Value;


            param = (IDbDataParameter)cmd.Parameters["pparentalguarantee"];
            if (parental != null && parental.ToString() != string.Empty)
                param.Value = AppendPercent(parental.ToString());
            else
                param.Value = System.DBNull.Value;


            param = (IDbDataParameter)cmd.Parameters["pcpty"];
            if (counterparty != null && counterparty.ToString() != string.Empty)
                param.Value = counterparty.ToString();
            else
                param.Value = System.DBNull.Value;


            param = (IDbDataParameter)cmd.Parameters["pcreditline"];
            if (creditfacility != null && creditfacility.ToString() != string.Empty)
                param.Value = creditfacility.ToString();
            else
                param.Value = System.DBNull.Value;

            param = (IDbDataParameter)cmd.Parameters["pissuanceto"];
            if (issuanceTodate != null)
                param.Value = issuanceTodate;
            else
                param.Value = DBNull.Value;

            param = (IDbDataParameter)cmd.Parameters["pexpiryto"];
            if (expiryTodate != null)
                param.Value = expiryTodate;
            else
                param.Value = DBNull.Value;

            param = (IDbDataParameter)cmd.Parameters["pamendmentto"];
            if (amendmentTodate != null)
                param.Value = amendmentTodate;
            else
                param.Value = DBNull.Value;

            param = (IDbDataParameter)cmd.Parameters["pcurrency"];
            if (currency != null && currency.ToString() != string.Empty)
                param.Value = currency.ToString();
            else
                param.Value = System.DBNull.Value;

            param = (IDbDataParameter)cmd.Parameters["pcancelled"];
            if (cancelled != null && cancelled.ToString() != string.Empty)
                param.Value = cancelled.ToString();
            else
                param.Value = System.DBNull.Value;
          

            try
            {
                da.SelectCommand = cmd;
                da.Fill(results);
            }
            catch (Exception ex)
            {
                //If we get an error opening the result for the stored
                //procedure, we likely have a a farily major problem.  
                //Permissions issues or something of the kind.  We will
                //percolate the call back up the stack so the front end
                //may report it and thus the user can log the error
                //for repair.
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    cmd.Dispose();
                    cmd = null;
                }

                if (da != null)
                {
                    da.Dispose();
                    da = null;
                }
            }

            return results;
        }

        public DataSet GetDetailsByCreditFacility(object effectivedate, object creditfacility)
        {
            ICustomDataAdapter da = DataAccess.GetCustomDataAdapter();
            DataSet results = new DataSet();  //make sure we use a loosely typed dataset as there will be more columns returned than just from the hedge table

            IDbCommand cmd;
            IDbDataParameter param;

            cmd = SearchLCByCreditLine;


            param = (IDbDataParameter)cmd.Parameters["puserId"];
            param.Value = CurrentUser;

            param = (IDbDataParameter)cmd.Parameters["peffectivedate"];
            if (effectivedate != null)
                param.Value = effectivedate;
            else
                param.Value = DBNull.Value;

            param = (IDbDataParameter)cmd.Parameters["pcreditline"];
            if (creditfacility != null && creditfacility.ToString() != string.Empty)
                param.Value = creditfacility.ToString();
            else
                param.Value = System.DBNull.Value;
            try
            {
                da.SelectCommand = cmd;
                da.Fill(results);
            }
            catch (Exception ex)
            {
                //If we get an error opening the result for the stored
                //procedure, we likely have a a farily major problem.  
                //Permissions issues or something of the kind.  We will
                //percolate the call back up the stack so the front end
                //may report it and thus the user can log the error
                //for repair.
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    cmd.Dispose();
                    cmd = null;
                }

                if (da != null)
                {
                    da.Dispose();
                    da = null;
                }
            }

            return results;
        }

        protected IDbCommand SearchCommand
        {
            get
            {
                IDbDataParameter param;
                IDbCommand cmd;

                cmd = DBConnection.CreateCommand();
                
                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "puserId";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pletterNumber";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pprevLcNumber";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pamount";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pissuancefrom";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.Date;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pexpiryfrom";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.Date;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pamendmentfrom";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.Date;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pbeneficiary";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pbunitId";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pdivision";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.Decimal;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pdepartment";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pleadContact";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "plcType";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pcounterguarantee";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pparentalguarantee";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pcpty";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pcreditline";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pissuanceto";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.Date;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pexpiryto";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.Date;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pamendmentto";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.Date;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pcurrency";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pcancelled";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_LETTEROFCREDIT.LOC_SEARCH";

                return cmd;
            }
        }

        protected IDbCommand SearchLCByCreditLine
        {
            get
            {
                IDbDataParameter param;
                IDbCommand cmd;

                cmd = DBConnection.CreateCommand();

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "puserId";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "peffectivedate";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.Date;
                cmd.Parameters.Add(param);

                param = (IDbDataParameter)cmd.CreateParameter();
                param.ParameterName = "pcreditline";
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_LETTEROFCREDIT.LOC_SEARCH_BY_CREDITLINE";

                return cmd;
            }
        }

        protected string AppendPercent(string searchString)
        {
            //if (searchString.IndexOf("*") != -1)
            //    return " LIKE " + "'" + searchString.Replace("*", "%").ToUpper() + "'";
            //else
            //    return " = " + "'" + searchString.ToUpper() + "'";

            if (searchString.Length > 0)
                searchString = "%" + searchString + "%";
            else
                searchString = System.DBNull.Value.ToString() ;
                

            
            return searchString;
        }

        
    }
}
