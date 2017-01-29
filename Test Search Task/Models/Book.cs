using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using TestSearchTask.Validation;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using Test_Search_Task.Models;
using Test_Search_Task.Validation;

namespace TestSearchTask.Models
{
    public class Book : BaseViewModel
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }

      //  [DefaultValue("12/31/9999")]
        [Display(Name = "New Release: Coming Soon")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [CheckFutureDate]
        public DateTime? NewReleaseComingSoon { get; set; }

      //  [DefaultValue("01/14/2017")]
        [Display(Name = "New Release: Last 30 Days")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [CheckPastDate]
        public DateTime? NewReleaseWithinPastMonth { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        [UIHint("BookPicker")]
        public string Genre { get; set; }

        public IEnumerable<string> GenreList;

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [DefaultValue(5)]
        public decimal Price { get; set; }
        
    }

    public class BookDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}