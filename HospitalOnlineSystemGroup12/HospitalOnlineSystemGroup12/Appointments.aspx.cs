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
            // If Patient, do this
            if (Convert.ToInt32(Session["IsDoctor"]) == 0)
            {
                // Doctor's appointments not visible to patient
                ShowDoctorAppointments.Visible = false;
                // Create Patient Object
                myPatient = UtilitiesClass.getPatient(Session["LoginName"].ToString());
                Session["AppointmentPatientID"] = myPatient.PatientID;

                // Create a Doctor object that is paired to the patient
                myDoctor = UtilitiesClass.getPatientsDoctor(myPatient);

                // Adds users appointments to appointments list
                allAppointments = dbcon.AppointmentsTables.ToList();
                foreach (AppointmentsTable appointment in allAppointments)
                {
                    if (appointment.PatientID == myPatient.PatientID)
                    {
                        userAppointments.Add(appointment);
                    }
                }

                // If no appointments are set up, display message
                if (userAppointments.Count == 0)
                {
                    DisplayNoAppointMessage.Text = "You have no appointments set up yet.";
                    DeletePatientAppointButton.Visible = false;
                }
                else // display patients appointments
                {
                    DisplayNoAppointMessage.Visible = false;
                    DeletePatientAppointButton.Visible = true;
                }

            }
            else // if Doctor, do this
            {
                AddAppointmentHyperLink.Visible = false;
                ShowDoctorAppointments.Visible = true;
                ShowPatientAppointments.Visible = false;

                DoctorsTable myDoctor = UtilitiesClass.getDoctor(Session["LoginName"].ToString());

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
                    DeleteDoctorAppointButton.Visible = false;
                }
                else
                {
                    DisplayNoAppointMessage.Visible = false;
                    DeleteDoctorAppointButton.Visible = true;
                }
            }
        }

        protected void DeletePatientAppointButton_Click(object sender, EventArgs e)
        {
            if (ShowPatientAppointments.SelectedRow != null) // if appointment selected to delete on gridview, do this
            {
                AppointmentsTable delete = new AppointmentsTable();
                string input = ShowPatientAppointments.SelectedValue.ToString(); // gets AppointmentID of selected row
                int appointmentID = Convert.ToInt32(input);
                delete = UtilitiesClass.createAppointment(appointmentID); // creates copy of appointment object to delete
                foreach (AppointmentsTable appointment in dbcon.AppointmentsTables) // check if appointment exists
                {
                    if(appointment.AppointmentID == delete.AppointmentID) // if appointment exists, delete it
                    {
                        dbcon.AppointmentsTables.Remove(appointment);
                    }
                }
                dbcon.SaveChanges(); // save changes to database
                ShowPatientAppointments.DataBind(); // update changes to grid view displaying patient appointment
                if (ShowPatientAppointments.Rows.Count == 0) // if no appointments, display message
                {
                    DisplayNoAppointMessage.Text = "You have no appointments set up.";
                    DisplayNoAppointMessage.Visible = true;
                    DeletePatientAppointButton.Visible = false; // makes delete appointment button invisible
                }
            }
        }

        protected void DeleteDoctorAppointButton_Click(object sender, EventArgs e) // same logic for deleting patient appointments
        {
            if (ShowDoctorAppointments.SelectedRow != null)
            {
                AppointmentsTable delete = new AppointmentsTable();
                string input = ShowDoctorAppointments.SelectedValue.ToString();
                int appointmentID = Convert.ToInt32(input);
                delete = UtilitiesClass.createAppointment(appointmentID);
                foreach (AppointmentsTable appointment in dbcon.AppointmentsTables)
                {
                    if (appointment.AppointmentID == delete.AppointmentID)
                    {
                        dbcon.AppointmentsTables.Remove(appointment);
                    }
                }
                dbcon.SaveChanges();
                ShowDoctorAppointments.DataBind();
                if (ShowDoctorAppointments.Rows.Count == 0)
                {
                    DisplayNoAppointMessage.Text = "You have no appointments set up.";
                    DisplayNoAppointMessage.Visible = true;
                    DeleteDoctorAppointButton.Visible = false;
                }
            }
        }
    }
}