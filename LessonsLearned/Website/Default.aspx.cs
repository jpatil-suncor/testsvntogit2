using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PetroCanada.CorpExec.WebControls;
using PetroCanada.CorpExec.Security;
using Backend.Maintenance;
using Backend;

namespace Website
{
    public partial class _Default : SecurityWebPageBase
    {
        protected System.Data.DataView dvSBU;
        protected System.Data.DataView dvBU;
        protected System.Data.DataView dvFrequency;
        protected System.Data.DataView dvImpact;
        protected System.Data.DataView dvType;
        protected System.Data.DataView dvProject;

        protected void Page_Load(object sender, EventArgs e)
        {
            UseNTLogin();
            //this.lblTitle.Text = ConfigurationManager.AppSettings["TitleMSG"].ToString();
            
        }

        protected override void OnInit(EventArgs e)
        {
            InitializeComponent();
            //base.OnInit(e);
        }

        private void InitializeComponent()
        {
            
            //this.imgInput.Attributes.Add("onmouseover", "showPopup('input', event);");
            //this.imgInput.Attributes.Add("onmouseout", "hideCurrentPopup();");
            //this.imgCentral.Attributes.Add("onmouseover", "showPopup('central', event);");
            //this.imgCentral.Attributes.Add("onmouseout", "hideCurrentPopup();");
            //this.imgOutput.Attributes.Add("onmouseover", "showPopup('output', event);");
            //this.imgOutput.Attributes.Add("onmouseout", "hideCurrentPopup();");
        }

        private void UseNTLogin()
        {
            PetroCanada.CorpExec.Security.Account acct = UserAccountSecurity;
            string authResult = string.Empty;
            string ntUser = string.Empty;
            string LANID = string.Empty;
            ntUser = this.Request.LogonUserIdentity.Name;
            
           

            try
            {
                LANID = ntUser.Substring(ntUser.IndexOf("\\") + 1);
                PopulateName();
           
                //if (acct.AccountSuspended(LANID))
                //{
                //    //User is suspended - let them know.
                //    //ValidationSummary1.AddErrorMessage("Your account has been suspended.  Please contact your security administrator for details.");
                //    authResult = LogActions.LogonSuspended;
                //}
                //else
                //{
                //    //Add the user name to the session variables
                //    Session.Add(Global.Parameters.User, LANID);

                //    authResult = LogActions.Logon;

                //    //else accept user as authenticated	and redirect to login page
                //    FormsAuthentication.RedirectFromLoginPage(this.LoginName, false);

                //    //Log user access result.
                //    //AuditAccess aa = new AuditAccess();
                //    //aa.UserLogin = LANID;
                //    //aa.Action = authResult;
                //    //aa.UserHostName = Request.UserHostName;
                //    //aa.Save();

                //}
            }
            catch (Exception ex)
            {
                throw new Backend.LLException("UseNTLogin: ntUser[" + ntUser + "]ex.Message[" + ex.Message + "]", ex);
            }

        }

        private void PopulateName()
        {
            string ntUser = string.Empty;
            try
            {
                
                string LANID = string.Empty;
                ntUser = this.Request.LogonUserIdentity.Name;

                LANID = ntUser.Substring(ntUser.IndexOf("\\") + 1);
               
                if (LANID != "")
                {
                    Session.Add(Global.Parameters.User, LANID);
                    // Retrieve First and Last name of user
                    User user = new User();
                    user.GetByPk(LANID);

                    if (user.FirstName.ToString() != "")
                    {
                        lblWelcome.Text = "Welcome " + user.FirstName.ToString() + " " + user.LastName.ToString();
                    }
                    else
                    {
                        lblWelcome.Text = "Welcome " + LANID.ToString();
                    }

                    if (user.LLCoordinator.ToString() != "")
                    {
                        Session.Add(Global.Parameters.LL_Coordinator, user.LLCoordinator.ToString());
                    }
                    else
                    {
                        Session.Add(Global.Parameters.LL_Coordinator, "");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Backend.LLException("Populate Name: ntUser[" + ntUser + "]ex.Message[" + ex.Message + "]", ex);
            }

        }
           
       
    }
}
