using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public enum DoctorDegree//Степнь кандидата или доктора (Нету, Канди, Доктор)
    {
        None,
        Candidate,
        Doctor
    }

    public enum HospitalType//Где работеат (Боль, Полик, в обоих)
    {
        Hospital,
        Polyclinic,
        Both
    }

    public class Doctor : Staff
    {
        public DoctorDegree Degree { get; set; }//Степень врача
        public HospitalType WorkType { get; set; }//Место работы
        public int OperationsPerformed { get; set; }//Общее число операций
        public int FatalOperations { get; set; }//Операции с летальным исходом
        public double SalaryCoefficient { get; set; }//Коэф к зарплате
        public int VacationDays { get; set; }// Отпуск

        public Doctor(string name, string position, int operationsPerformed, int fatalOperations, DoctorDegree degree, HospitalType workType) : base(name, position)
        {
            Degree = degree;
            WorkType = workType;
            OperationsPerformed = operationsPerformed;//Общее число проведенных операций
            FatalOperations = fatalOperations;//число проведенных операций с летальным исходом
            SalaryCoefficient = 1.0;//стандартный коэф зарплаты
            VacationDays = 30; // стандартный отпуск
            SetSpecialtyCharacteristics();
        }

        private void SetSpecialtyCharacteristics()//Определение спец условий
        {
            switch (Position.ToLower())
            {
                case "стоматолог":
                    SalaryCoefficient = 1.5;// коэффициент за вредные условия труда
                    break;
                case "рентгенолог":
                    SalaryCoefficient = 1.5;// коэффициент за вредные условия труда
                    VacationDays += 10; // дополнительный отпуск
                    break;
                case "невропатолог":
                    VacationDays += 10; // дополнительный отпуск
                    break;
            }
        }

        public string GetDegree()//Вывод степени
        {
            if (Degree == DoctorDegree.Doctor)
            {
                return "Professor";
            }
            else if (Degree == DoctorDegree.Candidate)
            {
                return "Associate Professor";
            }
            return "Doctor";
        }

        public string GetWorkType()//Вывод Где работает
        {
            if (WorkType == HospitalType.Hospital)
            {
                return "Hospital";
            }
            else if (WorkType == HospitalType.Polyclinic)
            {
                return "Polyclinic";
            }
            return "Both";
        }
    }
}
