using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace HospitalOnlineSystemGroup12
{
    public partial class PatientSearch : System.Web.UI.Page
    {
        HospitalDBEntities dbcon = new HospitalDBEntities();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ListBox1.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();

            DoctorsTable myDoctor = UtilitiesClass.getDoctor(Session["LoginName"].ToString());
            List<PatientsTable> patientList = dbcon.PatientsTables.ToList(); // All Patients
            List<PatientsTable> doctorsPatientList = new List<PatientsTable>(); // Contains only patients of myDoctor

            // Populates doctor's patient list
            foreach (PatientsTable patient in patientList)
            {
                if (patient.DoctorID == myDoctor.DoctorID)
                {
                    doctorsPatientList.Add(patient);
                }      
            }

            // Search by PatientID
            if (RadioButtonList1.SelectedIndex == 0)
            {
                foreach(PatientsTable patient in doctorsPatientList)
                {
                    if (patient.PatientID.ToString().Equals(TextBox1.Text))
                    {
                        foreach (string s in Regex.Split(PatientSearch.patientToString(patient, dbcon), "\n"))  // Used to newline on ListBox
                        {
                            ListBox1.Items.Add(s);
                        }
                    }
                }
                if (ListBox1.Items.Count == 0)
                    ListBox1.Items.Add("No Patient Found.");
            } 
            // Search by First Name
            else if (RadioButtonList1.SelectedIndex == 1)
            {
                foreach (PatientsTable patient in doctorsPatientList)
                {
                    if (patient.FirstName.Trim().Equals(TextBox1.Text.Trim()))
                    {
                        foreach (string s in Regex.Split(PatientSearch.patientToString(patient, dbcon), "\n"))
                        {
                            ListBox1.Items.Add(s);
                        }
                    }
                }
                if (ListBox1.Items.Count == 0)
                    ListBox1.Items.Add("No Patient Found.");
            }
            // Search by Last Name
            else if (RadioButtonList1.SelectedIndex == 2)
            {
                foreach (PatientsTable patient in doctorsPatientList)
                {
                    if (patient.LastName.Trim().Equals(TextBox1.Text.Trim()))
                    {
                        foreach (string s in Regex.Split(PatientSearch.patientToString(patient, dbcon), "\n"))
                        {
                            ListBox1.Items.Add(s);
                        }
                    }
                }
                if (ListBox1.Items.Count == 0)
                    ListBox1.Items.Add("No Patient Found.");
            }
            else
            {
                ListBox1.Items.Add("Please select an option.");
            }

            ListBox1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            TextBox1.Text = "";
        }


        // Method used to populate ListBox
        public static string patientToString(PatientsTable patient, HospitalDBEntities dbcon)
        {
            List<TestsTable> tests = dbcon.TestsTables.ToList();
            List<MedicationListTable> meds = dbcon.MedicationListTables.ToList();
            List<AppointmentsTable> appointments = dbcon.AppointmentsTables.ToList();

            String final = "Name: " + patient.FirstName + " " + patient.LastName + "\nEmail: " + patient.Email + "\nTests:";

            foreach (TestsTable test in tests)
            {
                if (patient.TestID == test.TestID)
                    final += "  " + test.TestResults + "  " + test.TestDate;
            }
            final += "\nMedications:";
            foreach (MedicationListTable med in meds)
            {
                if (patient.MedicationID == med.MedicationID)
                    final += "  " + med.Description;
            }
            final += "\nAppointments:";
            foreach (AppointmentsTable app in appointments)
            {
                if (patient.PatientID == app.PatientID)
                    final += "  " + app.VisitSummary + "  " + app.Date + "\n";
            }
            return final;
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}