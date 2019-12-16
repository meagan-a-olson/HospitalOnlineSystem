using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalOnlineSystemGroup12
{
    public partial class NewMessage : System.Web.UI.Page
    {
        private HospitalDBEntities dbcon = new HospitalDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadRecipients(Convert.ToInt32(Session["IsDoctor"]) == 1);
            }
        }

        //Function run at page load to populate recipients drop down list with patients or doctors
        private void loadRecipients(bool isDoctor)
        {
            Dictionary<string, string> recipients = new Dictionary<string, string>();
            if (isDoctor)
            {
                foreach (PatientsTable x in dbcon.PatientsTables)
                {
                    recipients.Add($"{x.FirstName.Trim()} {x.LastName.Trim()}", x.UserLoginName.Trim());
                }
            }
            else
            {
                foreach (DoctorsTable x in dbcon.DoctorsTables)
                {
                    recipients.Add($"{x.FirstName.Trim()} {x.LastName.Trim()}", x.UserLoginName.Trim());
                }
            }
            RecipientsDropDownList.DataSource = recipients;
            RecipientsDropDownList.DataTextField = "Key";
            RecipientsDropDownList.DataValueField = "Value";
            RecipientsDropDownList.DataBind();
        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            //create new MessagesTable object
            MessagesTable newMessage = new MessagesTable();
            newMessage.MessageFROM = Session["LoginName"].ToString().Trim();
            newMessage.MessageTO = RecipientsDropDownList.SelectedValue;
            newMessage.Date = DateTime.Now;
            newMessage.Message = MessageTextBox.Text;
            newMessage.IsRead = 0;

            //update database
            dbcon.MessagesTables.Add(newMessage);
            dbcon.SaveChanges();

            Server.Transfer("Messages.aspx", true);

        }
    }
}