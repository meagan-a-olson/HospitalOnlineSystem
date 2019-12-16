using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalOnlineSystemGroup12
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["IsDoctor"]) == 0)
            {
                PatientsTable myPatient = UtilitiesClass.getPatient(Session["LoginName"].ToString());
                DoctorsTable myDoctor = UtilitiesClass.getPatientsDoctor(myPatient);

                HyperLink4.Text = "Medications/Tests";
                HyperLink4.NavigateUrl = "~/MedAndTestsList.aspx";
                Label1.Text = "Current Session: " + myPatient.FirstName.Trim() + " " + myPatient.LastName.Trim() + " - Your Doctor: " + myDoctor.FirstName + " " + myDoctor.LastName;
            }
            else if (Convert.ToInt32(Session["IsDoctor"]) == 1)
            {
                DoctorsTable myDoctor = UtilitiesClass.getDoctor(Session["LoginName"].ToString());

                HyperLink4.Text = "Search for Patient";
                HyperLink4.NavigateUrl = "~/PatientSearch.aspx";
                Label1.Text = "Current Session: " + myDoctor.FirstName + " " + myDoctor.LastName;
            }
        }
    }
}