using System.Linq;
using TeachingSchedule.Services;

namespace TeachingSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            var seed = new Seed();
            seed.FeedEntities();

            var teachingScheduleService = new TeachingScheduleService(seed);
            seed.FeedStudentCourseDictionary();

            teachingScheduleService.ScheduleStudents(seed.Students.Select(s=>s.Id).ToList(), seed.StudentCourseDictionary, "path");
            teachingScheduleService.ScheduleTeachers(seed.Teachers.Select(t=>t.Id).ToList(), "path");
        }
    }
}
