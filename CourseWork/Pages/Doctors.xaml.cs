using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CourseWork.Pages
{
    //Класс страницы для Докторов
    public partial class Doctors : Page
    {
        public List<Doctor> Alldoctors;// Лист для хранения Докторов из всех Мед Учреждений
        public List<Doctor> filtredList;// Лист для хранения отфильтрованных Докторов
        static public Doctor selecDoct;// Хранит в себе выбранный обект (Доктор)
        static public MedicalInstitution buf_med = null;// Хранит в себе Мед учереждение выбранного Доктора

        public Doctors()
        {
            InitializeComponent();
            WriteTable();//Инициализируем данные
        }
        //Метод создания данных для таблицы со всем Персоналом
        public void WriteTable()
        {
            Alldoctors = new();
            //Пробегаемся по всем мед учреждениям
            for (int i = 0; i < ApplicationView.MedInst.Count; i++)
            {
                //Пробегаемся по всем Докторам одного Мед Учреждения
                for (int j = 0; j < ApplicationView.MedInst[i].Doctors.Count; j++)
                {
                    //Пополняем наш список всех Докторов
                    Alldoctors.Add(ApplicationView.MedInst[i].Doctors[j]);
                }
            }
            //Задаем начальные данные для таблици
            myDatagrid.ItemsSource = Alldoctors;
        }
        //Метод для фильтрации
        private void Filter(object sender, TextChangedEventArgs e)
        {
            //Задаем начальные данные для отфильтрованного списка (все Пациенты)
            filtredList = Alldoctors;
            //Если поля для ввода пустые
            if (NameText.Text == "" && SpecText.Text == "" && DegreeText.Text == "" && WorkText.Text == "" && OperaText.Text == "" && OperaDeadText.Text == "" && KofMoneyText.Text == "" && ValDayText.Text == "")
            {
                //Скрыть текстовое поле с выводам найденных отфильтрованных элементов
                RowCountPanel.Visibility = Visibility.Hidden;
                //Определить данные для отабражения таблицы
                myDatagrid.ItemsSource = Alldoctors;
            }
            else
            {
                //Если имя не пустое
                if (NameText.Text != "")
                {
                    //Находим в отфильтрованном списке тот, в котором есть часть текста и перезаписываем отфильтрованный лист
                    filtredList = filtredList.Where(x => x.Name.Contains(NameText.Text)).ToList();
                }
                if (SpecText.Text != "")
                {
                    filtredList = filtredList.Where(x => x.Position.Contains(SpecText.Text)).ToList();
                }
                if (DegreeText.Text != "")
                {
                    //Используем метод для получения Степени и проверяем часть введеного текста и перезаписываем отфильтрованный лист
                    filtredList = filtredList.Where(x => x.GetDegree().Contains(DegreeText.Text)).ToList();
                }
                if (WorkText.Text != "")
                {
                    filtredList = filtredList.Where(x => x.GetWorkType().Contains(WorkText.Text)).ToList();
                }
                //Если поле для операций не пустое и там содержиться только число
                if (OperaText.Text != "" && correctInput(OperaText.Text))
                {
                    filtredList = filtredList.Where(x => x.OperationsPerformed == Convert.ToInt32(OperaText.Text)).ToList();
                }
                if (OperaDeadText.Text != "" && correctInput(OperaDeadText.Text))
                {
                    filtredList = filtredList.Where(x => x.FatalOperations == Convert.ToInt32(OperaDeadText.Text)).ToList();
                }
                if (KofMoneyText.Text != "" && correctInput(KofMoneyText.Text))
                {
                    filtredList = filtredList.Where(x => x.SalaryCoefficient == Convert.ToInt32(KofMoneyText.Text)).ToList();
                }
                if (ValDayText.Text != "" && correctInput(ValDayText.Text))
                {
                    filtredList = filtredList.Where(x => x.VacationDays == Convert.ToInt32(ValDayText.Text)).ToList();
                }
                //Сперва обнуляем данные для таблицы
                myDatagrid.ItemsSource = null;
                //Далее задаем отфильтрованный лист в качестве источника данных
                myDatagrid.ItemsSource = filtredList;
                //Записываем в текстовое поле количество найденных элементов
                CountRowText.Text = Convert.ToString(filtredList.Count());
                //Делаем текстовое поле видимым
                RowCountPanel.Visibility = Visibility.Visible;
            }
        }
        //Метод для проверки на число
        private bool correctInput(string str)
        {
            foreach (char c in str)
            {
                if ((c < '0' || c > '9') && (c != ','))
                    return false;
            }
            return true;
        }
        //Метод для добавления элементов
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            //Создаем окно добавления Пациентов и определяем тот же контекст данных, что и в этом окне
            var win_add = new AddDoctors("Add") { DataContext = this.DataContext };
            //Пока окно активно, нельзя ничего делать в другом окне
            if (win_add.ShowDialog() == true) { }
            //перезаписываем таблицу
            WriteTable();
            //Есть отдельный класс, где описана логика работы с JSON
            SerJSON ser = new();
            //Вызываем метод для сохранения данных, передавая туда имена файлов
            ser.SaveData();
            myDatagrid.Items.Refresh();
        }
        //Метод для изменения выбранного элемента
        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            //Сохраняем выбранный элемент
            selecDoct = (Doctor)myDatagrid.SelectedItem;
            int docIndex = -1;
            //Если пользователь выбрал элемент
            if (selecDoct != null)
            {
                //Пробегаемся по всем Мед учреждениям
                foreach (var item in ApplicationView.MedInst)
                {
                    //Пытаемся найти Мед учреждения в котором работает Доктор
                    docIndex = item.Doctors.IndexOf(selecDoct);
                    //Если нашли
                    if (docIndex != -1)
                    {
                        //То сохраняем данное мед учреждение
                        buf_med = item;
                        break;
                    }
                }
                //Если нашли мед учреждение
                if (docIndex != -1)
                {
                    //Создаем окно для Изменения (оно одно, для изменения и добавления)
                    var win_add = new AddDoctors("Edit") { DataContext = this.DataContext };
                    //Передаем в текстовые поля созданного окна парамтры выбранного элемента
                    win_add.NameText.Text = selecDoct.Name;
                    win_add.SpecText.Text = selecDoct.Position;
                    win_add.BoxDegree.SelectedItem = selecDoct.Degree;
                    win_add.BoxOperationsPerformed.Text = selecDoct.OperationsPerformed.ToString();
                    win_add.BoxFatalOperations.Text = selecDoct.FatalOperations.ToString();
                    win_add.BoxNameMedInst.SelectedItem = buf_med;
                    win_add.BoxWork.SelectedItem = selecDoct.WorkType;
                    if (win_add.ShowDialog() == true) { }
                    //Перезаписываем таблицу
                    WriteTable();
                    //Есть отдельный класс, где описана логика работы с JSON
                    SerJSON ser = new();
                    //Вызываем метод для сохранения данных, передавая туда имена файлов
                    ser.SaveData();
                    myDatagrid.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show($"Выберете доктора");
            }
        }
        //Метод для удаления элемента
        private void Button_Del(object sender, RoutedEventArgs e)
        {
            //Сохраняем выбранный элемент
            var selecDoct = (Doctor)myDatagrid.SelectedItem;
            int docIndex;
            //Если пользователь выбрал элемент
            if (selecDoct != null)
            {
                //Пробегаемся по всем мед учреждениям
                foreach (var item in ApplicationView.MedInst)
                {
                    //Пытаемся найти Мед учреждения в котором лежит Пациент
                    docIndex = item.Doctors.IndexOf(selecDoct);
                    //Если он найден, то удалям элемент
                    if (docIndex != -1) item.Doctors.RemoveAt(docIndex);
                }
                //перезаписываем таблицу
                WriteTable();
                MessageBox.Show($"{selecDoct.Name} удален");
                myDatagrid.Items.Refresh();
                //Есть отдельный класс, где описана логика работы с JSON
                SerJSON ser = new();
                //Вызываем метод для сохранения данных, передавая туда имена файлов
                ser.SaveData();
            }
            else
            {
                MessageBox.Show($"Выберете доктора");
            }
        }
    }
}
