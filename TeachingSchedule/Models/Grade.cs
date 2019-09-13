using System;

namespace TeachingSchedule.Models
{
    public class Grade
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public int GradeMark { get; set; }

        public DateTime GradeDate { get; set; }
    }
}
