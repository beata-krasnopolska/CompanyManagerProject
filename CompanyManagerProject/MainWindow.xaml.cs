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
            if (TxtName.Text == string.Empty || TxtSurname.Text == string.Empty || TxtPost.Text == string.Empty)
            {
                MessageBox.Show(Messages.PersonAddError);
                return;
            }

            var person = new Person()
            {
                FirstName = TxtName.Text,
                Surname = TxtSurname.Text,
                PostId = int.Parse(TxtPost.Text),
                PhoneNo = int.Parse(TxtPhoneNumber.Text),
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
                        
            TxtName.Text = person.FirstName;
            TxtSurname.Text = person.Surname;
            TxtPost.Text = person.PostId.ToString();
            TxtPhoneNumber.Text = person.PhoneNo.ToString();
        }

        private void BtnUpdatePerson_Click(object sender, RoutedEventArgs e)
        {

            if (!(MainDataGrid.SelectedItem is Person person))
            {
                MessageBox.Show(Messages.PersonUpdateError);
                return;
            }
            
            person.FirstName = TxtName.Text;
            person.Surname = TxtSurname.Text;
            person.PostId = int.Parse(TxtPost.Text);
            person.PhoneNo = int.Parse(TxtPhoneNumber.Text);

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

            if (!(MainDataGrid.SelectedItem is Person person))
            {
                MessageBox.Show(Messages.PersonDeleteError);
                return;
            }
                        
            try
            {
                _personService.DeletePerson(person.Id);
                TxtName.Text = string.Empty;
                TxtSurname.Text = string.Empty;
                TxtPost.Text = string.Empty;
                TxtPhoneNumber.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            InitializeGrid();
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

        private void BtnSendSMS_Click(object sender, RoutedEventArgs e)
        {
            var addSendSmsDialog = new SendSMS_Dialog();
            addSendSmsDialog.ShowDialog();
        }
    }
}
