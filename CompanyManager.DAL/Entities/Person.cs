﻿namespace CompanyManager.DAL.Entities
{
    public class Person
    {
        public int Id { get; set; }        

        public string FirstName { get; set; }

        public string Surname { get; set; }

        //Foreign key for Post:

        public int? PostId { get; set; }

        public Post Post { get; set; }
    }
}
