using System;
using System.Collections.Generic;

namespace TeachingSchedule.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Teacher Teacher { get; set; }

        public int NumberOfCoursesPerYear { get; set; }

        public int FrequencyInDays { get; set; }

        public List<DateTime> CourseSchedule { get; set; }
    }
}
