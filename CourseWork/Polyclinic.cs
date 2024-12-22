using ScottPlot.Palettes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    //Класс для Поликлиник
    public class Polyclinic : MedicalInstitution
    {
        public List<Department> Departments { get; set; }//Список отделений

        public Polyclinic(string name) : base(name)
        {
            Name = name;
            Departments = new();
        }

        public void AddDepartment(Department dep)//добавление отделения
        {
            Departments.Add(dep);
        }

        //Получаем инфу про Поликлинику
        public override string GetInfo()
        {
            string infoHosp = "";
            infoHosp += Name;
            //Пробегаемся по листу Отделений Поликлиники и записываем их названия
            foreach (var department in Departments)
            {
                infoHosp += "\n" + "  " + department.Name + " отделение";
                //Пробегаемся по листу Кабинетов Отделений Поликлиники и записываем их названия
                foreach (var ward in department.Wards)
                {
                    infoHosp += "\n" + "   " + ward.Name;
                }
            }
            //Вызываем метод баззового класса для получения инфы про Докторов, Пациентов и Персонала
            infoHosp += base.GetInfo();
            return infoHosp;
        }
    }
}
