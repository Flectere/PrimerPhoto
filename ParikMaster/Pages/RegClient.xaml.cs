using Microsoft.Win32;
using ParikMaster.DB;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
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

namespace ParikMaster.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegClient.xaml
    /// </summary>
    public partial class RegClient : Page
    {
        public static List<Gender> genders { get; set; }
        public static List<Person> persons { get; set; }
        public Person person = new Person();
        public RegClient()
        {
            InitializeComponent();
            genders = new List<Gender>(DB.DbConnection.Entity.Gender.ToList());
            
            this.DataContext = this;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            person.Gender = GenderCb.SelectedItem as Gender;
            person.Name = NameTb.Text.Trim();
            person.Surname = SurnameTb.Text.Trim();
            person.Patronomyc = PatronomycTb.Text.Trim();
            person.BirthDate = BirthDateDp.SelectedDate;
            person.Login = LoginTb.Text.Trim();
            person.Password = PasswordTb.Text.Trim();

            DB.DbConnection.Entity.Person.Add(person);
            DB.DbConnection.Entity.SaveChanges();
            NavigationService.Navigate(new MainPage());
        }

        private void AddImg_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*jpeg|*jpeg|*jpg|*jpg"
            };
            if(openFile.ShowDialog().GetValueOrDefault()) 
            {
                person.Photo = File.ReadAllBytes(openFile.FileName);
                UserImg.Source = new BitmapImage(new Uri(openFile.FileName));
            }
            

        }
    }
}