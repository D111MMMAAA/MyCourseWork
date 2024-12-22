using CourseWork.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
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
using System.Windows.Shapes;

namespace CourseWork.AddWin
{
    public partial class AddPolyclinic : Window
    {
        public int SelectedIndex { get; set; }
        public bool isAdd = false;
        public AddPolyclinic(string str)
        {
            InitializeComponent();
            DoctList.ItemsSource = ApplicationView.MedInst.SelectMany(d => d.Doctors).ToList();
            PatientList.ItemsSource = ApplicationView.MedInst.SelectMany(p => p.Patients).ToList();
            StaffsList.ItemsSource = ApplicationView.MedInst.SelectMany(s => s.Staffs).ToList();

            if (str == "Add")
            {
                isAdd = true;
                but_add_edit.Content = "Добавить";
            }
            else
            {
                SelectedIndex = ApplicationView.Polyclinics.IndexOf(PoliclinicsPage.selectPol);
                foreach (var doctor in ApplicationView.Polyclinics[SelectedIndex].Doctors)
                    DoctList.SelectedItems.Add(doctor);
                foreach (var patient in ApplicationView.Polyclinics[SelectedIndex].Patients)
                    PatientList.SelectedItems.Add(patient);
                foreach (var staff in ApplicationView.Polyclinics[SelectedIndex].Staffs)
                    StaffsList.SelectedItems.Add(staff);
            }
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            char[] delimiters = new char[] { '-', ' ', '.', ',', '(', ')', '{', '}', '@', '#', '$', '%', '^', '<', '>', '?', '&', '*', '!', '+', '=', ':', ';', '\'', '\"', '/', '\\', '[', ']', '+' };

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

            if (NameText.Text == "" || DepartText.Text == "" ||
                WardText.Text == "" || selectedDoctors.Count == 0 || selectedPatients.Count == 0 || selectedStaffs.Count == 0)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            Polyclinic polyc = new Polyclinic(NameText.Text.Trim());

            for (int j = 0; j < departments.Length; j++)
            {
                if (departments[j] != "") polyc.AddDepartment(new Department(departments[j].Trim()));
                for (int k = 0; k < wards.Length; k++)
                {
                    if (wards[k] != "") polyc.Departments[j].AddWard(new Ward(wards[k].Trim(), 0));
                }
            }

            if (!isAdd)
            {
                if (SelectedIndex >= 0)
                {
                    ApplicationView.Polyclinics[SelectedIndex].Name = NameText.Text;
                    ApplicationView.Polyclinics[SelectedIndex].Doctors = selectedDoctors;
                    ApplicationView.Polyclinics[SelectedIndex].Patients = selectedPatients;
                    ApplicationView.Polyclinics[SelectedIndex].Staffs = selectedStaffs;
                    MessageBox.Show("Поликлиника была успешно изменена");
                }
            }
            else
            {
                polyc.Doctors = selectedDoctors;
                polyc.Patients = selectedPatients;
                polyc.Staffs = selectedStaffs;
                ApplicationView.Polyclinics.Add(polyc);
                MessageBox.Show("Поликлиника была успешно добавлена");
            }

            var polycs = new ObservableCollection<Polyclinic>(ApplicationView.Polyclinics);
            ApplicationView.Polyclinics.Clear();
            foreach (var p in polycs)
            {
                ApplicationView.Polyclinics.Add(p);
            }

            Close();
        }
    }
}
