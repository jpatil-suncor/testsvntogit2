using System;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Web;
using System.Web.SessionState;
using Microsoft.ApplicationBlocks.ExceptionManagement;
//using Website;

namespace Backend
{
  [Serializable]
  public class LLException : BaseApplicationException
  {
    // Default constructor
    public LLException() : base()
    {
    }

    // Constructor with exception message
    public LLException(string message) : base(message)
    {
        NameValueCollection additionalInfo = new NameValueCollection();
        additionalInfo.Add("Message", message);
        if (HttpContext.Current != null)
        {
            try
            {
                additionalInfo.Add("Timestamp", DateTime.Now.ToString());
                if (HttpContext.Current.Session != null && HttpContext.Current.Session.Keys != null && HttpContext.Current.Session.Keys.Count > 0)
                {
                    additionalInfo.Add("*************Session Variables follow*************", "");
                    for (int i = 0; i < HttpContext.Current.Session.Keys.Count; i++)
                    {
                        String key = HttpContext.Current.Session.Keys[i].ToString();
                        additionalInfo.Add(key, HttpContext.Current.Session[key].ToString());
                    }
                    additionalInfo.Add("*************Session Variables done*************", "");
                }

                if (HttpContext.Current.Request != null && HttpContext.Current.Request.ServerVariables.Keys != null && HttpContext.Current.Request.ServerVariables.Keys.Count > 0)
                {
                    additionalInfo.Add("*************Request.ServerVariables follow*************", "");
                    for (int i = 0; i < HttpContext.Current.Request.ServerVariables.Keys.Count; i++)
                    {
                        String key = HttpContext.Current.Request.ServerVariables.Keys[i].ToString();
                        additionalInfo.Add(key, HttpContext.Current.Request.ServerVariables[key].ToString());
                    }
                    additionalInfo.Add("*************Request.ServerVariables done*************", "");
                }

                Mailer.AlertException(additionalInfo, "");
            }
            catch (Exception ignore)
            {
                String tmp = ignore.Message;
            }
        }
    }

    // Constructor with message and inner exception
    public LLException(string message, Exception inner) : base(message,inner)
    {
      NameValueCollection additionalInfo = new NameValueCollection();
      additionalInfo.Add("Message", message);
      if (HttpContext.Current !=null)
      {
        try
        {
            additionalInfo.Add("Timestamp", DateTime.Now.ToString());
            if (HttpContext.Current.Session != null && HttpContext.Current.Session.Keys != null && HttpContext.Current.Session.Keys.Count > 0)
            {
                additionalInfo.Add("*************Session Variables follow*************", "");
                for (int i = 0; i < HttpContext.Current.Session.Keys.Count; i++)
                {
                    String key = HttpContext.Current.Session.Keys[i].ToString();
                    additionalInfo.Add(key, HttpContext.Current.Session[key].ToString());
                }
                additionalInfo.Add("*************Session Variables done*************", "");
            }

            if (HttpContext.Current.Request != null && HttpContext.Current.Request.ServerVariables.Keys != null && HttpContext.Current.Request.ServerVariables.Keys.Count > 0)
            {
                additionalInfo.Add("*************Request.ServerVariables follow*************", "");
                for (int i = 0; i < HttpContext.Current.Request.ServerVariables.Keys.Count; i++)
                {
                    String key = HttpContext.Current.Request.ServerVariables.Keys[i].ToString();
                    additionalInfo.Add(key, HttpContext.Current.Request.ServerVariables[key].ToString());
                }
                additionalInfo.Add("*************Request.ServerVariables done*************", "");
            }

            Mailer.AlertException(additionalInfo, inner.StackTrace);
        }
        catch(Exception ignore)
        {
            String tmp = ignore.Message;
        }
      }
//      ExceptionManager.Publish(this, additionalInfo);

    }

    // Protected constructor to de-serialize data
    protected LLException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }
}