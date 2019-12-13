using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalOnlineSystemGroup12
{
    public partial class AddAppointment : System.Web.UI.Page
    {
        HospitalDBEntities dbcon = new HospitalDBEntities();
        PatientsTable myPatient = new PatientsTable();
        DoctorsTable myDoctor = new DoctorsTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            myPatient = UtilitiesClass.getPatient(Session["LoginName"].ToString());

            ShowUserNameLabel.Text = myPatient.FirstName + " " + myPatient.LastName;
            myDoctor = UtilitiesClass.getPatientsDoctor(myPatient);
            ShowPatientsDoctorLabel.Text = "Your doctor is: " + myDoctor.FirstName + " " + myDoctor.LastName;
        }
    }
}