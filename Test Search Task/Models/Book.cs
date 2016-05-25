using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using TestSearchTask.Validation;
using System.Web.Mvc;
using System.Collections.Generic;

namespace TestSearchTask.Models
{
    public class Book
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "New Release: Coming Soon")]
        [DataType(DataType.Date)]
        [CheckFutureDate]
        public DateTime NewReleaseComingSoon { get; set; }

        [Display(Name = "New Release: Last 30 Days")]
        [DataType(DataType.Date)]
        public DateTime NewReleaseWithinPastMonth { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        [UIHint("BookPicker")]
        public string Genre { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        
    }

    public class BookDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}