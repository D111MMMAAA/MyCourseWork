using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CourseWork
{
    // Абстрактный класс для медицинских учреждений (Больниц и Поликлиник) ЛАБЫ НЕ ВХОДЯТ
    public abstract class MedicalInstitution
    {
        public string Name { get; set; } // название мед учереждений
        public List<Doctor> Doctors { get; set; } = new();
        public List<SupportStaff> Staffs { get; set; } = new();
        public List<Patient> Patients { get; set; } = new();

        [JsonConstructorAttribute]
        public MedicalInstitution(string name)
        {
            Name = name;
        }

        public void AddDoctor(Doctor doctor)//добавление доктора
        {
            Doctors.Add(doctor);
        }
        public void AddStaff(SupportStaff staff)//добавление обслуги
        {
            Staffs.Add(staff);
        }
        public void AddPatient(Patient pat)//добавление пациентов
        {
            Patients.Add(pat);
        }
        // метод для получения всех докторов в данном учреждении
        public string GetDoctors()
        {
            var info = "";
            foreach (var doctor in Doctors)
            {
                info += doctor.Name + ' ' + doctor.Position + "\n";
            }
            return info;
        }
        // метод для получения всех пациентов в данном учреждении
        public string GetPatient()
        {
            var info = "";
            foreach (var patient in Patients)
            {
                info += patient.Name + "\n";
            }
            return info;
        }
        // метод для получения всех персонала в данном учреждении
        public string GetStaff()
        {
            var info = "";
            foreach (var staff in Staffs)
            {
                info += staff.Name + ' ' + staff.Position + "\n";
            }
            return info;
        }
        // метод для получения информации о мед учереждении
        public virtual string GetInfo() 
        {
            string str = "";
            str += "\n\nИнформация о докторах\n\n" + GetDoctors();
            str += "\nИнформация о пациетах\n\n" + GetPatient();
            str += "\nИнформация о обслуживающем персонале\n\n" + GetStaff();
            return str;
        }
    }
}
