using System;
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
            teachingScheduleService.ScheduleStudent(1);
        }
    }
}
