using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalOnlineSystemGroup12
{
    public partial class PatientSearch : System.Web.UI.Page
    {
        HospitalDBEntities dbcon = new HospitalDBEntities();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "List of current Patients:";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DoctorsTable myDoctor = UtilitiesClass.getDoctor(Session["LoginName"].ToString());

            //if (RadioButtonList1.SelectedIndex == 0)
            //{
            //    foreach(GridView row in GridView1.Rows)
            //    {
            //        if (row.PatientID.ToString().Equals(TextBox1.Text))
            //        {
                        
            //            GridView1.DataSource = patient;
            //            break;
            //        }
            //    }
            //}
        }
    }
}