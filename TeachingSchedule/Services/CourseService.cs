using System;
using System.Collections.Generic;
using TeachingSchedule.Models;

namespace TeachingSchedule.Services
{
    public class CourseService
    {
        public CourseService() { }

        public void ComputeCourseSchedule(Course course)
        {
            var firstDay = new DateTime(2019, 10, 01);
            course.CourseSchedule = new List<DateTime>();

            for (var i = 0; i < course.NumberOfCoursesPerYear; i++)
            {
                course.CourseSchedule.Add(firstDay);
                firstDay = firstDay.AddDays(course.FrequencyInDays);
            }
        }


    }
}
