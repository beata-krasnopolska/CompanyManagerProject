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
using System.Windows.Shapes;
using CompanyManager.DAL.Repository;

namespace CompanyManagerProject
{
    /// <summary>
    /// Interaction logic for SearchPerson_Dialog.xaml
    /// </summary>
    public partial class SearchPerson_Dialog : Window
    {
        private readonly PersonService _personService = new PersonService();

        public SearchPerson_Dialog()
        {
            InitializeComponent();
        }

        private void SearchPersonButton_Dialog(object sender, RoutedEventArgs e)
        {
            try
            {
                var person = _personService.GetPersonByID(int.Parse(TxtId.Text));
                TxtName.Text = person.FirstName;
                TxtSurname.Text = person.Surname;
                //TxtPost = person.PostName;
                TxtId.Text = person.Id.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("The person does not exist in the datatbase");
            }
        }
    }
}
