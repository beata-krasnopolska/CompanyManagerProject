using CompanyManager.DAL.Entities;
using CompanyManager.DAL.Repository;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace CompanyManagerProject
{
    public partial class MainWindow : Window
    {
        private readonly PersonService _personService = new PersonService();
        private readonly PostService _postService = new PostService();

        public MainWindow()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            var persons = _personService.GetPersons();
            var personsViewModel = persons.Select(x => new PersonViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                Surname = x.Surname,
                PostName = x.Post?.Name ?? string.Empty,
                PhoneNo = x?.PhoneNo ?? 0,
            }).ToList();
            MainDataGrid.ItemsSource = personsViewModel;
            //MainDataGrid.ItemsSource = _personService.GetPersons();
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
            if (!(MainDataGrid.SelectedItem is PersonViewModel personViewModel))
            {
                return;
            }

            TxtName.Text = personViewModel.FirstName;
            TxtSurname.Text = personViewModel.Surname;
            TxtPost.Text = personViewModel.PostName;
            TxtPhoneNumber.Text = personViewModel.PhoneNo.ToString();

            //TxtName.Text = person.FirstName;
            //TxtSurname.Text = person.Surname;
            //TxtPost.Text = person.PostId.ToString();
            //TxtPhoneNumber.Text = person.PhoneNo.ToString();
        }

        private void BtnUpdatePerson_Click(object sender, RoutedEventArgs e)
        {

            if (!(MainDataGrid.SelectedItem is PersonViewModel personViewModel))
            {
                MessageBox.Show(Messages.PersonUpdateError);
                return;
            }

            personViewModel.FirstName = TxtName.Text;
            personViewModel.Surname = TxtSurname.Text;
            personViewModel.PostName = TxtPost.Text;
            personViewModel.PhoneNo = int.Parse(TxtPhoneNumber.Text);

            var person = new Person()
            {
                FirstName = personViewModel.FirstName,
                Surname = personViewModel.Surname,
                PostId = (_postService.GetPostByName(personViewModel.PostName)).Id,
                //PostId = int.Parse(TxtPost.Text),
                PhoneNo = personViewModel.PhoneNo,
            };

            //person.FirstName = TxtName.Text;
            //person.Surname = TxtSurname.Text;
            //person.PostId = int.Parse(TxtPost.Text);
            //person.PhoneNo = int.Parse(TxtPhoneNumber.Text);

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

            if (!(MainDataGrid.SelectedItem is PersonViewModel personViewModel))
            {
                MessageBox.Show(Messages.PersonDeleteError);
                return;
            }
                        
            try
            {
                _personService.DeletePerson(personViewModel.Id);
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
