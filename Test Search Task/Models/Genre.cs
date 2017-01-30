using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Test_Search_Task.Models
{
    public class Genre
    {
        public int ID { get; set; }

        public string Description { get; set; }
    }

    public class GenreDBContext : DbContext
    {
        public DbSet<Genre> GenreTypes { get; set; }
    }
}