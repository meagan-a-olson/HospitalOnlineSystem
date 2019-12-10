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
            if (Convert.ToInt32(Context.Items["IsDoctor"]) == 0)
            {
                List<PatientsTable> users = dbcon.PatientsTables.ToList();
                foreach (PatientsTable patient in users)
                {
                    // Info transferred in from login in Context
                    if (Context.Items["LoginName"].ToString().Equals(patient.UserLoginName))
                    {
                        myPatient.PatientID = patient.PatientID;
                        myPatient.DoctorID = patient.DoctorID;
                        myPatient.FirstName = patient.FirstName;
                        myPatient.LastName = patient.LastName;
                        myPatient.Address = patient.Address;
                        myPatient.Phone = patient.Phone;
                        myPatient.Email = patient.Email;
                        myPatient.UserLoginName = patient.UserLoginName;
                        myPatient.MedicationID = patient.MedicationID;
                        myPatient.TestID = patient.TestID;
                    }
                }
            }
            else
            {
                List<DoctorsTable> users = dbcon.DoctorsTables.ToList();
                foreach (DoctorsTable doctor in users)
                {
                    // Info transferred in from login in Context
                    if (Context.Items["LoginName"].ToString().Equals(doctor.UserLoginName))
                    {
                        myDoctor.DoctorID = doctor.DoctorID;
                        myDoctor.FirstName = doctor.FirstName;
                        myDoctor.LastName = doctor.LastName;
                        myDoctor.Location = doctor.Location;
                        myDoctor.Department = doctor.Department;
                        myDoctor.Email = doctor.Email;
                        myDoctor.UserLoginName = doctor.UserLoginName;
                    }
                }
            }


            // Page load depends on whether Patient or Doctor
            if (Convert.ToInt32(Context.Items["IsDoctor"]) == 0)
            {
                Label1.Text = myPatient.FirstName + " " + myPatient.LastName;
                Label2.Text = "Your Doctor is: ";
            }
            else
            {
                Label1.Text = myDoctor.FirstName + " " + myDoctor.LastName;
                Label2.Visible = false;
            }
                
        }
    }
}