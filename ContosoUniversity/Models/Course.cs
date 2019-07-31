using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//ask about this one not sure what is it for.
        // figure out what this one for is database generataed attribite none paramenter on the course ID
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5)]// i think thisd one for credit do you get 0 1 2 3 4 not more than 4 and less than 0
        public int Credits { get; set; }

        public int DepartmentID { get; set; }

        public Department Department { get; set; } // not sure what class this one yet
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}
