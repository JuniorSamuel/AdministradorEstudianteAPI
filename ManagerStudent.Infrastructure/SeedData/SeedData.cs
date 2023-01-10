using ManagerStudent.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ManagerStudent.Infrastructure.SeedData
{
    public class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Student
            var file = File.ReadAllText("../ManagerStudent.Infrastructure/SeedData/Student.json");
            var student = JsonSerializer.Deserialize<List<Student>>(file);
            
            student.ForEach(s =>
                modelBuilder.Entity<Student>().HasData(s)
            );

            // Subject
            file = File.ReadAllText("../ManagerStudent.Infrastructure/SeedData/Subject.json");
            var subject = JsonSerializer.Deserialize<List<Subject>>(file);

            subject.ForEach(s =>
                modelBuilder.Entity<Subject>().HasData(s)
            );

            // Score
            file = File.ReadAllText("../ManagerStudent.Infrastructure/SeedData/Score.json");
            var score = JsonSerializer.Deserialize<List<Score>>(file);

            score.ForEach(s =>
                modelBuilder.Entity<Score>().HasData(s)
            );

            // Attendance
            file = File.ReadAllText("../ManagerStudent.Infrastructure/SeedData/Attendance.json");
            var attendance = JsonSerializer.Deserialize<List<Attendance>>(file);

            attendance.ForEach( a =>
                modelBuilder.Entity<Attendance>().HasData(a)
            );
        }
    }
}
