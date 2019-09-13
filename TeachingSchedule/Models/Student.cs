using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeachingSchedule.Models
{
    public class Student
    {
        [RegularExpression(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", ErrorMessage = "Guid is invalid")]
        public Guid Guid { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50, ErrorMessage = "First name is too big")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(50, ErrorMessage = "Last name is too big")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime BirthDate { get; set; }

        [RegularExpression(@"[F]|[M]")]
        public char Sex { get; set; }

        public bool IsEnrolled { get; set; }

        public List<Course> Courses { get; set; }
    }
}
