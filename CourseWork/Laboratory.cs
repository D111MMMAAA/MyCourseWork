using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CourseWork
{
    public class Laboratory//Класс для лабораторий
    {
        public string Name { get; set; } // Название лаборатории
        public List<string> Profiles { get; set; }//Список профилей
        public List<Hospital> Hospitals { get; set; } // Список больниц с которыми заключен договор
        public List<Polyclinic> Policlinics { get; set; }// Список поликлиник с которыми заключен договор

        public Laboratory(string name, List<string> profiles, List<Hospital> hosp, List<Polyclinic> pol)
        {
            Name = name;
            Profiles = profiles;
            Hospitals = hosp;
            Policlinics = pol;
        }
        //Метод для получения информации про лабораторию
        public string GetInfo()
        {
            var str = "Информация про лабораторию\n" + Name;
            str += "\nПрофили";
            //Получаем все профили данной лабы
            foreach (var p in Profiles)
            {
                str += '\n' + p;
            }
            str += "\nМед учереждения с которыми заключены договора";
            str += "\nБольницы";
            //Получаем все Больницы с которой заключен договор у данной лабы
            foreach (var p in Hospitals)
            {
                str += '\n' + p.Name;
            }

            str += "\nПоликлиники";
            //Получаем все Поликлиники с которой заключен договор у данной лабы
            foreach (var p in Policlinics)
            {
                str += '\n' + p.Name;
            }
            return str;
        }
    }
}
