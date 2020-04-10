using CompanyManager.DAL.Repository;
using System;
using System.Windows;

namespace CompanyManagerProject
{
    public partial class SearchPerson_Dialog : Window
    {
        private readonly PersonService _personService = new PersonService();

        public SearchPerson_Dialog()
        {
            InitializeComponent();
        }

        private void SearchPersonButton_Dialog(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text == string.Empty)
            {
                MessageBox.Show(Messages.PersonSearchNoIdError);
                return;
            }

            var person = _personService.GetPersonById(int.Parse(TxtId.Text));

            if (person == null)
            {
                MessageBox.Show(Messages.PersonSearchError);
                return;
            }

            try
            {
                TxtName.Text = person.FirstName;
                TxtSurname.Text = person.Surname;
                TxtId.Text = person.Id.ToString();
                TxtPost.Text = person.PostId.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
