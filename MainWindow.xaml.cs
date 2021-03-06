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




namespace Экзамен_ИСРПО__5_вар_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Объявляем БД 
        ISRPOexamEntities db = new ISRPOexamEntities();
        Employees employees;


        public MainWindow()
        {
            InitializeComponent();
            employees = new Employees();
        }

        public MainWindow(Employees employees) 
        {
            InitializeComponent();
            this.employees = employees;
            // Объявляем наши textbox и связываем с БД
            TBFirtName.Text = this.employees.FirtName.ToString();
            TBSecondName.Text = this.employees.SecondName.ToString();
            TBMiddleName.Text = this.employees.MiddleName.ToString();
            TBDolznost.Text = this.employees.Position.ToString();


        }



        // Кнопка "Подтвердить"
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            
            //Условия сохранения 
            if (employees.IDEmployee == 0)
            {
                Employees dishes = new Employees()
                {   
                //Конвертирование 
                    FirtName = Convert.ToString(TBFirtName.Text),
                    SecondName = Convert.ToString(TBSecondName.Text),
                    MiddleName = Convert.ToString(TBMiddleName.Text),
                    Position = Convert.ToString(TBDolznost.Text),

                };
                
                //Добавление данных в БД и сохранение данных
                db.Employees.Add(employees);
                db.SaveChanges();
                
                MessageBox.Show("Сотрудник успешно добавлен");

            }
        }
    }
}
