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
using System.Configuration;
using CompanyManager.DAL.Repository;
using CompanyManager.DAL.Entities;

namespace CompanyManagerProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PersonService _personService = new PersonService();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        public void ShowPerson()
        {
            MainDataGrid.ItemsSource = _personService.GetPersons();
        }

            private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            
            var person = new Person()
            {
                Name = TxtName.Text,
                Surname = TxtSurname.Text,
                //Post = 
            };
            _personService.InsertPerson(person);
            MainDataGrid.ItemsSource = _personService.GetPersons();
        }

        private void ListPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var person = MainDataGrid.SelectedItem as Person;

            if (person == null)
            {
                return;
            }

            if (person != null)
            {
                TxtName.Text = person.Name;
                TxtSurname.Text = person.Surname;
                //TxtPost.Text = person.Post.PostName;
            }
        }

        private void BtnUpdatePerson_Click(object sender, RoutedEventArgs e)
        {
            var person = MainDataGrid.SelectedItem as Person;

            if (person == null)
            {
                MessageBox.Show("Person must be selected before update!");
                return;
            }

            if (person != null)
            {
                person.Name = TxtName.Text;
                person.Surname = TxtSurname.Text;

                //var post = dataContext.Posts.FirstOrDefault();
                //person.Post = post;
            }
            _personService.UpdatePerson(person);
        }

        private void BtnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            var person = MainDataGrid.SelectedItem as Person;

            if (person == null)
            {
                MessageBox.Show("Person must be selected before delete!");
                return;
            }

            if (person != null)
            {
                _personService.DeletePerson(person.Id);

                TxtName.Text = string.Empty;
                TxtSurname.Text = string.Empty;
                TxtPost.Text = string.Empty;
            }
        }
    }
}
