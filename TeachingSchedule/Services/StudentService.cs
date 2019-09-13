using TeachingSchedule.Models;

namespace TeachingSchedule.Services
{
    public class StudentService
    {
        private readonly CourseService _courseService;
        private const int MinimumCoursesToAttend = 3;

        public StudentService(CourseService courseService)
        {
            _courseService = courseService;
        }

        public void SetStudentEnrollment(Student student)
        {
            student.IsEnrolled = student.Courses.Count >= MinimumCoursesToAttend;
        }

        public void ComputeStudentCoursesSchedules(Student student)
        {
            foreach (var course in student.Courses)
            {
                _courseService.ComputeCourseSchedule(course);
            }
        }

        public void CreateStudentScheduleFile(Student student)
        {
            using (var file = new System.IO.StreamWriter(@"C:\Users\albrinza\OneDrive - ENDAVA\Desktop\Teaching\StudentSchedule.txt"))
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
