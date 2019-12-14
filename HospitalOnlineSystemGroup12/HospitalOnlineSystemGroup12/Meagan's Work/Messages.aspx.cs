using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace HospitalOnlineSystemGroup12.Meagan_s_Work {
    public partial class Messages : System.Web.UI.Page {
        HospitalDBEntities dbcon = new HospitalDBEntities();

        protected void Page_Load(object sender, EventArgs e) {
            string username = Session["LoginName"].ToString();
            MessagesGridView.DataSource = getMessages(username);
        }

        private List<CustomMessage> getMessages(string username) {
            List<CustomMessage> result = new List<CustomMessage>();
            foreach(MessagesTable m in dbcon.MessagesTables) {
                if (m.MessageTO == username || m.MessageFROM == username) {
                    result.Add(new CustomMessage(m));
                }
            }
            return result;
        }
        
        protected class CustomMessage {
            protected string From;
            protected string To;
            protected System.DateTime Date;
            protected string MessagePreview;
            protected string Read;

            public  CustomMessage(MessagesTable m) {
                if (UtilitiesClass.getPatient(m.MessageTO) != null) {
                    PatientsTable messageTo = UtilitiesClass.getPatient(m.MessageTO);
                    DoctorsTable messageFrom = UtilitiesClass.getDoctor(m.MessageFROM);
                    this.From = $"{messageTo.FirstName} {messageTo.LastName}";
                    this.To = $"{messageTo.FirstName} {messageTo.LastName}";
                } else {
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
    }
}