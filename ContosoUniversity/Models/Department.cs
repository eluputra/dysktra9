using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// new department class created from tutorial 5
namespace ContosoUniversity.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")] //  The CLR decimal type maps to a SQL Server decimal type. But in this case you know that the column will be holding currency amounts, and the money data type is more appropriate for that.
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        public int? InstructorID { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; } // adding time stamp that this column will be included in the Where clause of Update and Delete commands sent to the database

        public Instructor Administrator { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}