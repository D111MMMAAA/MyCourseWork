using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CourseWork
{

    public class Hospital : MedicalInstitution //Класс больницы
    {
        public List<Building> Buildings { get; set; }//Список корпусов
        public List<Polyclinic> AttachedPolyclinics { get; set; }//Список прикрипленных поликлиник

        public Hospital(string name) : base(name)
        {
            Buildings = new();
            AttachedPolyclinics = new();
        }

        public void AddBuilding(Building building)//добавление корпуса
        {
            Buildings.Add(building);
        }

        public void AttachPolyclinic(Polyclinic polyclinic)//добавление поликлиники
        {
            AttachedPolyclinics.Add(polyclinic);
        }
        // Метод для получения списка пациентов в указанной палате
        public List<Patient> GetPatientsByWard(string wardName)
        {
            return Patients.FindAll(p => p.Position.Equals(wardName, StringComparison.OrdinalIgnoreCase));
        }
        //Метод для вывода всей информации про Больницу
        public override string GetInfo()
        {
            string infoHosp = "";
            infoHosp += Name;
            //Пробегаемся по Корпусам
            foreach (var building in Buildings)
            {
                infoHosp += "\n" + " " + building.Name;
                //Пробегаемся по Отделениям данного Корпуса
                foreach (var department in building.Departments)
                {
                    infoHosp += "\n" + "  " + department.Name + " отделение";
                    //Пробегаемся по Палатам данного Отделения у данного Корпуса
                    foreach (var ward in department.Wards)
                    {
                        infoHosp += "\n" + "   " + ward.Name;
                        infoHosp += "\n" + "    Количестов свободных мест " + ward.FreeBeads + " из " + ward.NumberOfBeds;//Сколько коек свободно
                        
                        //Если количество свободных коек не равно общему количеству коек
                        //то получаем пациентов, который там лежат
                        if (ward.FreeBeads != ward.NumberOfBeds) {
                            var pat = GetPatientsByWard(ward.Name);//Получаем список пациентов
                            infoHosp += "\n" + "     Пациенты лежащие в палате: ";
                            //Цикл для вывода всех пациентов с их лечащими врачами
                            for (int i = 0; i < pat.Count; i++)
                            {
                                infoHosp += "\n" + "      " + pat[i].Name + " лечащий доктор: " + pat[i].AttendingDoctor.Name;
                            } 
                        }
                    }
                }
            }
            infoHosp += "\n\n" + " Работающий персонал:";
            infoHosp += "\n" + " Доктора\n" + GetDoctors();
            infoHosp += "\n" + " Обслуживающий персонал\n" + GetStaff();
            return infoHosp;
        }
    }

    public class Building//Класс корпуса больницы 
    {
        public string Name { get; set; }
        public List<Department> Departments { get; set; }//Список отделений

        public Building(string name)
        {
            Name = name;
            Departments = new List<Department>();
        }

        public void AddDepartment(Department department)//добавление отделения
        {
            Departments.Add(department);
        }
    }

    public class Department//Класс для отделения 
    {
        public string Name { get; set; }
        public List<Ward> Wards { get; set; }//Список палат для больницы или кабинетов для госпиталя

        public Department(string name)
        {
            Name = name;
            Wards = new List<Ward>();
        }

        public void AddWard(Ward ward)//Добавление палаты для больницы или кабинетов для госпиталя
        {
            Wards.Add(ward);
        }
    }

    public class Ward//Класс палат
    {
        public string Name { get; set; }
        public int NumberOfBeds { get; set; }//Количесво коек
        public int FreeBeads { get; set; }//Количество свободных коек

        public Ward(string name, int numberOfBeds)
        {
            Name = name;
            NumberOfBeds = numberOfBeds;
            FreeBeads = numberOfBeds;
        }
    }
}
