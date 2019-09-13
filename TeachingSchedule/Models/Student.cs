using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeachingSchedule.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50, ErrorMessage = "First name is too big")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(50, ErrorMessage = "Last name is too big")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime BirthDate { get; set; }

        [RegularExpression(@"[F]|[M]")]
        public char Gender { get; set; }

        public bool IsEnrolled { get; set; }

        public List<Course> Courses { get; set; }
    }
}
