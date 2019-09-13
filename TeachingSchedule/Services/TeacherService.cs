using System;
using System.Linq;
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
