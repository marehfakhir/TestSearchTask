namespace Test_Search_Task.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestSearchTask.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestSearchTask.Models.MovieDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TestSearchTask.Models.MovieDBContext";
        }

        protected override void Seed(TestSearchTask.Models.MovieDBContext context)
        {
            context.Movies.AddOrUpdate(i => i.Title,
        new Movie
        {
            Title = "When Harry Met Sally",
            ReleaseDate = DateTime.Parse("1989-1-11"),
            Genre = "Romantic Comedy",
            NewReleaseComingSoon = DateTime.Parse("2017-1-11"),
            NewReleaseWithinPastMonth = DateTime.Parse("2016-3-11"),
            Price = 7.99M
        },

         new Movie
         {
             Title = "Ghostbusters ",
             ReleaseDate = DateTime.Parse("1984-3-13"),
             Genre = "Comedy",
             NewReleaseComingSoon = DateTime.Parse("2017-1-11"),
             NewReleaseWithinPastMonth = DateTime.Parse("2016-3-11"),
             Price = 8.99M
         },

         new Movie
         {
             Title = "Ghostbusters 2",
             ReleaseDate = DateTime.Parse("1986-2-23"),
             Genre = "Comedy",
             NewReleaseComingSoon = DateTime.Parse("2017-1-11"),
             NewReleaseWithinPastMonth = DateTime.Parse("2016-3-11"),
             Price = 9.99M
         },

       new Movie
       {
           Title = "Rio Bravo",
           ReleaseDate = DateTime.Parse("1959-4-15"),
           Genre = "Western",
           NewReleaseComingSoon = DateTime.Parse("2017-1-11"),
           NewReleaseWithinPastMonth = DateTime.Parse("2016-3-11"),
           Price = 3.99M
       }
   );
   
        }
    }
}
