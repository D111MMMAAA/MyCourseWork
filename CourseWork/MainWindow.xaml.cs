using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWork
{
    /*
     *
     * Основное окно программы, здесь происходит переход на страницы с информацией о мед учереж, докторах и т.д.
     * Мы определили, что есть основное окно программы (MainWindow), где располагаються страницы с инфой (Page) 
     * 
     * Так же здесь задаються имена файлов, куда будут сохраняться данные
     */
    public partial class MainWindow : Window
    {
        //имена файлов для сохранения данных
        string nameHopital = "Save\\data_hosp.json";
        string namePoliclinic = "Save\\data_polic.json";
        string nameLab = "Save\\data_lab.json";

        //создаем нашу ViewModel, где инициализируються и храняться данные
        static public ApplicationView applicationView { get; set; }

        public MainWindow()
        {
            //Инициализируем окно программы
            InitializeComponent();
            //Инициализируем обект, от куда и будем брать данные 
            applicationView = new();
            //определяем наш контекст данных (условно - биндим обект с данными к окну с WPF)
            DataContext = applicationView;
        }

        //При нажатии на Главная, отрабатываеться эта функция
        private void Main_Page(object sender, MouseButtonEventArgs e)
        {
            //Переходим на Главную страницу
            frame.Navigate(new Pages.MainPage()
            {
                //Определяем такой же контекст, как и в главнном окне
                DataContext = applicationView
            });
        }

        private void Hospitals_Page(object sender, MouseButtonEventArgs e)
        {
            //Переходим на страницу с Больницами
            frame.Navigate(new Pages.HospitalsPage()
            {
                DataContext = applicationView
            });
        }

        private void Policlinics_Page(object sender, MouseButtonEventArgs e)
        {
            //Переходим на страницу с Поликлиниками
            frame.Navigate(new Pages.PoliclinicsPage()
            {
                DataContext = applicationView
            });
        }

        private void Doctors_Page(object sender, MouseButtonEventArgs e)
        {
            //Переходим на страницу с Докторами
            frame.Navigate(new Pages.Doctors() 
            { 
                DataContext = applicationView 
            });
        }

        private void Staff_Page(object sender, MouseButtonEventArgs e)
        {
            //Переходим на страницу с Рабочим персоналом
            frame.Navigate(new Pages.StaffMed()
            {
                DataContext = applicationView
            });
        }

        private void Patient_Page(object sender, MouseButtonEventArgs e)
        {
            //Переходим на страницу с Пациентами
            frame.Navigate(new Pages.PatientPage()
            {
                DataContext = applicationView
            });
        }

        private void Labs_Page(object sender, MouseButtonEventArgs e)
        {
            //Переходим на страницу с Лабораториями
            frame.Navigate(new Pages.LabPage()
            {
                DataContext = applicationView
            });
        }

        //Метод для сохранения данных в JSON
        private void SaveToJSON(object sender, RoutedEventArgs e)
        {
            //Есть отдельный класс, где описана логика работы с JSON
            SerJSON ser = new();
            //Вызываем метод для сохранения данных, передавая туда имена файлов
            ser.SaveData();
            MessageBox.Show("Данные сохранены");
        }
        /*
         *Дальше идут методы, которые вызываються при нажатии на справку и помощь
         */
        private void Click_Hospital_Info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Перейдя на вкладку Медучереждения -> Больницы вы сможете увидеть информацию о больницах");
        }

        private void Click_Policlinic_Info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Перейдя на вкладку Медучереждения -> Поликлиники вы сможете увидеть информацию о поликлиниках");

        }

        private void Click_Personal_Info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Перейдя на вкладку Персонал -> Обслуживающий персонал вы сможете увидеть информацию об обслуживающем персонале");

        }

        private void Click_Patient_Info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Перейдя на вкладку Пациенты вы сможете увидеть информацию о пациентах");

        }

        private void Click_Labs_Info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Перейдя на вкладку Медучереждения -> Лаборатории вы сможете увидеть информацию о лабораториях");

        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Программа разработана для ознокомления с медецинскими учереждениями города" +
                "\nВ данной программе есть несколько вкладок, где вы сможете более подробно ознакомиться с ифнормацией о больницах, поликлиниках, пациентах и др.");
        }
        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}