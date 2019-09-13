using System;
using System.Linq;
using TeachingSchedule.Models;

namespace TeachingSchedule.Services
{
    public class TeacherService
    {
        private readonly CourseService _courseService;

        public TeacherService(CourseService courseService)
        {
            _courseService = courseService;
        }

        public void ComputeTeacherCoursesSchedules(Teacher teacher)
        {
            if (teacher.Courses.Any())
            {
                foreach (var course in teacher.Courses)
                {
                    _courseService.ComputeCourseSchedule(course);
                }
            }
            else
            {
                throw new Exception("Teacher is not assigned to teach any course.");
            }
        }

        public void CreateTeacherScheduleFile(Teacher teacher)
        {
            using (var file = new System.IO.StreamWriter(@"C:\Users\albrinza\OneDrive - ENDAVA\Desktop\Teaching\StudentSchedule.txt"))
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
