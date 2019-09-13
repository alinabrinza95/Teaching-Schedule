using System;
using System.Collections.Generic;
using TeachingSchedule.Models;
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

        public List<Course> GetCoursesById(List<int> courseIds)
        {
            return _courseRepository.GetCoursesByIds(courseIds);
        }

        public List<Course> GetCoursesByTeacherId(int teacherId)
        {
            return _courseRepository.GetCoursesByTeacherId(teacherId);
        }

        public List<Course> GetCoursesByIds(List<int> coursesIds)
        {
            return _courseRepository.GetCoursesByIds(coursesIds);
        }

        public List<DateTime> ComputeCourseSchedule(int id)
        {
            var course = _courseRepository.GetCourseById(id);
            var firstDay = new DateTime(2019, 10, 01);

            course.CourseSchedule = new List<DateTime>();

            for (var i = 0; i < course.NumberOfCoursesPerYear; i++)
            {
                course.CourseSchedule.Add(firstDay);
                firstDay = firstDay.AddDays(course.FrequencyInDays);
            }

            return course.CourseSchedule;
        }


    }
}
