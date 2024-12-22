using CourseWork.Pages;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для AddStaffMed.xaml
    /// </summary>
    public partial class AddStaffMed : Window
    {
        bool isAdd = false;
        public AddStaffMed(string str)
        {
            InitializeComponent();
            if (str == "Add")
            {
                isAdd = true;
                but_add_edit.Content = "Добавить";
            }
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            if (NameText.Text == "" || SpecText.Text == "" || BoxMedInst.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            var medInst = BoxMedInst.SelectedItem as MedicalInstitution;


            if (isAdd)
            {
                if (medInst.GetType() == typeof(Hospital))
                {
                    var index = ApplicationView.Hospitals.IndexOf((Hospital)medInst);
                    ApplicationView.Hospitals[index].AddStaff(new SupportStaff(NameText.Text, SpecText.Text));
                }
                else if (medInst.GetType() == typeof(Polyclinic))
                {
                    var index = ApplicationView.Polyclinics.IndexOf((Polyclinic)medInst);
                    ApplicationView.Polyclinics[index].AddStaff(new SupportStaff(NameText.Text, SpecText.Text));
                }
                MessageBox.Show("Персонал был успешно добавлен");
            }
            else
            {
                StaffMed.selecStaf.Name = NameText.Text;
                StaffMed.selecStaf.Position = SpecText.Text;


                if (PatientPage.buf_med != medInst)
                {
                    PatientPage.buf_med.Patients.Remove(PatientPage.selecPat);
                    if (medInst.GetType() == typeof(Hospital))
                    {
                        var medInstIndex = ApplicationView.Hospitals.IndexOf((Hospital)medInst);
                        ApplicationView.Hospitals[medInstIndex].AddPatient(PatientPage.selecPat);
                    }
                    else if (medInst.GetType() == typeof(Polyclinic))
                    {
                        var medInstIndex = ApplicationView.Polyclinics.IndexOf((Polyclinic)medInst);
                        ApplicationView.Polyclinics[medInstIndex].AddPatient(PatientPage.selecPat);
                    }
                }
            }
            Close();
        }
    }
}
