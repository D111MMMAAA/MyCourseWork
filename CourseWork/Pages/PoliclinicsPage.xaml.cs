using CourseWork.AddWin;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseWork.Pages
{
    //Класс страницы для Поликлиник
    public partial class PoliclinicsPage : Page
    {
        public static Polyclinic selectPol;// Хранит в себе выбранный обект (Поликлиника)
        public List<Polyclinic> filtredList;// Лист для хранения отфильтрованных Поликлиники
        public PoliclinicsPage()
        {
            InitializeComponent();
        }

        //Метод для фильтрации
        private void Filter(object sender, TextChangedEventArgs e)
        {
            //Задаем начальные данные для отфильтрованного списка (все Поликлиники)
            filtredList = ApplicationView.Polyclinics.ToList();
            //Если поля для ввода пустые
            if (NameText.Text == "" && CountDepartText.Text == "" && CountPatText.Text == "" && CountDoctText.Text == "" && CountStaffText.Text == "")
            {
                //Скрыть текстовое поле с выводам найденных отфильтрованных элементов
                RowCountPanel.Visibility = Visibility.Hidden;
                //Определить данные для отабражения таблицы
                myDatagrid.ItemsSource = ApplicationView.Polyclinics;
            }
            else
            {
                //Если имя не пустое
                if (NameText.Text != "")
                {
                    //Находим в отфильтрованном списке тот, в котором есть часть текста и перезаписываем отфильтрованный лист
                    filtredList = filtredList.Where(x => x.Name.Contains(NameText.Text)).ToList();
                }
                //Если поле не пустое и имеет тольок числа
                if (CountDepartText.Text != "" && correctInput(CountDepartText.Text))
                {
                    //Находим в отфильтрованном списке тот, в котором есть данное количество Отделов и перезаписываем отфильтрованный лист
                    filtredList = filtredList.Where(x => x.Departments.Count == Convert.ToInt32(CountDepartText.Text)).ToList();
                }
                if (CountPatText.Text != "" && correctInput(CountPatText.Text))
                {
                    filtredList = filtredList.Where(x => x.Patients.Count == Convert.ToInt32(CountPatText.Text)).ToList();
                }
                if (CountDoctText.Text != "" && correctInput(CountDoctText.Text))
                {
                    filtredList = filtredList.Where(x => x.Doctors.Count == Convert.ToInt32(CountDoctText.Text)).ToList();
                }
                if (CountStaffText.Text != "" && correctInput(CountStaffText.Text))
                {
                    filtredList = filtredList.Where(x => x.Staffs.Count == Convert.ToInt32(CountStaffText.Text)).ToList();
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
            //Пробегаемся по всем символам строки
            foreach (char c in str)
            {
                //Если есть хотя бы 1 символ не цифры
                if (c < '0' || c > '9')
                {
                    //Возвращаем Ложь
                    return false;
                }
            }
            return true;
        }

        //Метод для отображения инфы о Поликлинике
        private void Choise_Polyclinic(object sender, MouseButtonEventArgs e)
        {
            var win_info = new WindowInfo();
            var selectRow = sender as DataGridRow;
            Polyclinic selectedHosp = selectRow.Item as Polyclinic;
            win_info.InfoText.Text = selectedHosp.GetInfo();
            if (win_info.ShowDialog() == true) { }
        }

        //Метод для добавления
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            var win_add = new AddPolyclinic("Add") { DataContext = this.DataContext };
            if (win_add.ShowDialog() == true) { }
            SerJSON ser = new();
            ser.SaveData();
        }

        //Метод для преобразования строк (ref - обозначает передачу по ссылке)
        private void ToStr(ref string depart, ref string ward, ref string doct, ref string staff, ref string patient)
        {
            foreach (var item in selectPol.Departments)
            {
                //Записываем их названия
                depart += item.Name;
                depart += ";";
            }
            //Пробегаемся по всем кабинетам у 0 Отделения выбранной Поликлиники
            foreach (var item in selectPol.Departments[0].Wards)
            {
                //Записываем их названия
                ward += item.Name;
                ward += ";";
            }
            //Пробегаемся по всем Докторам выбранной Поликлиники
            foreach (var item in selectPol.Doctors)
            {
                //Записываем их имена
                doct += item.Name;
                doct += ";";
            }
            //Пробегаемся по всем Пациентам выбранной Поликлиники
            foreach (var item in selectPol.Patients)
            {
                //Записываем их имена
                patient += item.Name;
                patient += ";";
            }
            //Пробегаемся по всем Персонала выбранной Поликлиники
            foreach (var item in selectPol.Staffs)
            {
                //Записываем их имена
                staff += item.Name;
                staff += ";";
            }
            //Обрезаем полседний символ ";"
            if(depart.Length > 1) depart = depart.Substring(0, (depart.Length - 1));
            if (ward.Length > 1) ward = ward.Substring(0, (ward.Length - 1));
            if (doct.Length > 1) doct = doct.Substring(0, (doct.Length - 1));
            if (staff.Length > 1) staff = staff.Substring(0, (staff.Length - 1));
            if (patient.Length > 1) patient = patient.Substring(0, (patient.Length - 1));
        }

        //Метод для изменения
        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            //Сохраняем выбранную Поликлинику
            selectPol = (Polyclinic)myDatagrid.SelectedItem;
            //Если пользователь выбрал элемент
            if (selectPol != null)
            {
                //Пытаемся найти в списке всех Мед Учреждениях именно выбранный элемент
                int medInstIndex = ApplicationView.Polyclinics.IndexOf(selectPol);
                if (medInstIndex != -1)
                {
                    //создаем строки, которые будут хранить в себе информацию по каждому полю выбранного обекта
                    string depart_str = "";
                    string ward_str = "";
                    string doct = "";
                    string staff = "";
                    string patient = "";
                    //Заполяем строки
                    ToStr( ref depart_str, ref ward_str, ref doct, ref staff, ref patient);
                    //Создаем окно для изменения элемента
                    var win_add = new AddPolyclinic("Edit") { DataContext = this.DataContext };
                    //Передаем данные о Поликлинике в окно для изменения
                    win_add.NameText.Text = selectPol.Name;
                    win_add.DepartText.Text = depart_str;
                    win_add.WardText.Text = ward_str;
                    //Пока окно активно, нельзя ничего делать в другом окне
                    if (win_add.ShowDialog() == true) { }
                    //Есть отдельный класс, где описана логика работы с JSON
                    SerJSON ser = new();
                    //Вызываем метод для сохранения данных, передавая туда имена файлов
                    ser.SaveData();
                }
            }
            else
            {
                MessageBox.Show("Выберете больницу");
            }
        }

        private void Button_Del(object sender, RoutedEventArgs e)
        {
            //Сохраняем выбранный элемент
            Polyclinic selecHosp = (Polyclinic)myDatagrid.SelectedItem;
            //Если пользователь выбрал элемент
            if (selecHosp != null)
            {
                //Пытаемся найти в списке всех Мед учреждений нашу Поликлинику
                int medInstIndex = ApplicationView.Polyclinics.IndexOf(selecHosp);
                if (medInstIndex != -1)
                {
                    //Пытаемся найти Поликлинику
                    int hospIndex = ApplicationView.Polyclinics.IndexOf(selecHosp);
                    //Удаляем выбранную Поликлинику из списка всех Мед Учреждений и Поликлиник
                    ApplicationView.MedInst.RemoveAt(medInstIndex);
                    ApplicationView.Polyclinics.RemoveAt(hospIndex);
                }
                MessageBox.Show($"{selecHosp.Name} удалена");
                //Есть отдельный класс, где описана логика работы с JSON
                SerJSON ser = new();
                //Вызываем метод для сохранения данных, передавая туда имена файлов
                ser.SaveData();

                var polycs = new ObservableCollection<Polyclinic>(ApplicationView.Polyclinics);
                ApplicationView.Polyclinics.Clear();
                foreach (var p in polycs)
                    ApplicationView.Polyclinics.Add(p);
            }
            else
            {
                MessageBox.Show("Выберете поликлиника");
            }
        }
    }
}
