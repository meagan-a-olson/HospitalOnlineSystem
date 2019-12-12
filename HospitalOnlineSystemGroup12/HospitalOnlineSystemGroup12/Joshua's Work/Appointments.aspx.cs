using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalOnlineSystemGroup12.Joshua_s_Work
{
    public partial class Appointments : System.Web.UI.Page
    {
        HospitalDBEntities dbcon = new HospitalDBEntities();
        PatientsTable myPatient = new PatientsTable();
        DoctorsTable myDoctor = new DoctorsTable();
        List<AppointmentsTable> allAppointments = new List<AppointmentsTable>();
        List<AppointmentsTable> userAppointments = new List<AppointmentsTable>();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Checks if user is patient or doctor, and creates object
            if (Convert.ToInt32(Session["IsDoctor"]) == 0)
            {
                ShowDoctorAppointments.Visible = false;
                List<PatientsTable> users = dbcon.PatientsTables.ToList();
                foreach (PatientsTable patient in users)
                {
                    // Info transferred in from login in Context
                    if (Session["LoginName"].ToString().Equals(patient.UserLoginName))
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

                Session["AppointmentPatientID"] = myPatient.PatientID;

                allAppointments = dbcon.AppointmentsTables.ToList();
                foreach(AppointmentsTable appointment in allAppointments)
                {
                    if(appointment.PatientID == myPatient.PatientID)
                    {
                        userAppointments.Add(appointment);
                    }
                }

                if (userAppointments.Count == 0)
                {
                    DisplayNoAppointMessage.Text = "You have no appointments set up yet.";
                }
                else
                {
                    DisplayNoAppointMessage.Visible = false;
                    DeletePatientAppointButton.Visible = true;
                }
                
            }
            else
            {
                ShowDoctorAppointments.Visible = true;
                ShowPatientAppointments.Visible = false;
                List<DoctorsTable> doctorUsers = dbcon.DoctorsTables.ToList();
                foreach (DoctorsTable doctor in doctorUsers)
                {
                    // Info transferred in from login in Context
                    if (Session["LoginName"].ToString().Equals(doctor.UserLoginName))
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

                Label1.Text = Session["LoginName"].ToString();
                Session["AppointmentDoctorID"] = myDoctor.DoctorID;

                allAppointments = dbcon.AppointmentsTables.ToList();
                foreach (AppointmentsTable appointment in allAppointments)
                {
                    if (appointment.DoctorID == myDoctor.DoctorID)
                    {
                        userAppointments.Add(appointment);
                    }
                }

                if (userAppointments.Count == 0)
                {
                    DisplayNoAppointMessage.Text = "You have no appointments set up yet.";
                }
                else
                {
                    DisplayNoAppointMessage.Visible = false;
                    DeleteDoctorAppointButton.Visible = true;
                }
            }
        }

        protected void ShowAppointmentsDataGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}