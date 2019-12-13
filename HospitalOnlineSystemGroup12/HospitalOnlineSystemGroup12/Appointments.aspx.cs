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
                myPatient = UtilitiesClass.getPatient(Session["LoginName"].ToString());

                Session["AppointmentPatientID"] = myPatient.PatientID;

                DisplayNameLabel.Text = myPatient.FirstName + " " + myPatient.LastName;
                myDoctor = UtilitiesClass.getPatientsDoctor(myPatient);
                DisplayPatientsDoctorLabel.Text = "Your doctor is: " + myDoctor.FirstName + " " + myDoctor.LastName;

                allAppointments = dbcon.AppointmentsTables.ToList();
                foreach (AppointmentsTable appointment in allAppointments)
                {
                    if (appointment.PatientID == myPatient.PatientID)
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

                DoctorsTable myDoctor = UtilitiesClass.getDoctor(Session["LoginName"].ToString());

                DisplayNameLabel.Text = myDoctor.FirstName + " " + myDoctor.LastName;

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

        protected void DeletePatientAppointButton_Click(object sender, EventArgs e)
        {
            if (ShowDoctorAppointments.SelectedValue != null)
            {
                
            }
        }
    }
}