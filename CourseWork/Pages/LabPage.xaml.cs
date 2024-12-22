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
    //Класс страницы для Лабораторий
    public partial class LabPage : Page
    {
        public static Laboratory selectLab;
        public List<Laboratory> filtredList;
        public LabPage()
        {
            InitializeComponent();
        }

        private void Filter(object sender, TextChangedEventArgs e)
        {
            filtredList = ApplicationView.Labs.ToList();
            if (NameText.Text == "" && CountPoly.Text == "" && CountProf.Text == "" && CountHosp.Text == "")
            {
                RowCountPanel.Visibility = Visibility.Hidden;
                myDatagrid.ItemsSource = ApplicationView.Labs;
            }
            else
            {
                if (NameText.Text != "")
                {
                    filtredList = filtredList.Where(x => x.Name.Contains(NameText.Text)).ToList();
                }
                if (CountPoly.Text != "" && correctInput(CountPoly.Text))
                {
                    filtredList = filtredList.Where(x => x.Policlinics.Count == Convert.ToInt32(CountPoly.Text)).ToList();
                }
                if (CountProf.Text != "" && correctInput(CountProf.Text))
                {
                    filtredList = filtredList.Where(x => x.Profiles.Count == Convert.ToInt32(CountProf.Text)).ToList();
                }
                if (CountHosp.Text != "" && correctInput(CountHosp.Text))
                {
                    filtredList = filtredList.Where(x => x.Hospitals.Count == Convert.ToInt32(CountHosp.Text)).ToList();
                }

                myDatagrid.ItemsSource = null;
                myDatagrid.ItemsSource = filtredList;
                CountRowText.Text = Convert.ToString(filtredList.Count());
                RowCountPanel.Visibility = Visibility.Visible;
            }
        }

        private bool correctInput(string str)
        {
            foreach (char c in str)
            {
                if ((c < '0' || c > '9'))
                {
                    return false;
                }
            }
            return true;
        }

        private void Choise_Lab(object sender, MouseButtonEventArgs e)
        {
            var win_info = new WindowInfo();
            var selectRow = sender as DataGridRow;
            Laboratory selectedHosp = selectRow.Item as Laboratory;
            win_info.InfoText.Text = selectedHosp.GetInfo();
            if (win_info.ShowDialog() == true) { }
        }

        private void ToStr(ref string hosp, ref string polyc, ref string prof)
        {
            foreach (var item in selectLab.Hospitals)
            {
                hosp += item.Name;
                hosp += ";";
            }
            foreach (var item in selectLab.Policlinics)
            {
                polyc += item.Name;
                polyc += ";";
            }
            foreach (var item in selectLab.Profiles)
            {
                prof += item;
                prof += ";";
            }

            if(hosp.Length > 1)hosp = hosp.Substring(0, (hosp.Length - 1));
            if (hosp.Length > 1) polyc = polyc.Substring(0, (polyc.Length - 1));
            if (hosp.Length > 1) prof = prof.Substring(0, (prof.Length - 1));
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            var win_add = new AddWin.AddLab("Add") { DataContext = this.DataContext };
            if (win_add.ShowDialog() == true) { }
            myDatagrid.Items.Refresh();
            //Есть отдельный класс, где описана логика работы с JSON
            SerJSON ser = new();
            //Вызываем метод для сохранения данных, передавая туда имена файлов
            ser.SaveData();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            selectLab = (Laboratory)myDatagrid.SelectedItem;
            if (selectLab != null)
            {
                string hosp = "";
                string polyc= "";
                string prof = "";

                ToStr(ref hosp, ref polyc, ref prof);

                var win_add = new AddLab("Edit") { DataContext = this.DataContext };
                win_add.NameText.Text = selectLab.Name;
                win_add.ProfText.Text = prof;

                if (win_add.ShowDialog() == true) { }
                myDatagrid.Items.Refresh();
                //Есть отдельный класс, где описана логика работы с JSON
                SerJSON ser = new();
                //Вызываем метод для сохранения данных, передавая туда имена файлов
                ser.SaveData();
            }
            else
            {
                MessageBox.Show("Выберете лабораторию");
            }
        }

        private void Button_Del(object sender, RoutedEventArgs e)
        {
            Laboratory selecHosp = (Laboratory)myDatagrid.SelectedItem;
            if (selecHosp != null)
            {
                int medInstIndex = ApplicationView.Labs.IndexOf(selecHosp);
                if (medInstIndex != -1)
                {
                    int hospIndex = ApplicationView.Labs.IndexOf(selecHosp);
                    ApplicationView.Labs.RemoveAt(medInstIndex);
                }
                MessageBox.Show($"{selecHosp.Name} удалена");
                myDatagrid.Items.Refresh();
                //Есть отдельный класс, где описана логика работы с JSON
                SerJSON ser = new();
                //Вызываем метод для сохранения данных, передавая туда имена файлов
                ser.SaveData();
            }
            else
            {
                MessageBox.Show("Выберете лабораторию");
            }
        }
    }
}
