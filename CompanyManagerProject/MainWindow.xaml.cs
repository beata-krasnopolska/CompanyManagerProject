using CompanyManager.DAL.Entities;
using CompanyManager.DAL.Repository;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CompanyManagerProject
{
    public partial class MainWindow : Window
    {
        private readonly PersonService _personService = new PersonService();

        public MainWindow()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            MainDataGrid.ItemsSource = _personService.GetPersons();
        }

        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            var person = new Person()
            {
                FirstName = TxtName.Text,
                Surname = TxtSurname.Text,
                //PostId = int.Parse(TxtPost.Text),
                //wpisać liczbę z tabeli jak już będę miałą zdefiniowane
            };

            try
            {
                _personService.InsertPerson(person);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            InitializeGrid();
        }

        private void ListPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(MainDataGrid.SelectedItem is Person person))
            {
                return;
            }

            if (person != null)
            {
                TxtName.Text = person.FirstName;
                TxtSurname.Text = person.Surname;
                TxtPost.Text = person.PostId.ToString();
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
                person.FirstName = TxtName.Text;
                person.Surname = TxtSurname.Text;
                //person.PostId = int.Parse(TxtPost.Text);
                //var post = dataContext.Posts.FirstOrDefault();
                //person.Post = post;
            }

            try
            {
                _personService.UpdatePerson(person);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            InitializeGrid();
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
                try
                {
                    _personService.DeletePerson(person.Id);
                    TxtName.Text = string.Empty;
                    TxtSurname.Text = string.Empty;
                    TxtPost.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                InitializeGrid();
            }
        }

        private void BtnSearchPerson_Click(object sender, RoutedEventArgs e)
        {
            var searchPersonDialog = new SearchPerson_Dialog();
            searchPersonDialog.ShowDialog();
        }

        private void BtnManagePosts_Click(object sender, RoutedEventArgs e)
        {
            var addPostDialod = new PostTable_Dialog();
            addPostDialod.ShowDialog();
        }
    }
}
