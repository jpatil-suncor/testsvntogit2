using System;
using PetroCanada.CorpExec.DataAccess;

namespace Backend.DataAccess
{
    /// <summary>
    /// Summary description for DataAccessUtil.
    /// </summary>
    public class DataAccessUtil
    {
        public DataAccessUtil()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataAccessConnection GetDataAccessObject()
        {
            return new DataAccessConnection(); 
            //PetroCanada.MRD.SMART.DataAccess.DataAccessConnection();
        }

        public static string ConnectionString
        {
            get
            {
                return DataAccessConnection.ConnectionString;
            }
        }
    }
}
