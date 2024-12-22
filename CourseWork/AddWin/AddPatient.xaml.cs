using CourseWork.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// <summary>
    /// Логика взаимодействия для AddPatient.xaml
    /// </summary>
    public partial class AddPatient : Window
    {
        public ObservableCollection<Doctor> Alldoctors;
        bool isAdd = false;
        public AddPatient(string str)
        {
            InitializeComponent();
            WriteTable();
            if (str == "Add")
            {
                isAdd = true;
                but_add_edit.Content = "Добавить";
            }
        }
        public void WriteTable()
        {
            Alldoctors = new();
            for (int i = 0; i < ApplicationView.MedInst.Count; i++)
            {
                for (int j = 0; j < ApplicationView.MedInst[i].Doctors.Count; j++)
                {
                    Alldoctors.Add(ApplicationView.MedInst[i].Doctors[j]);
                }
            }
            DoctText.ItemsSource = Alldoctors;
            
        }
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            if(NameText.Text == "" || MedIstText.Text == ""
                || PalatText.Text == "" || DataText.Text == ""
                || CondText.Text == "" || TempText.Text == ""
                || DoctText.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            foreach (char c in TempText.Text)
            {
                if ((c < '0' || c > '9') && (c != ','))
                {
                    MessageBox.Show("Не корекктная температура");
                    return;
                }
            }


            var medInst = MedIstText.SelectedItem as MedicalInstitution;
            var doct = DoctText.SelectedItem as Doctor;

            if (isAdd)
            {
                if (medInst.GetType() == typeof(Hospital))
                {
                    var index = ApplicationView.Hospitals.IndexOf((Hospital)medInst);
                    ApplicationView.Hospitals[index].AddPatient(new Patient(NameText.Text, PalatText.Text,
                    (DateTime)DataText.SelectedDate, CondText.Text,
                    Convert.ToDouble(TempText.Text), doct));
                }
                else if (medInst.GetType() == typeof(Polyclinic))
                {
                    var index = ApplicationView.Polyclinics.IndexOf((Polyclinic)medInst);
                    ApplicationView.Polyclinics[index].AddPatient(new Patient(NameText.Text, PalatText.Text,
                    (DateTime)DataText.SelectedDate, CondText.Text,
                    Convert.ToDouble(TempText.Text), doct));
                }
                MessageBox.Show("Пациент был успешно добавлен");
            }
            else
            {
                PatientPage.selecPat.Name = NameText.Text;

                PatientPage.selecPat.Name = NameText.Text;
                PatientPage.selecPat.Position = PalatText.Text;
                PatientPage.selecPat.AdmissionDate = (DateTime)DataText.SelectedDate;
                PatientPage.selecPat.Condition = CondText.Text;
                PatientPage.selecPat.Temperature = Convert.ToDouble(TempText.Text);
                PatientPage.selecPat.AttendingDoctor = (Doctor)DoctText.SelectedItem;


                if (PatientPage.buf_med != MedIstText.SelectedItem)
                {
                    PatientPage.buf_med.Patients.Remove(PatientPage.selecPat);
                    if (medInst.GetType() == typeof(Hospital))
                    {
                        var medInstIndex = ApplicationView.Hospitals.IndexOf((Hospital)MedIstText.SelectedItem);
                        ApplicationView.Hospitals[medInstIndex].AddPatient(PatientPage.selecPat);
                    }
                    else if (medInst.GetType() == typeof(Polyclinic))
                    {
                        var medInstIndex = ApplicationView.Polyclinics.IndexOf((Polyclinic)MedIstText.SelectedItem);
                        ApplicationView.Polyclinics[medInstIndex].AddPatient(PatientPage.selecPat);
                    }
                }
                MessageBox.Show("Пациент был успешно изменен");
            }
            Close();
        }
    }
}
