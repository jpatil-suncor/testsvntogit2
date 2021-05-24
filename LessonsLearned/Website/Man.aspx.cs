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
using Backend.Maintenance;

namespace Website
{
    public partial class Man : LLWebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateName();
        }

        private void PopulateName()
        {

            string ntUser = string.Empty;
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
                    lblWelcome.Text = "Welcome " + LoginName.ToString();
                }
            }
        }
    }
}
