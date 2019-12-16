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

        // Creates Patient from login username
        public static PatientsTable getPatient(string username)
        {
            PatientsTable myPatient = null;
            username = username.Trim();
            foreach(PatientsTable patient in dbcon.PatientsTables)
            {
                if (patient.UserLoginName.ToString().Trim() == username) // if input is equal to a username in database, create copy
                {
                    myPatient = new PatientsTable();
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

        // Creates Doctor from loged in patient
        public static DoctorsTable getPatientsDoctor(PatientsTable patient)
        {
            DoctorsTable doctor = null;
            foreach(DoctorsTable doc in dbcon.DoctorsTables)
            {
                if(doc.DoctorID == patient.DoctorID) // if patient's DoctorID equals DoctorID in doctor table, create copy of doctor
                {
                    doctor = new DoctorsTable();
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

        // Create Doctor from login username
        public static DoctorsTable getDoctor(string username)
        {
            DoctorsTable myDoctor = null;
            username = username.Trim();
            foreach (DoctorsTable doctor in dbcon.DoctorsTables)
            {
                if (doctor.UserLoginName.ToString().Trim() == username) // if input is equal to a username in database, create copy
                {
                    myDoctor = new DoctorsTable();
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

        // Creates appointment from appointmentID to delete
        public static AppointmentsTable createAppointment(int appointmentID)
        {
            AppointmentsTable deleteAppointment = new AppointmentsTable();
            foreach (AppointmentsTable appointment in dbcon.AppointmentsTables)
            {
                if (appointment.AppointmentID == appointmentID) // if input is equal an appointmentID in database, copy it for deletion
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

        // Searches for a Message in database by messageID, and returns copy
        public static MessagesTable getMessageByID(int messageID)
        {
            MessagesTable result = null;
            foreach (MessagesTable m in dbcon.MessagesTables)
            {
                if (m.MessageID == messageID)
                {
                    result = new MessagesTable();
                    result.MessageID = m.MessageID;
                    result.MessageTO = m.MessageTO;
                    result.MessageFROM = m.MessageFROM;
                    result.Date = m.Date;
                    result.Message = m.Message;
                    result.IsRead = m.IsRead;
                    break;
                }
            }
            return result;
        }
    }
}