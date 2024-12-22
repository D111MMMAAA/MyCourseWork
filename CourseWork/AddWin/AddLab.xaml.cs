using CourseWork.Pages;
using ScottPlot.Palettes;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    public partial class AddLab : Window
    {
        bool isListHosp = true;
        bool isListPolic = true;
        bool isAdd = false;
        public int SelectedIndex {get; set;}
        public AddLab(string str)
        {
            InitializeComponent();
            if (str == "Add")
            {
                isAdd = true;
                but_add_edit.Content = "Добавить";
            }
            else
            {
                SelectedIndex = ApplicationView.Labs.IndexOf(LabPage.selectLab);
                foreach (var hopital in ApplicationView.Labs[SelectedIndex].Hospitals)
                    HospList.SelectedItems.Add(hopital);
                foreach (var polyclinic in ApplicationView.Labs[SelectedIndex].Policlinics)
                    PolycList.SelectedItems.Add(polyclinic);
            }
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            char[] delimiters = new char[] { '-', ' ' , '.', ',', '(', ')', '{', '}', '@', '#', '$', '%', '^', '<', '>', '?', '&', '*', '!', '+', '=', ':', ';', '\'', '\"', '/', '\\', '[', ']', '+' };

            string[] profiles = ProfText.Text
                    .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                    .Select(word => word.Trim())
                    .Where(word => !string.IsNullOrEmpty(word)) 
                    .Select(word => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.ToLower()))
                    .ToArray();

            var selectedHospitals = HospList.SelectedItems.Cast<Hospital>().ToList();
            var selectedPolyclinics = PolycList.SelectedItems.Cast<Polyclinic>().ToList();

            if (ProfText.Text == "" || NameText.Text == "" || selectedHospitals.Count == 0 || selectedPolyclinics.Count ==0)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            var listProf = new List<string>();
                
            for (int i = 0; i < profiles.Length; i++)
            {
                listProf.Add(profiles[i]);
            }

            if (!isAdd)
            {
                if (SelectedIndex >= 0)
                {
                    ApplicationView.Labs[SelectedIndex].Name = NameText.Text.Trim(); 
                    ApplicationView.Labs[SelectedIndex].Profiles = listProf; 
                    ApplicationView.Labs[SelectedIndex].Hospitals = selectedHospitals;
                    ApplicationView.Labs[SelectedIndex].Policlinics = selectedPolyclinics;
                    MessageBox.Show("Лаборатория была успешно изменина");
                }
            }
            else
            {
                ApplicationView.Labs.Add(new Laboratory(NameText.Text.Trim(), listProf, selectedHospitals, selectedPolyclinics));
                MessageBox.Show("Лаборатория была успешно добавлена");
            }
            Close();
        }
    }
}
