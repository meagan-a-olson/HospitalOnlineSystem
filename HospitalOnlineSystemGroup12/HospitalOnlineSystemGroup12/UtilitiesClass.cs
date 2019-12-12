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
    }
}