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
            if(!IsPostBack)
            {
                loadMessages(Session["LoginName"].ToString());
            }
            ViewMessageTextBox.Visible = false;
            InstructionsLabel.Visible = false;
        }

        //Function to clear and reload Inbox and Sent GridViews
        private void loadMessages(string username)
        {
            //Clear gridboxes and add messages to lists
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

            //Set data sources and keys
            InboxGridView.DataSource = inbox;
            InboxGridView.DataKeyNames = new string[1] { "MessageID" };
            InboxGridView.DataBind();
            SentGridView.DataSource = sent;
            SentGridView.DataKeyNames = new string[1] { "MessageID" };
            SentGridView.DataBind();

            //handle empty message labels
            string emptyMessage = "You have no messages to display.";
            if(InboxGridView.Rows.Count == 0)
            {
                EmptyInboxLabel.Visible = true;
                EmptyInboxLabel.Text = emptyMessage;
            }
            else
            {
                EmptyInboxLabel.Visible = false;
            }
            if (SentGridView.Rows.Count == 0)
            {
                EmptySentLabel.Visible = true;
                EmptySentLabel.Text = emptyMessage;
            }
            else
            {
                EmptySentLabel.Visible = false;
            }
        }

        //Sends the given message's info to the ViewMessageTextBox
        public void ViewMessage(int messageID)
        {
            MessagesTable mTable = UtilitiesClass.getMessageByID(messageID);
            CustomMessage mCustom = new CustomMessage(mTable);
            ViewMessageTextBox.Visible = true;
            ViewMessageTextBox.Text = $"From: {mCustom.From}\nTo: {mCustom.To}\nDate: {mTable.Date}\n\n{mTable.Message}";
            if (mTable.MessageTO.Trim().Equals(Session["LoginName"].ToString().Trim()) && mTable.IsRead == 0)
            {
                foreach(MessagesTable m in dbcon.MessagesTables)
                {
                    if (m.MessageID == messageID)
                    {
                        m.IsRead = 1;
                    }
                }
                dbcon.SaveChanges();
                loadMessages(Session["LoginName"].ToString());
            }
        }

        //Class to display MessageTable info in a user-friendly way
        protected class CustomMessage
        {
            private string _from;
            private string _to;
            private System.DateTime _date;
            private string _messagePreview;
            private string _read;
            private int _messageID;

            public CustomMessage(MessagesTable m)
            {
                if (UtilitiesClass.getPatient(m.MessageTO) != null)
                {
                    PatientsTable messageTo = UtilitiesClass.getPatient(m.MessageTO);
                    DoctorsTable messageFrom = UtilitiesClass.getDoctor(m.MessageFROM);
                    this.From = $"{messageFrom.FirstName.Trim()} {messageFrom.LastName.Trim()}";
                    this.To = $"{messageTo.FirstName.Trim()} {messageTo.LastName.Trim()}";
                }
                else
                {
                    DoctorsTable messageTo = UtilitiesClass.getDoctor(m.MessageTO);
                    PatientsTable messageFrom = UtilitiesClass.getPatient(m.MessageFROM);
                    this.From = $"{messageFrom.FirstName.Trim()} {messageFrom.LastName.Trim()}";
                    this.To = $"{messageTo.FirstName.Trim()} {messageTo.LastName.Trim()}";
                }
                this.Date = m.Date;
                this.MessagePreview = Regex.Replace(m.Message.Remove(40), @"\s+", " ");
                //CHECK
                if (m.Message.Length > 40)
                {
                    this.MessagePreview += "...";
                }
                this.Read = Convert.ToInt32(m.IsRead) == 0 ? "Unread" : "";
                this.MessageID = m.MessageID;
            }

            public string From
            {
                get
                {
                    return _from;
                }
                set
                {
                    this._from = value;
                }
            }
            public string To 
            {
                get
                {
                    return _to;
                }
                set
                {
                    this._to = value;
                }
            }
            public System.DateTime Date 
            {
                get
                {
                    return _date;
                }
                set
                {
                    this._date = value;
                }
            }
            public string MessagePreview 
            {
                get
                {
                    return _messagePreview;
                }
                set
                {
                    this._messagePreview = value;
                }
            }
            public string Read 
            {
                get
                {
                    return _read;
                }
                set
                {
                    this._read = value;
                }
            }
            public int MessageID
            {
                get
                {
                    return _messageID;
                }
                set
                {
                    _messageID = value;
                }
            }

        }

        protected void ViewMessageButton_Click(object sender, EventArgs e)
        {
            InstructionsLabel.Visible = false;
            if (!ValidateSelectedMessage()) {
                if (InboxGridView.SelectedRow == null && SentGridView.SelectedRow == null)
                {
                    DisplayInstructions("Please select a message to view.");
                } 
                else if (InboxGridView.SelectedRow != null && SentGridView.SelectedRow != null)
                {
                    DisplayInstructions("Please select only one message to view.");
                    ClearGridViewSelect();
                }
            }
            else
            {
                int messageID = Convert.ToInt32(InboxGridView.SelectedRow == null ? SentGridView.SelectedDataKey.Value : InboxGridView.SelectedDataKey.Value);
                ViewMessage(messageID);
                ClearGridViewSelect();
            }
        }

        //Returns true if the user has selected only one message from the Inbox and Sent gridviews; false if none are selected or more than one are selected
        private bool ValidateSelectedMessage()
        {
            return (InboxGridView.SelectedRow == null ^ SentGridView.SelectedRow == null);
        }

        private void ClearGridViewSelect()
        {
            InboxGridView.SelectedIndex = -1;
            SentGridView.SelectedIndex = -1;
        }

        private void DisplayInstructions(string message)
        {
            InstructionsLabel.Text = message;
            InstructionsLabel.Visible = true;
            InstructionsLabel.ForeColor = System.Drawing.Color.Red;
        }

        protected void DeleteMessageButton_Click(object sender, EventArgs e)
        {
            InstructionsLabel.Visible = false;
            if (!ValidateSelectedMessage())
            {
                if (InboxGridView.SelectedRow == null && SentGridView.SelectedRow == null)
                {
                    DisplayInstructions("Please select a message to delete.");
                }
                else if (InboxGridView.SelectedRow != null && SentGridView.SelectedRow != null)
                {
                    DisplayInstructions("Please select only one message to delete.");
                    ClearGridViewSelect();
                }
            }
            else
            {
                int messageID = Convert.ToInt32(InboxGridView.SelectedRow == null ? SentGridView.SelectedDataKey.Value : InboxGridView.SelectedDataKey.Value);
                foreach (MessagesTable m in dbcon.MessagesTables)
                {
                    if (m.MessageID == messageID)
                    {
                        dbcon.MessagesTables.Remove(m);
                    }
                }
                dbcon.SaveChanges();
                loadMessages(Session["LoginName"].ToString());
            }
        }

        protected void NewMessageButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("NewMessage.aspx", true);
        }
    }
}
