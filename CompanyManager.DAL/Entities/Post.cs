using System.Collections.Generic;

namespace CompanyManager.DAL.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}
