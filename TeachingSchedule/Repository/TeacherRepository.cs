using System.Collections.Generic;
using System.Linq;
using TeachingSchedule.Models;

namespace TeachingSchedule.Repository
{
    public class TeacherRepository
    {
        private readonly Seed _seed;

        public TeacherRepository()
        {
            _seed = new Seed();
        }

        public Teacher GetTeacherById(int id)
        {
            return _seed.Teachers.FirstOrDefault(s => s.Id.Equals(id));
        }

        public List<Teacher> GetTeachersByGender(char gender)
        {
            return _seed.Teachers.Where(s => s.Gender.Equals(gender)).ToList();
        }

        public List<Teacher> GetAllTeachers()
        {
            return _seed.Teachers;
        }
    }
}
