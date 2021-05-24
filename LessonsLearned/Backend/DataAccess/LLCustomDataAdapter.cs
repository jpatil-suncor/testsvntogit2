using System;
using System.Data;
using System.Data.OleDb;
using PetroCanada.CorpExec.DataAccess;

namespace Backend.DataAccess
{
    /// <summary>
    /// This classes simply wraps and exposes only basic OleDbDataAdapter
    /// functionality. Microsoft provided a common interface for all data
    /// adapters, but not a common interface for traditional relational database
    /// data adapters (no select, insert, update and delete commands on the generic
    /// interface)  Being that one of the design goals was to provide 
    /// for simple data provider transitions to the Oracle Native .Net provider when
    /// available, we are wraping the adapter, so we can access the underlying
    /// adapter polymorphically with in the code.  This way when we change 
    /// managed data providers we simply will need to change the logic that 
    /// returns the instanciated class who implments the ICustomDataAdapter 
    /// interface and wraps the appropriate data adapter.  The underlying code
    /// will access the data adapter through our custom interface, polymorphically.
    /// THIS CODE TAKEN FROM THE SMART APP Aug 8, 2007
    /// </summary>
    public class LLCustomDataAdapter : ICustomDataAdapter
    {
        #region Private Fields
        private OleDbDataAdapter m_dataAdapter = new OleDbDataAdapter();
        #endregion

        #region Public Properties
        public IDbCommand SelectCommand
        {
            get
            {
                return m_dataAdapter.SelectCommand;
            }
            set
            {
                if (value != null)
                {
                    m_dataAdapter.SelectCommand = (OleDbCommand)value;
                }
            }
        }

        public IDbCommand DeleteCommand
        {
            get
            {
                return m_dataAdapter.DeleteCommand;
            }
            set
            {
                m_dataAdapter.DeleteCommand = (OleDbCommand)value;
            }
        }

        public IDbCommand InsertCommand
        {
            get
            {
                return m_dataAdapter.InsertCommand;
            }
            set
            {
                m_dataAdapter.InsertCommand = (OleDbCommand)value;
            }
        }

        public IDbCommand UpdateCommand
        {
            get
            {
                return m_dataAdapter.UpdateCommand;
            }
            set
            {
                m_dataAdapter.UpdateCommand = (OleDbCommand)value;
            }
        }
        #endregion

        #region Private Methods
        private void ValidateSelectCommand()
        {
            if (m_dataAdapter != null)
            {
                if (m_dataAdapter.SelectCommand == null)
                {
                    ApplicationException ex = new ApplicationException("Null Select Command, unable to perform operation");
                    throw ex;
                }
            }
            else
            {
                ApplicationException ex = new ApplicationException("Underlying Data Adapter is null");
                throw ex;
            }

        }

        private void ValidateInsertCommand()
        {
            if (m_dataAdapter != null)
            {
                if (m_dataAdapter.InsertCommand == null)
                {
                    ApplicationException ex = new ApplicationException("Null Insert Command, unable to perform operation");
                    throw ex;
                }
            }
            else
            {
                ApplicationException ex = new ApplicationException("Underlying Data Adapter is null");
                throw ex;
            }
        }

        private void ValidateDeleteCommand()
        {
            if (m_dataAdapter != null)
            {
                if (m_dataAdapter.DeleteCommand == null)
                {
                    ApplicationException ex = new ApplicationException("Null Delete Command, unable to perform operation");
                    throw ex;
                }
            }
            else
            {
                ApplicationException ex = new ApplicationException("Underlying Data Adapter is null");
                throw ex;
            }

        }

        private void ValidateUpdateCommand()
        {
            if (m_dataAdapter != null)
            {
                if (m_dataAdapter.UpdateCommand == null)
                {
                    ApplicationException ex = new ApplicationException("Null Update Command, unable to perform operation");
                    throw ex;
                }
            }
            else
            {
                ApplicationException ex = new ApplicationException("Underlying Data Adapter is null");
                throw ex;
            }

        }

        private void ValidateCommands()
        {
            ValidateSelectCommand();
            ValidateInsertCommand();
            ValidateUpdateCommand();
            ValidateDeleteCommand();
        }
        #endregion

        #region Public Methods
        public LLCustomDataAdapter()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Fill(DataSet ds)
        {
            //If we have an invalid command an exception 
            //is raised which will won't catch so that our
            //calling function may.
            ValidateSelectCommand();

            return m_dataAdapter.Fill(ds);
        }

        public int Fill(DataTable dt)
        {
            //If we have an invalid command an exception 
            //is raised which will won't catch so that our
            //calling function may.
            ValidateSelectCommand();

            return m_dataAdapter.Fill(dt);
        }

        public int Fill(DataSet ds, string tableName)
        {
            //If we have an invalid command an exception 
            //is raised which will won't catch so that our
            //calling function may.
            ValidateSelectCommand();

            return m_dataAdapter.Fill(ds, tableName);
        }

        public int Update(DataSet ds)
        {
            //If we have an invalid command an exception 
            //is raised which will won't catch so that our
            //calling function may.
            ValidateCommands();

            return m_dataAdapter.Update(ds);
        }

        public int Update(DataTable dt)
        {
            //If we have an invalid command an exception 
            //is raised which will won't catch so that our
            //calling function may.
            ValidateCommands();

            return m_dataAdapter.Update(dt);
        }

        public int Update(DataRow[] dr)
        {
            //If we have an invalid command an exception 
            //is raised which will won't catch so that our
            //calling function may.
            ValidateCommands();

            return m_dataAdapter.Update(dr);
        }

        public int Update(DataSet ds, string tableName)
        {
            //If we have an invalid command an exception 
            //is raised which will won't catch so that our
            //calling function may.
            ValidateCommands();

            return m_dataAdapter.Update(ds, tableName);
        }

        public void Dispose()
        {
            if (m_dataAdapter != null)
                m_dataAdapter.Dispose();
        }
        #endregion

    }
}
