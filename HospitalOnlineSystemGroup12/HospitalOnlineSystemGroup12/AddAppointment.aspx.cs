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
        bool flag = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            myPatient = UtilitiesClass.getPatient(Session["LoginName"].ToString());
            if (!IsPostBack)
            {
                ShowSelectedDateLabel.Visible = false;
            }
        }

        protected void CreateAppointmentButton_Click(object sender, EventArgs e)
        {
            flag = true;
            AppointmentsTable newAppointment = new AppointmentsTable();
            newAppointment.PatientID = myPatient.PatientID;
            newAppointment.DoctorID = Convert.ToInt32(DoctorDropDownList.SelectedItem.Value);
            newAppointment.Date = Convert.ToDateTime(ShowSelectedDateLabel.Text);
            int hour = Convert.ToInt32(HourDropDownList.SelectedValue);
            int min = Convert.ToInt32(MinDropDownList.SelectedValue);
            TimeSpan mytime = new TimeSpan(hour, min, 0);
            newAppointment.Time = mytime;
            newAppointment.Purpose = "";
            newAppointment.VisitSummary = "";

            foreach(AppointmentsTable appointment in dbcon.AppointmentsTables)
            {
                if(DateTime.Compare(appointment.Date, newAppointment.Date) == 0)
                {
                    if(TimeSpan.Compare(appointment.Time, newAppointment.Time) == 0)
                    {
                        DisplayMesageLabel.Text = "An appointment already exists at this date and time.";
                        DisplayMesageLabel.Visible = true;
                        flag = false;
                    }
                }
            }

            if (flag)
            {
                dbcon.AppointmentsTables.Add(newAppointment);
                dbcon.SaveChanges();
                DisplayMesageLabel.Text = "Appointment Added.";
                DisplayMesageLabel.Visible = true;
                Server.Transfer("Appointments.aspx", true);
            }
        }

        protected void SelectDateCalendar_SelectionChanged(object sender, EventArgs e)
        {
            ShowSelectedDateLabel.Text = SelectDateCalendar.SelectedDate.ToString();
            ShowSelectedDateLabel.Visible = true;
        }
    }
}