using CourseWork.AddWin;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace CourseWork.Pages
{
    //Класс страницы для Пациентов
    public partial class PatientPage : Page
    {
        public List<Patient> Allpatients; // Лист для хранения Пациентов из всех Мед Учреждений
        public List<Patient> filtredList; // Лист для хранения отфильтрованных Пациентов
        static public Patient selecPat; // Хранит в себе выбранный обект (Пациентов)
        static public MedicalInstitution buf_med = null; // Хранит в себе Мед учереждение выбранного Пациентов

        public PatientPage()
        {
            InitializeComponent();
            WriteTable();
        }
        //Метод создания данных для таблицы со всем Персоналом
        public void WriteTable()
        {
            Allpatients = new();
            //Пробегаемся по всем мед учреждениям
            for (int i = 0; i < ApplicationView.MedInst.Count; i++)
            {
                //Пробегаемся по всем Пациентам одного Мед Учреждения
                for (int j = 0; j < ApplicationView.MedInst[i].Patients.Count; j++)
                {
                    //Пополняем наш список всех Пациентов
                    Allpatients.Add(ApplicationView.MedInst[i].Patients[j]);
                }
            }
            //Задаем начальные данные для таблици
            myDatagrid.ItemsSource = Allpatients;
        }
        //Метод для фильтрации
        private void Filter(object sender, TextChangedEventArgs e)
        {
            //Задаем начальные данные для отфильтрованного списка (все Пациенты)
            filtredList = Allpatients;
            //Если поля для ввода пустые
            if (NameText.Text == "" && WardText.Text == "" && DataText.Text == "" && ConText.Text == "" && TempeText.Text == "" && NameDoctorText.Text == "") 
            {
                //Скрыть текстовое поле с выводам найденных отфильтрованных элементов
                RowCountPanel.Visibility = Visibility.Hidden;
                //Определить данные для отабражения таблицы
                myDatagrid.ItemsSource = Allpatients;
            }
            else
            {
                //Находим в отфильтрованном списке тот, в котором есть часть текста и перезаписываем отфильтрованный лист
                if (NameText.Text != "")
                    filtredList = filtredList.Where(x => x.Name.Contains(NameText.Text)).ToList();
                if (WardText.Text != "")
                    filtredList = filtredList.Where(x => x.Position.Contains(WardText.Text)).ToList();
                if (DataText.Text != "") //Т.к. Поле имеет тип DataTime, то необходимо конвертировать его
                    filtredList = filtredList.Where(x => x.AdmissionDate == Convert.ToDateTime(DataText.Text)).ToList();
                if (ConText.Text != "")
                    filtredList = filtredList.Where(x => x.Condition.Contains(ConText.Text)).ToList();
                if (TempeText.Text != "" && correctInput(TempeText.Text))
                    filtredList = filtredList.Where(x => x.Temperature == Convert.ToDouble(TempeText.Text)).ToList();
                if (NameDoctorText.Text != "")
                    filtredList = filtredList.Where(x => x.AttendingDoctor.Name == NameDoctorText.Text).ToList();
                myDatagrid.ItemsSource = null;

                myDatagrid.ItemsSource = filtredList;

                CountRowText.Text = Convert.ToString(filtredList.Count());

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
            
            var win_add = new AddWin.AddPatient("Add") { DataContext = this.DataContext };

            if (win_add.ShowDialog() == true) { }
            WriteTable();
            myDatagrid.Items.Refresh();
           
            SerJSON ser = new();

            ser.SaveData();
        }
        //Метод для изменения выбранного элемента
        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            selecPat = (Patient)myDatagrid.SelectedItem;
            int docIndex = -1;

            if (selecPat != null)
            {
                foreach (var item in ApplicationView.MedInst)
                {
                    docIndex = item.Patients.IndexOf(selecPat);
                    if (docIndex != -1)
                    {
                        buf_med = item;
                        break;
                    }
                }
                //Если нашли мед учреждение
                if (docIndex != -1)
                {
                    //Создаем окно для Изменения (оно одно, для изменения и добавления)
                    var win_add = new AddPatient("Edit") { DataContext = this.DataContext };
                    //Передаем в текстовые поля созданного окна парамтры выбранного элемента
                    win_add.NameText.Text = selecPat.Name;
                    win_add.MedIstText.SelectedItem = buf_med;
                    win_add.PalatText.Text = selecPat.Position;
                    win_add.DataText.SelectedDate = selecPat.AdmissionDate;
                    win_add.CondText.Text = selecPat.Condition;
                    win_add.TempText.Text = selecPat.Temperature.ToString();
                    win_add.DoctText.SelectedItem = selecPat.AttendingDoctor;

                    if (win_add.ShowDialog() == true) { }
                    WriteTable();
                    myDatagrid.Items.Refresh();
                    SerJSON ser = new();
                    ser.SaveData();
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
            var selecDoct = (Patient)myDatagrid.SelectedItem;
            int docIndex;
            //Если пользователь выбрал элемент
            if (selecDoct != null)
            {
                //Пробегаемся по всем мед учреждениям
                foreach (var item in ApplicationView.MedInst)
                {
                    //Пытаемся найти Мед учреждения в котором лежит Пациент
                    docIndex = item.Patients.IndexOf(selecDoct);
                    //Если он найден, то удалям элемент
                    if (docIndex != -1) item.Patients.RemoveAt(docIndex);
                }
                WriteTable();
                myDatagrid.Items.Refresh();
                MessageBox.Show($"{selecDoct.Name} удален");
                SerJSON ser = new();
                ser.SaveData();
            }
            else
            {
                MessageBox.Show($"Выберете пациента");
            }
        }
    }
}
