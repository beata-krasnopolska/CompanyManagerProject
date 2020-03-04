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
using CompanyManager.DAL;

namespace CompanyManagerProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["CompanyManagerProject.Properties.Settings.CompanyManagerConnectionString"].ConnectionString;
            //dataContext = 
        }

        public void InsertPerson()
        {
            //var manager = dataContext.Posts.First(p => p.PostName == "Manager");
            //var assistant = dataContext.Posts.First(p => p.PostName == "Assistant");

            InsertPerson(); // metoda z PersonService

            //dataContext.Persons.InsertAllOnSubmit(people);
            //dataContext.SubmitChanges();
            //MainDataGrid.ItemsSource = dataContext.Persons.Select(x => new Entity.Person
            //{
            //    Id = x.Id,
            //    Gender = x.Gender,
            //    PostId = x.PostId,
            //    Name = x.PersonName
            //}).ToList();
        }
    }
}
