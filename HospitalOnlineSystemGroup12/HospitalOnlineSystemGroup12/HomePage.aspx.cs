using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalOnlineSystemGroup12
{
    public partial class HomePage : System.Web.UI.Page
    {
        HospitalDBEntities dbcon = new HospitalDBEntities();
        PatientsTable myPatient = new PatientsTable();
        DoctorsTable myDoctor = new DoctorsTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Checks if user is patient or doctor, and creates object
            if (Convert.ToInt32(Session["IsDoctor"]) == 0)
            {
                myPatient = UtilitiesClass.getPatient(Session["LoginName"].ToString());
                Session["PatientID"] = myPatient.PatientID;

                Label1.Text = myPatient.FirstName + " " + myPatient.LastName;
                myDoctor = UtilitiesClass.getPatientsDoctor(myPatient);
                Label2.Text = "Your Doctor is: " + myDoctor.FirstName + " " + myDoctor.LastName;
            }
            else
            {
                // not working, wont display doctor name..?
                Label1.Text = Session["LoginName"].ToString();
                myDoctor = UtilitiesClass.getDoctor(Session["LoginName"].ToString());

                Label1.Text = myDoctor.FirstName + " " + myDoctor.LastName;
                Label2.Visible = false;
                HyperLink1.Visible = false;
            }

                
        }

    }
}