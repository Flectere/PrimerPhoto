using ParikMaster.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static List<Person> persons { get; set; }
        public static List<Gender> genders { get; set; }
        public MainPage()
        {
            InitializeComponent();
            genders = new List<Gender>(DbConnection.Entity.Gender.ToList());
            persons = new List<Person>(DbConnection.Entity.Person.ToList());
            this.DataContext = this; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegClient());
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ClientsList.ItemsSource = persons.Where(i =>i.Name.StartsWith(SearchTb.Text) || 
            i.Surname.StartsWith(SearchTb.Text)||
            i.Patronomyc.StartsWith(SearchTb.Text) && i.Gender==GenderCb.SelectedItem).ToList();
        }

        private void GenderCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClientsList.ItemsSource = persons.Where(i => i.Gender==GenderCb.SelectedItem).ToList();
        }
    }
}
