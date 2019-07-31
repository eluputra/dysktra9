using System;
using System.ComponentModel.DataAnnotations;

// adding new class base on what it requested but not sure yet what it does maybe it just creating view model?

namespace ContosoUniversity.Models.SchoolViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int StudentCount { get; set; }
    }
}