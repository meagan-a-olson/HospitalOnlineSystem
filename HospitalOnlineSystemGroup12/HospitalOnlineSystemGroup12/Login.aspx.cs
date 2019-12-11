using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


namespace HospitalOnlineSystemGroup12
{
    public partial class Login : System.Web.UI.Page
    {
        HospitalDBEntities dbcon = new HospitalDBEntities();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            List<UsersTable> users = dbcon.UsersTables.ToList();    // Creates list of all users

            // Verfies Login information
            foreach (UsersTable user in users)
            {
                if (user.UserLoginName.Trim().Equals(Login1.UserName))
                {
                    if (user.UserLoginPass.Trim().Equals(Login1.Password))
                    {
                        // Transfers needed UserNameLogin and IsDoctor properties to Homepage
                        Session["LoginName"] = user.UserLoginName;
                        Session["IsDoctor"] = user.UserIsDoctor;
                        Server.Transfer("HomePage.aspx", true);
                    }
                        
                }
            }
        }
    }
}