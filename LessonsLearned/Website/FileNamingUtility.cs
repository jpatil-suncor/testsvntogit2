using System;
using System.Collections;
using System.Web.SessionState;
using System.IO;
using System.Configuration;

namespace Website
{
    /// <summary>
    /// Summary description for FileNamingUtility.
    /// </summary>
    public class FileNamingUtility
    {
        private static string SessionFileKey = "SessionFileNames";

        private static ArrayList FileArrayList(HttpSessionState session)
        {
            ArrayList files = null;

            //If the arraylist exists in the session object then retrieve it
            try
            {
                files = (ArrayList)session[SessionFileKey];
                //If it is null then create it
                if (files == null) files = new ArrayList();
            }
            catch //The session object doesn't exist yet so create a new arraylist
            {
                files = new ArrayList();
            }

            return files;
        }

        public FileNamingUtility()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void AddFileToSessionList(HttpSessionState session, string absolutePathFileName)
        {
            ArrayList files = FileArrayList(session);

            files.Add(absolutePathFileName);
            session[SessionFileKey] = files;
        }

        public static string GetTempExcelFileName()
        {
            return Guid.NewGuid().ToString() + ".xls";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="absolutePathFilename"></param>
        /// <param name="relativePathFilename"></param>
        /// <param name="tmpFileName"></param>
        //		private static void GetFilePathsAndRegisterToSession(HttpSessionState session, ref string absolutePathFilename, ref string relativePathFilename, string tmpFileName)
        //		{
        //			absolutePathFilename =  ConfigurationSettings.AppSettings["ReportPathAbsolute"].ToString() 
        //				+ tmpFileName;
        //			relativePathFilename = ConfigurationSettings.AppSettings["ReportPathRelative"].ToString()
        //				+ tmpFileName;
        //			
        //			//Add the absolute path filename to the arraylist in the session object so it can
        //			//be deleted when the session ends
        //			ArrayList files;
        //
        //			files = FileArrayList(session);
        //
        //			//Add the file to the array and store it in the session object
        //			files.Add(absolutePathFilename);
        //			session[SessionFileKey] = files;
        //		}

        public static void GetCsvFileName(HttpSessionState session, ref string absolutePathFilename, ref string relativePathFilename)
        {
            string newFileName = System.IO.Path.GetTempFileName();
            //string newFileName = GetTempFileName();


            //string filePath = newFileName.Substring(0,newFileName.Length - 4);

            //absolutePathFilename = filePath + ".csv";
            absolutePathFilename = newFileName;
            if (absolutePathFilename.Length <= 4)
            {
                relativePathFilename = string.Empty;
                absolutePathFilename = string.Empty;
            }
            else
            {
                //rpp relativePathFilename = Path.GetDirectoryName(absolutePathFilename);
                string relativefilename = ConfigurationManager.AppSettings["webfilename"];
                string filename = Path.GetFileName(newFileName);
                relativePathFilename = relativefilename + filename;
            }
        }

        public static void GetTxtFileName(ref string absolutePathFilename, ref string relativePathFilename)
        {
            string newFileName = System.IO.Path.GetTempFileName();
            string filePath = newFileName.Substring(0, newFileName.Length - 4);

            absolutePathFilename = filePath + ".txt";
            if (absolutePathFilename.Length <= 4)
            {
                //fileName = string.Empty;
                relativePathFilename = string.Empty;
                absolutePathFilename = string.Empty;
            }
            else
            {
                //fileName = Path.GetFileName(absolutePathFilename);
                relativePathFilename = Path.GetDirectoryName(absolutePathFilename);
            }
        }

        public static void GetAcrobatFilename(HttpSessionState session, ref string absolutePathFilename, ref string relativePathFilename)
        {
            string newFileName = System.IO.Path.GetTempFileName();
            //string newFileName = GetTempFileName();
            //string filePath = newFileName.Substring(0,newFileName.Length - 4);

            //absolutePathFilename = filePath + ".pdf";
            absolutePathFilename = newFileName;
            if (absolutePathFilename.Length <= 4)
            {
                relativePathFilename = string.Empty;
                absolutePathFilename = string.Empty;
            }
            else
            {
                relativePathFilename = Path.GetDirectoryName(absolutePathFilename);
            }
        }

        public static void GetExcelFilename(HttpSessionState session, ref string absolutePathFilename, ref string relativePathFilename)
        {
            string newFileName = System.IO.Path.GetTempFileName();
            //string filePath = newFileName.Substring(0,newFileName.Length - 4);

            //absolutePathFilename = filePath + ".xls";
            absolutePathFilename = newFileName;
            if (absolutePathFilename.Length <= 4)
            {
                relativePathFilename = string.Empty;
                absolutePathFilename = string.Empty;
            }
            else
            {
                relativePathFilename = Path.GetDirectoryName(absolutePathFilename);
            }
        }

        public static string GetTempFileName()
        {
            string tempfilepathname = Path.GetTempFileName();
            string absolutefilename = ConfigurationManager.AppSettings["absolutefilename"];
            string filename = Path.GetFileName(tempfilepathname);
            string filepathname = absolutefilename + filename;
            File.Copy(tempfilepathname, filepathname, true);

            return filepathname;
        }

        /// <summary>
        /// Deletes all of the acrobat files in the report path that were
        /// created in this session
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public static bool DeleteSessionFiles(HttpSessionState session)
        {
            bool success = true;

            ArrayList files;

            //If the arraylist exists in the session object then retrieve it
            try
            {
                files = (ArrayList)session[SessionFileKey];
            }
            catch (Exception) //The session object doesn't exist so there is nothing to delete
            {
                return success;
            }

            foreach (object filename in files)
            {
                try
                {
                    File.Delete(filename.ToString());
                }
                catch (Exception)
                {
                    //If a file fails to delete we will return appropriate flag
                    //(but there is probably not much we can do about it except
                    //log it in a file if we decide to keep track of it)
                    success = false;
                }
            }

            return success;
        }

        /// <summary>
        /// Deletes all of the acrobat files in the directory specified by reportpath  
        /// </summary>

    }
}
