using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager.DAL.Entities
{
    public class Person
    {
        public int Id { get; set; }        

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public Post PostId { get; set; }
    }
}
