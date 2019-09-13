using System.Collections.Generic;
using System.Linq;
using TeachingSchedule.Models;

namespace TeachingSchedule.Repository
{
    public class StudentRepository
    {
        private readonly Seed _seed;

        public StudentRepository()
        {
            _seed = new Seed();
        }

        public Student GetStudentById(int id)
        {
            return _seed.Students.FirstOrDefault(s => s.Id.Equals(id));
        }

        public List<Student> GetStudentsByGender(char gender)
        {
            return _seed.Students.Where(s => s.Gender.Equals(gender)).ToList();
        }

        public List<Student> GetAllStudents()
        {
            return _seed.Students;
        }
    }
}
