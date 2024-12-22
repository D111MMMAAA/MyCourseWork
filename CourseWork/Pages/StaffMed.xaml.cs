using CourseWork.AddWin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWork.Pages
{
    /*
     * Страница для отображения Персонала
     */
    public partial class StaffMed : Page
    {
        public List<SupportStaff> Allstaff;// Лист для хранения Персонала из всех Мед Учреждений
        public List<SupportStaff> filtredList; // Лист для хранения отфильтрованного Персонала
        static public SupportStaff selecStaf;// Хранит в себе выбранный обект (Персонал)
        static public MedicalInstitution buf_med = null;// Хранит в себе Мед учереждение выбранного Персонала

        public StaffMed()
        {
            InitializeComponent();
            WriteTable();//Инициализируем данные
        }
        //Метод создания данных для таблицы со всем Персоналом
        public void WriteTable()
        {
            Allstaff = new();
            //Пробегаемся по всем Мед Учреждениям
            for (int i = 0; i < ApplicationView.MedInst.Count; i++)
            {
                //Пробегаемся по всему Персоналу одного Мед Учреждения
                for (int j = 0; j < ApplicationView.MedInst[i].Staffs.Count; j++)
                {
                    //Пополняем наш список всего Персонала
                    Allstaff.Add(ApplicationView.MedInst[i].Staffs[j]);
                }
            }
            //Задаем начальные данные для таблици
            myDatagrid.ItemsSource = Allstaff;
        }
        //Метод для фильтрации
        private void Filter(object sender, TextChangedEventArgs e)
        {
            //Задаем начальные данные для отфильтрованного списка (весь Персонал)
            filtredList = Allstaff;
            //Если поля для ввода пустые
            if (NameText.Text == "" && SpecText.Text == "" )
            { 
                //Скрыть текстовое поле с выводам найденных отфильтрованных элементов
                RowCountPanel.Visibility = Visibility.Hidden;
                //Определить данные для отабражения таблицы
                myDatagrid.ItemsSource = Allstaff;
            }
            else
            {
                //Если имя не пустое
                if (NameText.Text != "")
                {
                    //Находим в отфильтрованном списке тот, в котором есть часть текста и перезаписываем отфильтрованный лист
                    filtredList = filtredList.Where(x => x.Name.Contains(NameText.Text)).ToList();
                }
                //Если специальность не пустая
                if (SpecText.Text != "")
                {
                    //Находим в отфильтрованном списке тот, в котором есть часть текста и перезаписываем отфильтрованный лист
                    filtredList = filtredList.Where(x => x.Position.Contains(SpecText.Text)).ToList();
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
        //Метод для добавления элементов
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            //Создаем окно добавления Персонала и определяем тот же контекст данных, что и в этом окне
            var win_add = new AddWin.AddStaffMed("Add") { DataContext = this.DataContext };
            //Пока окно активно, нельзя ничего делать в другом окне
            if (win_add.ShowDialog() == true) { }
            WriteTable();
            myDatagrid.Items.Refresh();

            //Есть отдельный класс, где описана логика работы с JSON
            SerJSON ser = new();
            //Вызываем метод для сохранения данных, передавая туда имена файлов
            ser.SaveData();
        }
        //Метод для изменения выбранного элемента
        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            //Сохраняем выбранный элемент
            selecStaf = (SupportStaff)myDatagrid.SelectedItem;
            int docIndex = -1;
            //Если пользователь выбрал элемент
            if (selecStaf != null)
            {
                //Пробегаемся по всем мед учреждениям
                foreach (var item in ApplicationView.MedInst)
                {
                    //Пытаемся найти Мед учреждения в котором работает Персонал
                    docIndex = item.Staffs.IndexOf(selecStaf);
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
                    var win_add = new AddStaffMed("Edit") { DataContext = this.DataContext };
                    //Передаем в текстовые поля созданного окна парамтры выбранного элемента
                    win_add.NameText.Text = selecStaf.Name;
                    win_add.SpecText.Text = selecStaf.Position;
                    win_add.BoxMedInst.SelectedItem = buf_med;
                    if (win_add.ShowDialog() == true) { }
                    //Перезаписываем таблицу
                    WriteTable();
                    myDatagrid.Items.Refresh();
                    //Есть отдельный класс, где описана логика работы с JSON
                    SerJSON ser = new();
                    //Вызываем метод для сохранения данных, передавая туда имена файлов
                    ser.SaveData();
                }
            }
            else
            {
                //Если пользователь не выбрал элемент, то выводиться сообщение
                MessageBox.Show($"Выберете доктора");
            }
        }
        //Метод для удаления элемента
        private void Button_Del(object sender, RoutedEventArgs e)
        {
            //Сохраняем выбранный элемент
            var selecDoct = (SupportStaff)myDatagrid.SelectedItem;
            int docIndex;
            //Если пользователь выбрал элемент
            if (selecDoct != null)
            {
                //Пробегаемся по всем мед учреждениям
                foreach (var item in ApplicationView.MedInst)
                {
                    //Пытаемся найти Мед учреждения в котором работает Персонал
                    docIndex = item.Staffs.IndexOf(selecDoct);
                    //Если он найден, то удалям элемент
                    if (docIndex != -1) item.Staffs.RemoveAt(docIndex);
                }
                MessageBox.Show($"{selecDoct.Name} удален");
                WriteTable();
                myDatagrid.Items.Refresh();
                //Есть отдельный класс, где описана логика работы с JSON
                SerJSON ser = new();
                //Вызываем метод для сохранения данных, передавая туда имена файлов
                ser.SaveData();
            }
            else
            {
                MessageBox.Show($"Выберете персонал");
            }
        }
    }
}
