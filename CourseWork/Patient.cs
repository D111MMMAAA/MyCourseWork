using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{

    public class Patient : Staff//Класс пациента
    {
        public DateTime AdmissionDate { get; set; }//время поступления
        public string Condition { get; set; }//состояние
        public double Temperature { get; set; }//температура
        public Doctor AttendingDoctor { get; set; }//лечащий врач

        public Patient(string name, string position, DateTime admissionDate, string condition, double temperature, Doctor attendingDoctor) : base(name, position)
        {
            AdmissionDate = admissionDate;
            Condition = condition;
            Temperature = temperature;
            AttendingDoctor = attendingDoctor;
        }
    }
}
