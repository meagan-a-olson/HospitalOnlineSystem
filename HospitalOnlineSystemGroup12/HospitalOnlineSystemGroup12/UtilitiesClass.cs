using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HospitalOnlineSystemGroup12
{
    public static class UtilitiesClass
    {
        private static HospitalDBEntities dbcon = new HospitalDBEntities();

        public static PatientsTable getPatient(string username)
        {
            PatientsTable myPatient = new PatientsTable();
            foreach(PatientsTable patient in dbcon.PatientsTables)
            {
                if (patient.UserLoginName.ToString() == username)
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
                    break;
                }
            }
            return myPatient;
        }

        public static DoctorsTable getPatientsDoctor(PatientsTable patient)
        {
            DoctorsTable doctor = new DoctorsTable();
            foreach(DoctorsTable doc in dbcon.DoctorsTables)
            {
                if(doc.DoctorID == patient.DoctorID)
                {
                    doctor.FirstName = doc.FirstName;
                    doctor.LastName = doc.LastName;
                    doctor.UserLoginName = doc.UserLoginName;
                    doctor.Email = doc.Email;
                    doctor.DoctorID = doc.DoctorID;
                    doctor.Location = doc.Location;
                    doctor.Department = doc.Department;
                    break;
                }
            }
            return doctor;
        }

        public static DoctorsTable getDoctor(string username)
        {
            DoctorsTable myDoctor = new DoctorsTable();
            foreach (DoctorsTable doctor in dbcon.DoctorsTables)
            {
                if (doctor.UserLoginName.ToString() == username)
                {
                    myDoctor.DoctorID = doctor.DoctorID;
                    myDoctor.FirstName = doctor.FirstName;
                    myDoctor.LastName = doctor.LastName;
                    myDoctor.Location = doctor.Location;
                    myDoctor.Department = doctor.Department;
                    myDoctor.Email = doctor.Email;
                    myDoctor.UserLoginName = doctor.UserLoginName;
                    break;
                }
            }
            return myDoctor;
        }

        public static AppointmentsTable createAppointment(int appointmentID)
        {
            AppointmentsTable deleteAppointment = new AppointmentsTable();
            foreach (AppointmentsTable appointment in dbcon.AppointmentsTables)
            {
                if (appointment.AppointmentID == appointmentID)
                {
                    deleteAppointment.AppointmentID = appointment.AppointmentID;
                    deleteAppointment.PatientID = appointment.PatientID;
                    deleteAppointment.DoctorID = appointment.DoctorID;
                    deleteAppointment.Date = appointment.Date;
                    deleteAppointment.Time = appointment.Time;
                    deleteAppointment.Purpose = appointment.Purpose;
                    deleteAppointment.VisitSummary = appointment.VisitSummary;
                    break;
                }
            }
            return deleteAppointment;
        }
    }
}