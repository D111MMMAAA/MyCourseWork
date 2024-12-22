using CourseWork.Pages;
using System.Data;
using System.Windows;


namespace CourseWork
{
    //Класс для Добавления Докторов
    public partial class AddDoctors : Window
    {
        //Переменная нужная для отслеживания действий (Добавление или удаление)
        public bool isAdd = false;

        public AddDoctors(string str)
        {
            InitializeComponent();
            //Задаем в выпадающие спики значения
            //Для Степени определяем enum со степенями
            BoxDegree.ItemsSource = Enum.GetValues(typeof(DoctorDegree)).Cast<DoctorDegree>();
            //Для Типа мед учрежд определяем enum с типом
            BoxWork.ItemsSource = Enum.GetValues(typeof(HospitalType)).Cast<HospitalType>();
            //если передали строку Add
            if (str == "Add")
            {
                //Тогда необходимо добавить а не изменить
                isAdd = true;
                //Также перезаписываем текст кнопки
                but_add_edit.Content = "Добавить";
            }
        }
        //Метод для добавления
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            //Если поля пустые, просим их заполнить
            if (NameText.Text == "" || SpecText.Text == ""
                || BoxDegree.Text == "" || BoxNameMedInst.Text == ""
                || BoxWork.Text == "" || BoxOperationsPerformed.Text == "" || BoxFatalOperations.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            int medInstIndex = 0;
            //Сохраняем мед учреждение которое выбрали в выпадающем спике
            var medInst = BoxNameMedInst.SelectedItem as MedicalInstitution;
            int.TryParse(BoxOperationsPerformed.Text, out int operationsPerformed);
            int.TryParse(BoxFatalOperations.Text, out int fatalOperations);
            //Если необходимо добавить
            if (isAdd)
            {
                //Сперва проверяем тип мед учрежд в котором будет работать Доктор
                if (medInst.GetType() == typeof(Hospital))
                {
                    //Находим соответстующую больницу
                    medInstIndex = ApplicationView.Hospitals.IndexOf((Hospital)BoxNameMedInst.SelectedItem);
                    //Добавляем нового доктора в найденную больницу
                    ApplicationView.Hospitals[medInstIndex].AddDoctor(new Doctor(NameText.Text,
                                                                                SpecText.Text,
                                                                                operationsPerformed,
                                                                                fatalOperations,
                                                                                (DoctorDegree)BoxDegree.SelectedIndex,
                                                                                (HospitalType)BoxWork.SelectedIndex));
                }
                else if (medInst.GetType() == typeof(Polyclinic))
                {
                    //Находим соответстующую Поликлинику
                    medInstIndex = ApplicationView.Polyclinics.IndexOf((Polyclinic)BoxNameMedInst.SelectedItem);
                    //Добавляем нового доктора в найденную Поликлинику
                    ApplicationView.Polyclinics[medInstIndex].AddDoctor(new Doctor(NameText.Text,
                                                                                SpecText.Text,
                                                                                operationsPerformed,
                                                                                fatalOperations,
                                                                                (DoctorDegree)BoxDegree.SelectedIndex,
                                                                                (HospitalType)BoxWork.SelectedIndex));

                }
                MessageBox.Show("Доктор был успешно добавлен");
            }
            //Если необходимо изменить
            else
            {
                //Передаем значения в сохраненный обект класса Страницы для Докторов
                Doctors.selecDoct.Name = NameText.Text;
                Doctors.selecDoct.Position = SpecText.Text;
                Doctors.selecDoct.OperationsPerformed = operationsPerformed;
                Doctors.selecDoct.FatalOperations = fatalOperations;
                Doctors.selecDoct.Degree = (DoctorDegree)BoxDegree.SelectedIndex;
                Doctors.selecDoct.WorkType = (HospitalType)BoxWork.SelectedIndex;

                //Если Мед учрежд не совпадают (изменили место работы)
                if (Doctors.buf_med != BoxNameMedInst.SelectedItem)
                {
                    //удаляем из прошлого Мед Учреждения
                    Doctors.buf_med.Doctors.Remove(Doctors.selecDoct);
                    //тут идет блок добавления (как показано выше)
                    if (medInst.GetType() == typeof(Hospital))
                    {
                        medInstIndex = ApplicationView.Hospitals.IndexOf((Hospital)BoxNameMedInst.SelectedItem);
                        ApplicationView.Hospitals[medInstIndex].AddDoctor(Doctors.selecDoct);
                    }
                    else if (medInst.GetType() == typeof(Polyclinic))
                    {
                        medInstIndex = ApplicationView.Polyclinics.IndexOf((Polyclinic)BoxNameMedInst.SelectedItem);
                        ApplicationView.Polyclinics[medInstIndex].AddDoctor(Doctors.selecDoct);
                    } 
                }
                MessageBox.Show("Доктор был успешно изменен");
            }
            //закрываем окно после всех проведенных операций
            Close();
        }
    }
}
