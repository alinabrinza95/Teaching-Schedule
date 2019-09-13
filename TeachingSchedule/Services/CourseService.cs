using System;
using System.Collections.Generic;
using TeachingSchedule.Repository;

namespace TeachingSchedule.Services
{
    public class CourseService
    {
        private readonly CourseRepository _courseRepository;

        public CourseService(Seed _seed)
        {
            _courseRepository = new CourseRepository(_seed);
        }

        public void ComputeCourseSchedule(int id)
        {
            var course = _courseRepository.GetCourseById(id);
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
