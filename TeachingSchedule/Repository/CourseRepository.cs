using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeachingSchedule.Models;

namespace TeachingSchedule.Repository
{
    public class CourseRepository
    {
        private readonly Seed _seed;

        public CourseRepository()
        {
            _seed = new Seed();
        }

        public Course GetCourseById(int id)
        {
            return _seed.Courses.FirstOrDefault(s => s.Id.Equals(id));
        }

        public List<Course> GetCoursesByTeacherId(int teacherId)
        {
            return _seed.Courses.Where(c => c.Teacher.Id.Equals(teacherId)).ToList();
        }

        public List<Course> GetAllCourses()
        {
            return _seed.Courses;
        }
    }
}
