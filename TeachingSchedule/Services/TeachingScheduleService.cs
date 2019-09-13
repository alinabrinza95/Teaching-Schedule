using System.Collections.Generic;

namespace TeachingSchedule.Services
{
    public class TeachingScheduleService
    {
        private readonly StudentService _studentService;
        private readonly CourseService _courseService;
        private readonly TeacherService _teacherService;

        public TeachingScheduleService(Seed seed)
        {
            _courseService = new CourseService(seed);
            _studentService = new StudentService(_courseService, seed);
            _teacherService = new TeacherService(_courseService, seed);
        }

        public void ScheduleStudent(int studentId, List<int> coursesIds)
        {
            _studentService.AssignCoursesToStudent(studentId, coursesIds);
            _studentService.SetStudentEnrollment(studentId);
            if (!_studentService.IsStudentEnrolled(studentId))
            {
                return;
            }
            _studentService.ComputeStudentCoursesSchedules(studentId);
            _studentService.CreateStudentScheduleFile(studentId);
        }

        public void ScheduleTeacher(int teacherId)
        {
            _teacherService.AssignCoursesToTeacher(teacherId);
            _teacherService.ComputeTeacherCoursesSchedules(teacherId);
            _teacherService.CreateTeacherScheduleFile(teacherId);
        }

        public void ScheduleStudents(List<int> studentIds, Dictionary<int, List<int>> coursesIds)
        {
            foreach (var studentId in studentIds)
            {
                ScheduleStudent(studentId, coursesIds[studentId]);
            }
        }

        public void ScheduleTeachers(List<int> teacherIds)
        {
            foreach (var teacherId in teacherIds)
            {
                ScheduleTeacher(teacherId);
            }
        }
    }
}
