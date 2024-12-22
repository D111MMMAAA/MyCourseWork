using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;


namespace CourseWork
{
    //Класс для работы с JSON
    public class SerJSON
    {
        public SerJSON() {}

        //Метод для сохранения инфы в JSON формат
        public void SaveData()
        {
            string nameHopital = "Save\\data_hosp.json";
            string namePoliclinic = "Save\\data_polic.json";
            string nameLab = "Save\\data_lab.json";
            //Сериализуем информацию про все Больницы
            string ser = JsonConvert.SerializeObject(ApplicationView.Hospitals);
            
            //Записываем в файл информацию про все Больницы
            File.WriteAllText(nameHopital, ser);

            ser = JsonConvert.SerializeObject(ApplicationView.Polyclinics);

            File.WriteAllText(namePoliclinic, ser);

            ser = JsonConvert.SerializeObject(ApplicationView.Labs);

            File.WriteAllText(nameLab, ser);

        }
        /*
         * Далее идут методы для получения данных из файлов
         * Принцип везде один - Десереализуем данные из JSON, 
         * предварительно передав туда имя файла 
         * и возвращаем коллекцию соответствующего типа
         */
        public ObservableCollection<Hospital> ReadDataHosp(string nameHopital)
        {
             return JsonConvert.DeserializeObject<ObservableCollection<Hospital>>(File.ReadAllText(nameHopital));
        }

        public ObservableCollection<Polyclinic> ReadDataPolic(string namePoliclinic)
        {
            return JsonConvert.DeserializeObject<ObservableCollection<Polyclinic>>(File.ReadAllText(namePoliclinic));
        }

        public ObservableCollection<Laboratory> ReadDataLab(string nameLab)
        {
            return JsonConvert.DeserializeObject<ObservableCollection<Laboratory>>(File.ReadAllText(nameLab));
        }
    }
}
