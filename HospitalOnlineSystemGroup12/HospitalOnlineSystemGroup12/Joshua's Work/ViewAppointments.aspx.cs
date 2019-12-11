using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalOnlineSystemGroup12.Joshua_s_Work
{
    public partial class ViewAppointments : System.Web.UI.Page
    {
        HospitalDBEntities dbcon = new HospitalDBEntities();
        PatientsTable myPatient = new PatientsTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["UserLoginName"].ToString();
            if (Convert.ToInt32(Context.Items["IsDoctor"]) == 0)
            {
                List<PatientsTable> patients = dbcon.PatientsTables.ToList();
                List<AppointmentsTable> allAppointments = dbcon.AppointmentsTables.ToList();
                List<AppointmentsTable> usersAppointments = new List<AppointmentsTable>();
                foreach (PatientsTable patient in patients)
                {
                    // Info transferred in from login in Context
                    if (Session["UserLoginName"].ToString().Equals(patient.UserLoginName))
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

                foreach (AppointmentsTable appointment in allAppointments)
                {
                    if (appointment.PatientID == myPatient.PatientID)
                    {
                        usersAppointments.Add(appointment);
                    }
                }

                AppointmentDisplayGridView.DataSource = usersAppointments;
            }
        }
    }
}