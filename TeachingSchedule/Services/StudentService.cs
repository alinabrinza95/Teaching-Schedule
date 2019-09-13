using System;
using System.Collections.Generic;
using TeachingSchedule.Repository;

namespace TeachingSchedule.Services
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;
        private readonly CourseService _courseService;
        private const int MinimumCoursesToAttend = 3;

        public StudentService(CourseService courseService, Seed seed)
        {
            _courseService = courseService;
            _studentRepository = new StudentRepository(seed);
        }

        public void AssignCoursesToStudent(int id, List<int> courseIds)
        {
            var student = _studentRepository.GetStudentById(id);

            student.Courses = _courseService.GetCoursesByIds(courseIds);
        }

        public void SetStudentEnrollment(int id)
        {
            var student = _studentRepository.GetStudentById(id);

            student.IsEnrolled = student.Courses.Count >= MinimumCoursesToAttend;
        }

        public bool IsStudentEnrolled(int id)
        {
            var student = _studentRepository.GetStudentById(id);

            return student.IsEnrolled;
        }

        public void ComputeStudentCoursesSchedules(int id)
        {
            var student = _studentRepository.GetStudentById(id);
            foreach (var course in student.Courses)
            {
                _courseService.ComputeCourseSchedule(id);
            }
        }

        public void CreateStudentScheduleFile(int id, string path)
        {
            var student = _studentRepository.GetStudentById(id);
            using (var file = new System.IO.StreamWriter(path))
            {
                foreach (var course in student.Courses)
                {
                    file.WriteLine(course.Name + "\n");
                    foreach (var courseSchedule in course.CourseSchedule)
                    {
                        file.WriteLine(courseSchedule.Date);
                    }
                }
            }
        }

    }
}
