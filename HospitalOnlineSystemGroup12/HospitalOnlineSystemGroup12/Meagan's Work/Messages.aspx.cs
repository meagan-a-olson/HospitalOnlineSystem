using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace HospitalOnlineSystemGroup12.Meagan_s_Work
{
    public partial class Messages : System.Web.UI.Page
    {
        HospitalDBEntities dbcon = new HospitalDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Session["LoginName"].ToString();
            MessagesGridView.DataSource = getMessages(username);
        }

        private List<MessagesTable> getMessages(string username)
        {
            List<MessagesTable> result = new List<MessagesTable>();
            foreach(MessagesTable m in dbcon.MessagesTables)
            {
                if (m.MessageTO == username)
                {
                    result.Add(m);
                }
            }
            return result;
        }
    }
}