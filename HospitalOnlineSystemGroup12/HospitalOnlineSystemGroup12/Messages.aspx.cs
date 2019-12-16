using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace HospitalOnlineSystemGroup12.Meagan_s_Work
{
    public partial class Messages : System.Web.UI.Page
    {
        private HospitalDBEntities dbcon = new HospitalDBEntities();
        private List<CustomMessage> inbox = new List<CustomMessage>();
        private List<CustomMessage> sent = new List<CustomMessage>();

        protected void Page_Load(object sender, EventArgs e)
        {
            SendButton.Visible = false;
            loadMessages(Session["LoginName"].ToString());
            loadRecipients(Convert.ToInt32(Session["IsDoctor"]) == 1);
        }

        //Function to clear and reload Inbox and Sent GridViews
        private void loadMessages(string username)
        {
            this.inbox.Clear();
            this.sent.Clear();
            foreach (MessagesTable m in dbcon.MessagesTables)
            {
                if (m.MessageTO == username)
                {
                    this.inbox.Add(new CustomMessage(m));
                }
                else if (m.MessageFROM == username)
                {
                    this.sent.Add(new CustomMessage(m));
                }
            }
            InboxGridView.DataSource = inbox;
            SentGridView.DataSource = sent;
        }

        //Function run at page load to populate recipients drop down list with patients or doctors
        private void loadRecipients(bool isDoctor)
        {
            Dictionary<string, string> recipients = new Dictionary<string, string>();
            if (isDoctor)
            {
                foreach (PatientsTable x in dbcon.PatientsTables)
                {
                    recipients.Add($"{x.FirstName} {x.LastName}", x.UserLoginName);
                }
            }
            else
            {
                foreach (DoctorsTable x in dbcon.DoctorsTables)
                {
                    recipients.Add($"{x.FirstName} {x.LastName}", x.UserLoginName);
                }
            }
            RecipientsDropDownList.DataSource = recipients;
            RecipientsDropDownList.DataTextField = "Value";
            RecipientsDropDownList.DataValueField = "Key";
            RecipientsDropDownList.DataBind();
        }

        //Class to display MessageTable info in a user-friendly way
        protected class CustomMessage
        {
            protected string From;
            protected string To;
            protected System.DateTime Date;
            protected string MessagePreview;
            protected string Read;

            public CustomMessage(MessagesTable m)
            {
                if (UtilitiesClass.getPatient(m.MessageTO) != null)
                {
                    PatientsTable messageTo = UtilitiesClass.getPatient(m.MessageTO);
                    DoctorsTable messageFrom = UtilitiesClass.getDoctor(m.MessageFROM);
                    this.From = $"{messageTo.FirstName} {messageTo.LastName}";
                    this.To = $"{messageTo.FirstName} {messageTo.LastName}";
                }
                else
                {
                    DoctorsTable messageTo = UtilitiesClass.getDoctor(m.MessageTO);
                    PatientsTable messageFrom = UtilitiesClass.getPatient(m.MessageFROM);
                    this.From = $"{messageTo.FirstName} {messageTo.LastName}";
                    this.To = $"{messageTo.FirstName} {messageTo.LastName}";
                }
                this.Date = m.Date;
                this.MessagePreview = $"{Regex.Replace(m.Message.Remove(10), @"\s+", " ")}...";
                this.Read = Convert.ToInt32(m.IsRead) == 0 ? "Unread" : "";
            }
        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            //create new MessagesTable object
            MessagesTable newMessage = new MessagesTable();
            newMessage.MessageFROM = Session["LoginName"].ToString();
            newMessage.MessageTO = RecipientsDropDownList.SelectedValue;
            newMessage.Date = new DateTime();
            newMessage.Message = MessageListBox.Text;

            //update database
            dbcon.MessagesTables.Add(newMessage);
            dbcon.SaveChanges();

            //clear fields and reload tables
            RecipientsDropDownList.ClearSelection();
            MessageListBox.Text = "";
            loadMessages(Session["LoginName"].ToString());
        }

        protected void RecipientsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SendButton.Visible = true;
        }
    }
}
