﻿using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TestSearchTask.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

         [Display(Name = "Release Date")]
         [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

         [Display(Name = "New Release: Coming Soon")]
       //  [DataType(DataType.Date)]
         //// [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
         ////public string ReleaseDate2 { get; set; }
         public DateTime? NewReleaseComingSoon { get; set; }

         [Display(Name = "New Release: Last 30 Days")]
       //   [DataType(DataType.Date)]
         //// [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
         //public string ReleaseDate3 { get; set; }
         public DateTime? NewReleaseWithinPastMonth { get; set; }
        


        //  [Display(Name = "Category")]
          [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
          [Required]
          [StringLength(30)]
          public string Genre { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}