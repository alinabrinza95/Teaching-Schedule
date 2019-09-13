using System;
using System.Collections.Generic;

namespace TeachingSchedule.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public char Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public List<Course> Courses { get; set; }
    }
}
