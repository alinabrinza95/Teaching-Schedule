﻿using System;
using System.Collections.Generic;
using System.Linq;
using TeachingSchedule.Models;

namespace TeachingSchedule
{
    public class Seed
    {
        public List<Student> Students = new List<Student>();

        public List<Teacher> Teachers = new List<Teacher>();

        public List<Course> Courses = new List<Course>();

        public Dictionary<int, List<int>> StudentCourseDictionary = new Dictionary<int, List<int>>();

        public void FeedStudentCourseDictionary()
        {
            StudentCourseDictionary.Add(1, new List<int> { 1, 2, 3 });
            StudentCourseDictionary.Add(2, new List<int> { 2, 3, 4 });
            StudentCourseDictionary.Add(3, new List<int> { 3, 4, 1 });
            StudentCourseDictionary.Add(4, new List<int> { 1, 2, 3, 4 });
        }


        public void FeedStudents()
        {
            Students = new List<Student>
            {
                new Student()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Gender = 'M',
                    BirthDate = new DateTime(1990, 10, 06),
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Hellen",
                    LastName = "Doe",
                    Gender = 'F',
                    BirthDate = new DateTime(1998, 10, 06),
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Julia",
                    LastName = "Ingram",
                    Gender = 'F',
                    BirthDate = new DateTime(2001, 08, 26),
                },
                new Student()
                {
                    Id = 4,
                    FirstName = "Simon",
                    LastName = "Marge",
                    Gender = 'M',
                    BirthDate = new DateTime(2005, 01, 25),
                }
            };
        }

        public void FeedTeachers()
        {
            Teachers = new List<Teacher>
            {
                new Teacher()
                {
                    Id = 1,
                    FirstName = "Maria",
                    LastName = "Gregova",
                    Gender = 'F',
                    BirthDate = new DateTime(1970, 05,17),
                },
                new Teacher()
                {
                    Id = 2,
                    FirstName = "Julian",
                    LastName = "Helm",
                    Gender = 'M',
                    BirthDate = new DateTime(1982, 02,28),
                },
                new Teacher()
                {
                    Id = 3,
                    FirstName = "Hans",
                    LastName = "Herminger",
                    Gender = 'M',
                    BirthDate = new DateTime(1968, 11,16),
                },
                new Teacher()
                {
                    Id = 4,
                    FirstName = "Mariana",
                    LastName = "Blum",
                    Gender = 'F',
                    BirthDate = new DateTime(1985, 07,20),
                },
            };
        }

        public void FeedCourses()
        {
            Courses = new List<Course>
            {
                new Course()
                {
                    Id = 1,
                    Name = "Mathematics",
                    Description = "Advanced techniques in mathematics",
                    FrequencyInDays = 7,
                    NumberOfCoursesPerYear = 30,
                    CourseSchedule = new List<DateTime>(),
                    Teacher = Teachers.FirstOrDefault(t=>t.Id.Equals(1))
                },
                new Course()
                {
                    Id = 2,
                    Name = "Python",
                    Description = "Advanced techniques in Python",
                    FrequencyInDays = 14,
                    NumberOfCoursesPerYear = 15,
                    CourseSchedule = new List<DateTime>(),
                    Teacher = Teachers.FirstOrDefault(t=>t.Id.Equals(2))
                },
                new Course()
                {
                    Id = 3,
                    Name = "C#",
                    Description = "Advanced techniques in C#",
                    FrequencyInDays = 7,
                    NumberOfCoursesPerYear = 28,
                    CourseSchedule = new List<DateTime>(),
                    Teacher = Teachers.FirstOrDefault(t=>t.Id.Equals(3))
                },
                new Course()
                {
                    Id = 4,
                    Name = "Database",
                    Description = "Advanced techniques in database",
                    FrequencyInDays = 7,
                    NumberOfCoursesPerYear = 20,
                    CourseSchedule = new List<DateTime>(),
                    Teacher = Teachers.FirstOrDefault(t=>t.Id.Equals(4))
                },
            };
        }

        public void FeedEntities()
        {
            FeedStudents();
            FeedTeachers();
            FeedCourses();
        }
    }
}
