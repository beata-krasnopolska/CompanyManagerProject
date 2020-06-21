using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyManager.DAL.Entities
{
    public class Post
    {
        [Index("Posts", 1)]
        public int Id { get; set; }

        [Index("Posts", 2)]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}
