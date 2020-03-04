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

        public int PostId { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
