using CourseWork.Pages;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;

namespace CourseWork
{
    //Класс для Добавления Больницы
    public partial class AddHospital : Window
    {
        //Переменная нужная для отслеживания действий (Добавление или удаление)
        public bool isAdd = false;
        public int SelectedIndex { get; set; }
        public AddHospital(string str)
        {
            InitializeComponent();

            DoctList.ItemsSource = ApplicationView.MedInst.SelectMany(d => d.Doctors).ToList();
            PatientList.ItemsSource = ApplicationView.MedInst.SelectMany(p => p.Patients).ToList();
            StaffsList.ItemsSource = ApplicationView.MedInst.SelectMany(s => s.Staffs).ToList();
            PolycList.ItemsSource = ApplicationView.Polyclinics;

            if (str == "Add")
            {
                isAdd = true;
                but_add_edit.Content = "Добавить";
            }
            else
            {
                SelectedIndex = ApplicationView.Hospitals.IndexOf(HospitalsPage.selectHosp);
                foreach (var doctor in ApplicationView.Hospitals[SelectedIndex].Doctors)
                    DoctList.SelectedItems.Add(doctor);
                foreach (var patient in ApplicationView.Hospitals[SelectedIndex].Patients)
                    PatientList.SelectedItems.Add(patient);
                foreach (var staff in ApplicationView.Hospitals[SelectedIndex].Staffs)
                    StaffsList.SelectedItems.Add(staff);
                foreach (var polyc in ApplicationView.Hospitals[SelectedIndex].AttachedPolyclinics)
                    PolycList.SelectedItems.Add(polyc);
            }
        }
        //Метод для добавления
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            int medInstIndex = 0;

            char[] delimiters = new char[] { '-', ' ', '.', ',', '(', ')', '{', '}', '@', '#', '$', '%', '^', '<', '>', '?', '&', '*', '!', '+', '=', ':', ';', '\'', '\"', '/', '\\', '[', ']', '+' };

            string[] buildings = BuildText.Text
                    .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                    .Select(word => word.Trim())
                    .Where(word => !string.IsNullOrEmpty(word))
                    .Select(word => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.ToLower()))
                    .ToArray();

            string[] departments = DepartText.Text
                    .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                    .Select(word => word.Trim())
                    .Where(word => !string.IsNullOrEmpty(word))
                    .Select(word => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.ToLower()))
                    .ToArray();

            string[] wards = WardText.Text
                    .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                    .Select(word => word.Trim())
                    .Where(word => !string.IsNullOrEmpty(word))
                    .Select(word => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.ToLower()))
                    .ToArray();

            var selectedDoctors = DoctList.SelectedItems.Cast<Doctor>().ToList();
            var selectedPatients = PatientList.SelectedItems.Cast<Patient>().ToList();
            var selectedStaffs = StaffsList.SelectedItems.Cast<SupportStaff>().ToList();
            var selectedPolyc = PolycList.SelectedItems.Cast<Polyclinic>().ToList();

            if (NameText.Text == "" || BuildText.Text == "" || DepartText.Text == "" ||
                WardText.Text == "" || selectedDoctors.Count == 0 || selectedPatients.Count == 0 || selectedStaffs.Count == 0 || selectedPolyc.Count == 0)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            Hospital hosp = new Hospital(NameText.Text.Trim());

            for (int i = 0; i < buildings.Length; i++)
            {
                if (buildings[i] == "")
                    continue;

                hosp.AddBuilding(new Building(buildings[i].Trim()));
                for (int j = 0; j < departments.Length; j++)
                {
                    if (departments[j] != "")
                        hosp.Buildings[i].AddDepartment(new Department(departments[j].Trim()));
                    for (int k = 0; k < wards.Length; k++)
                    {
                        if (wards[k] != "")
                            hosp.Buildings[i].Departments[j].AddWard(new Ward(wards[k].Trim(), 0));
                    }
                }
            }

            //Если необходимо изменить
            if (!isAdd)
            {
                if (SelectedIndex >= 0)
                {
                    ApplicationView.Hospitals[SelectedIndex].Name = NameText.Text;
                    ApplicationView.Hospitals[SelectedIndex].Doctors = selectedDoctors;
                    ApplicationView.Hospitals[SelectedIndex].Patients = selectedPatients;
                    ApplicationView.Hospitals[SelectedIndex].Staffs = selectedStaffs;
                    ApplicationView.Hospitals[SelectedIndex].AttachedPolyclinics = selectedPolyc;
                    MessageBox.Show("Больница была успешно изменена");
                }
            }
            else
            {
                hosp.Doctors = selectedDoctors;
                hosp.Patients = selectedPatients;
                hosp.Staffs = selectedStaffs;
                hosp.AttachedPolyclinics = selectedPolyc;
                ApplicationView.Hospitals.Add(hosp);
                MessageBox.Show("Больница была успешно добавлена");
            }

            var hospitals= new ObservableCollection<Hospital>(ApplicationView.Hospitals);
            ApplicationView.Hospitals.Clear();
            foreach (var h in hospitals)
                ApplicationView.Hospitals.Add(h);

            Close();
        }
    }
}
