using CourseWork.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace CourseWork
{
    //Класс для хранения данных
    public class ApplicationView
    {
        //Дефолтные имена файлов, где содержиться данные 
        string nameHopital = "Save\\data_hosp.json";
        string namePoliclinic = "Save\\data_polic.json";
        string nameLab = "Save\\data_lab.json";

        //Коллекции для хранения каждого типа Мед Учреждений
        static public ObservableCollection<MedicalInstitution> MedInst { get; set; }
        static public ObservableCollection<Hospital> Hospitals { get; set; }
        static public ObservableCollection<Polyclinic> Polyclinics { get; set; }
        static public ObservableCollection<Laboratory> Labs { get; set; }

        public ApplicationView()
        {
            //Инициализируем данные
            initializedProgramm();
        }
        //Метод для инициализации данных
        public void initializedProgramm()
        {
            MedInst = new();
            //Создаем обект с помощью которого будем брать данные из JSON
            SerJSON jSON = new SerJSON();
            //Для каждого Мед Учреждения считываем данные
            Hospitals = jSON.ReadDataHosp(nameHopital);
            Polyclinics = jSON.ReadDataPolic(namePoliclinic);
            Labs = jSON.ReadDataLab(nameLab);
            //Далее заполняем коллекцию (добавляем Больницы и Поликлиники) всех мед учреждений 
            //Сделано для упрощения отображения Людей
            foreach (var item in Hospitals)
            {
                MedInst.Add(item);
            }
            foreach (var item in Polyclinics)
            {
                MedInst.Add(item);
            }
        }
    }
}
