using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    // office assignment created for instructor class
    public class OfficeAssignment
    {
        [Key] // one to zero or one realitionship between the instructior and office assignment this mean that office assignment only exist in relation to the instructor its assigned to 
        public int InstructorID { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
}