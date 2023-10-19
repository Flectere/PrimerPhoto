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
using ParikMaster.DB;

namespace ParikMaster.Pages
{

    public partial class AuthPage : Page
    {
        public static List<Person> Persons { get; set; }
        public AuthPage()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTb.Text.Trim();
            string password = passwordTb.Password.Trim();
            Persons = new List<Person>(DbConnection.Entity.Person.ToList());
            Person currentUser = Persons.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (currentUser != null)
            {
                NavigationService.Navigate(new MainPage());
            }
        }
    }
}
