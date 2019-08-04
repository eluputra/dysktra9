using System;
using System.Collections.Generic; //just like java collection generic class
using System.ComponentModel.DataAnnotations;// adding the dataannotations 
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Student : Person // update the student it is inheritance of person
    {
        public int ID { get; set; }
        [Required] // this one indicate have to have id like in html css required function
        [StringLength(50)] // maximum length that user can put
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]// maximum number of length of the name
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")] this code is for forcing user to put first character in upercase
        [Column("FirstName")] // curently i dont really get it what this one does but "the data will come from or be updated in the FirstName column of the Student table."
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]// name space  and adding data type
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  // formating the display format base on year month and date
        [Display(Name = "Enrollment Date")] //displaying enrollment date
        public DateTime EnrollmentDate { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {// i think this one like a to string function in java
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}