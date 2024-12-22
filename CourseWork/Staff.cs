using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    // Абстрактный класс для людей (Пациентов и Докторов)
    public abstract class Staff
    {
        public string Name { get; set; }//Имя
        public string Position { get; set; }//должность для Докторов и Палата для Пациентов

        public Staff(string name, string position)
        {
            Name = name;
            Position = position;
        }
    }
}
