using System;
using System.Collections.Generic;
using System.Linq;
using TeachingSchedule.Models;
using TeachingSchedule.Repository;

namespace TeachingSchedule.Services
{
    public class TeacherService
    {
        private readonly TeacherRepository _teacherRepository;
        private readonly CourseService _courseService;

        public TeacherService(CourseService courseService, Seed seed)
        {
            _courseService = courseService;
            _teacherRepository = new TeacherRepository(seed);
        }

        public void AssignCoursesToTeacher(int id)
        {
            var teacher = _teacherRepository.GetTeacherById(id);

            teacher.Courses = new List<Course>();
            teacher.Courses.AddRange(_courseService.GetCoursesByTeacherId(id));
        }

        public void ComputeTeacherCoursesSchedules(int id)
        {
            var teacher = _teacherRepository.GetTeacherById(id);
            if (teacher.Courses.Any())
            {
                foreach (var course in teacher.Courses)
                {
                    _courseService.ComputeCourseSchedule(id);
                }
            }
            else
            {
                throw new Exception("Teacher is not assigned to teach any course.");
            }
        }

        public void CreateTeacherScheduleFile(int id)
        {
            var teacher = _teacherRepository.GetTeacherById(id);
            using (var file = new System.IO.StreamWriter(string.Format("C:\\Users\\albrinza\\OneDrive - ENDAVA\\Desktop\\Teaching\\TeacherSchedule_{0}_{1}_{2}.txt", teacher.FirstName, teacher.LastName, DateTime.Now.Year)))
            {
                foreach (var course in teacher.Courses)
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
