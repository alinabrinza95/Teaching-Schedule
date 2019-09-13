using System.Collections.Generic;
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
            foreach (var student in seed.Students)
            {
                teachingScheduleService.ScheduleStudent(student.Id, new List<int> { 1, 2, 3, 4 });
            }

            foreach (var teacher in seed.Teachers)
            {
                teachingScheduleService.ScheduleTeacher(teacher.Id);
            }
        }
    }
}
