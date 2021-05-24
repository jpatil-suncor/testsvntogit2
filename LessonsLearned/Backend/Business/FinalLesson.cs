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
    public class FinalLesson : LLBusinessObjectBase
    {
        public FinalLesson()
        {
            m_dataTableName = "LL_LEARNED";
        }

        private object m_llId              = DBNull.Value;
        private object m_learnedstatusId   = DBNull.Value;
        private object m_keywords          = DBNull.Value;
        private object m_sbuids            = DBNull.Value;
        private object m_buids             = DBNull.Value;
        private object m_projectIds        = DBNull.Value;
        private object m_processids        = DBNull.Value;
        private object m_disciplineIds     = DBNull.Value;
        private object m_categoryIds       = DBNull.Value;
        private object m_stageIds          = DBNull.Value;
        private object m_procedurechange   = DBNull.Value;
        private object m_bulletinsent      = DBNull.Value;  
        private object m_createdby         = DBNull.Value;
        private object m_createddate       = DBNull.Value;
        private object m_lastChangedBy     = DBNull.Value;
        private object m_lastChangedDate   = DBNull.Value;

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

        public object LearnedStatusId
        {
            get
            {
                return m_learnedstatusId;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Learned Status Id ", ex);
                    throw newEx;
                }

                m_learnedstatusId = value;
            }
        }

        public object KeyWords
        {
            get
            {
                return m_keywords;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Key words ", ex);
                    throw newEx;
                }

                m_keywords = value;
            }        
        }

        public object SBUIds
        {
            get
            {
                return m_sbuids;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Project Id ", ex);
                    throw newEx;
                }

                m_sbuids = value;
            }
        }

        public object BUIds
        {
            get
            {
                return m_buids;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Project Id ", ex);
                    throw newEx;
                }

                m_buids = value;
            }
        }

        public object ProjectIds
        {
            get
            {
                return m_projectIds;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Project Ids ", ex);
                    throw newEx;
                }

                m_projectIds = value;
            }
        }

        public object ProcessIds
        {
            get
            {
                return m_processids;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Process Id ", ex);
                    throw newEx;
                }

                m_processids = value;
            }
        }

        public object DisciplineIds
        {
            get
            {
                return m_disciplineIds;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Discipline Ids ", ex);
                    throw newEx;
                }

                m_disciplineIds = value;
            }
        }

        public object CategoryIds
        {
            get
            {
                return m_categoryIds;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Category Ids ", ex);
                    throw newEx;
                }

                m_categoryIds = value;
            }
        }

        public object StageIds
        {
            get
            {
                return m_stageIds;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Stage Ids ", ex);
                    throw newEx;
                }

                m_stageIds = value;
            }
        }
        
        public object ProcedureChange
        {
            get
            {
                return m_procedurechange;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Procedure Change ", ex);
                    throw newEx;
                }
                m_procedurechange = value;
            }
        }

        public object BulletinSent
        {
            get
            {
                return m_bulletinsent;
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
                    System.InvalidCastException newEx = new InvalidCastException("Unable to perform cast on property: " + "Bulletin Sent ", ex);
                    throw newEx;
                }
                m_bulletinsent = value;
            }
        }

        
        public override void Save()
        {
                      
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
         
        }

       

        protected override IDbCommand InsertCommand
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
                IDbCommand cmd;
               
                cmd = DBConnection.CreateCommand();

               
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

    
        public DataSet GetDetailsByPk(System.Decimal locId)
        {
            ICustomDataAdapter da = DataAccess.GetCustomDataAdapter();
            DataSet results = new DataSet();  //make sure we use a loosely typed dataset as there will be more columns returned than just from the hedge table

            return results;
        }

        public DataSet SearchLessonsLearned()
        { 
            ICustomDataAdapter da = DataAccess.GetCustomDataAdapter();
            DataSet results = new DataSet();  //make sure we use a loosely typed dataset as there will be more columns returned than just from the hedge table

            IDbCommand cmd;
            cmd = DBConnection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LL_LEARNED_PKG.SEARCH_RECORD";

            CreateParameter(ref cmd, "userId", ParameterDirection.Input, DbType.String, "USER_ID");
            CreateParameter(ref cmd, "pkeywords", ParameterDirection.Input, DbType.String, "KEY_WORDS");
            CreateParameter(ref cmd, "psbuids", ParameterDirection.Input, DbType.String, "SBU_IDS");
            CreateParameter(ref cmd, "pbuids", ParameterDirection.Input, DbType.String, "BU_IDS");
            CreateParameter(ref cmd, "pprojectids", ParameterDirection.Input, DbType.String, "PROJECT_IDS");
            CreateParameter(ref cmd, "pprocessids", ParameterDirection.Input, DbType.String, "PROCESS_IDS");
            CreateParameter(ref cmd, "pdisciplineids", ParameterDirection.Input, DbType.String, "DISCIPLINE_IDS");
            CreateParameter(ref cmd, "pstageids", ParameterDirection.Input, DbType.String, "STAGE_IDS");
            CreateParameter(ref cmd, "pcategoryids", ParameterDirection.Input, DbType.String, "CATEGORY_IDS");

            ((IDbDataParameter)cmd.Parameters["userId"]).Value          = CurrentUser;
            ((IDbDataParameter)cmd.Parameters["pkeywords"]).Value       = KeyWords.ToString();
            ((IDbDataParameter)cmd.Parameters["psbuids"]).Value         = SBUIds.ToString();
            ((IDbDataParameter)cmd.Parameters["pbuids"]).Value          = BUIds.ToString();
            ((IDbDataParameter)cmd.Parameters["pprojectids"]).Value     = ProjectIds.ToString();
            ((IDbDataParameter)cmd.Parameters["pprocessids"]).Value     = ProcessIds.ToString();
            ((IDbDataParameter)cmd.Parameters["pdisciplineids"]).Value  = DisciplineIds.ToString();
            ((IDbDataParameter)cmd.Parameters["pstageids"]).Value       = StageIds.ToString();
            ((IDbDataParameter)cmd.Parameters["pcategoryids"]).Value    = CategoryIds.ToString();

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
              
                return cmd;
            }
        }


       


        protected IDbCommand SearchCommand
        {
            get
            {
                IDbCommand cmd;

                cmd = DBConnection.CreateCommand();
               

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

