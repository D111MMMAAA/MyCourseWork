using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace CourseWork.Pages
{
    public partial class HospitalsPage : Page
    {
        public static Hospital selectHosp;
        public List<Hospital> filtredList;

        public HospitalsPage()
        {
            InitializeComponent();
        }

        private void Filter(object sender, TextChangedEventArgs e)
        {
            filtredList = ApplicationView.Hospitals.ToList();
            if (NameText.Text == "" && CountPoly.Text == "" && CountBuilText.Text == "" && CountPatText.Text == "" && CountDoctText.Text == "" && CountStaffText.Text == "")
            {
                RowCountPanel.Visibility = Visibility.Hidden;
                myDatagrid.ItemsSource = ApplicationView.Hospitals;
            }
            else
            {
                if (NameText.Text != "")
                {
                    filtredList = filtredList.Where(x => x.Name.Contains(NameText.Text)).ToList();
                }
                if (CountPoly.Text != "" && correctInput(CountPoly.Text))
                {
                    filtredList = filtredList.Where(x => x.AttachedPolyclinics.Count == Convert.ToInt32(CountPoly.Text)).ToList();
                }
                if (CountBuilText.Text != "" && correctInput(CountBuilText.Text))
                {
                    filtredList = filtredList.Where(x => x.Buildings.Count == Convert.ToInt32(CountBuilText.Text)).ToList();
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

        private void Choise_Hospital(object sender, MouseButtonEventArgs e)
        {
            var win_info = new WindowInfo();
            var selectRow = sender as DataGridRow;
            Hospital selectedHosp = selectRow.Item as Hospital;
            win_info.InfoText.Text = selectedHosp.GetInfo();
            if (win_info.ShowDialog() == true) { }
        }

        private void ToStr(ref string build, ref string depart, ref string ward, ref string doct, ref string staff, ref string patient)
        {
            foreach (var item in selectHosp.Buildings) 
            { 
                build += item.Name;
                build += ";";
            }
            foreach (var item in selectHosp.Buildings[0].Departments)
            {
                depart += item.Name;
                depart += ";";
            }
            foreach (var item in selectHosp.Buildings[0].Departments[0].Wards)
            {
                ward += item.Name;
                ward += ";";
            }
            foreach (var item in selectHosp.Doctors)
            {
                doct += item.Name;
                doct += ";";
            }
            foreach (var item in selectHosp.Patients)
            {
                patient += item.Name;
                patient += ";";
            }
            foreach (var item in selectHosp.Staffs)
            {
                staff += item.Name;
                staff += ";";
            }

            if (build.Length > 1) build = build.Substring(0, (build.Length - 1));
            if (depart.Length > 1) depart = depart.Substring(0, (depart.Length - 1));
            if (ward.Length > 1) ward = ward.Substring(0, (ward.Length - 1));
            if (doct.Length > 1) doct = doct.Substring(0, (doct.Length - 1));
            if (staff.Length > 1) staff = staff.Substring(0, (staff.Length - 1));
            if (patient.Length > 1) patient = patient.Substring(0, (patient.Length - 1));
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            var win_add = new AddHospital("Add") { DataContext = this.DataContext };
            if (win_add.ShowDialog() == true) { }
            myDatagrid.Items.Refresh();
            //Есть отдельный класс, где описана логика работы с JSON
            SerJSON ser = new();
            //Вызываем метод для сохранения данных, передавая туда имена файлов
            ser.SaveData();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            selectHosp = (Hospital)myDatagrid.SelectedItem;
            if (selectHosp != null)
            {
                int medInstIndex = ApplicationView.Hospitals.IndexOf(selectHosp);
                if (medInstIndex != -1)
                {
                    string build_str = "";
                    string depart_str = "";
                    string ward_str = "";
                    string doct = "";
                    string staff = "";
                    string patient = "";

                    ToStr(ref build_str, ref depart_str, ref ward_str, ref doct, ref staff, ref patient);

                    var win_add = new AddHospital("Edit") { DataContext = this.DataContext };
                    win_add.NameText.Text = selectHosp.Name;
                    win_add.BuildText.Text= build_str;
                    win_add.DepartText.Text = depart_str;
                    win_add.WardText.Text = ward_str;

                    if (win_add.ShowDialog() == true) { }
                    myDatagrid.Items.Refresh();
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
            Hospital selecHosp = (Hospital)myDatagrid.SelectedItem;
            if (selecHosp != null)
            {
                int medInstIndex = ApplicationView.Hospitals.IndexOf(selecHosp);
                if (medInstIndex != -1)
                {
                    int hospIndex = ApplicationView.Hospitals.IndexOf(selecHosp);
                    ApplicationView.MedInst.RemoveAt(medInstIndex);
                    ApplicationView.Hospitals.RemoveAt(hospIndex);
                }
                MessageBox.Show($"{selecHosp.Name} удалена");
                myDatagrid.Items.Refresh();
                //Есть отдельный класс, где описана логика работы с JSON
                SerJSON ser = new();
                //Вызываем метод для сохранения данных, передавая туда имена файлов
                ser.SaveData();

                var hospitals = new ObservableCollection<Hospital>(ApplicationView.Hospitals);
                ApplicationView.Hospitals.Clear();
                foreach (var h in hospitals)
                    ApplicationView.Hospitals.Add(h);
            }
            else
            {
                MessageBox.Show("Выберете больницу");
            }
        }
    }
}
