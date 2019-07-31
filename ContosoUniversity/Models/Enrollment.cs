using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public enum Grade // enum start from 0 so A is value of 0 and F is value of 4 and you can re assign it like A = 0 in java
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")] // if it is null it will say no grade
        public Grade? Grade { get; set; } // ? special key in C# so the value can be null

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}