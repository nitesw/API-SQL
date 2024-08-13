using CoursesApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Infrastructure.Initializers
{
    internal static class AppDbInitializer
    {
        public static async Task SeedCourse(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course() 
                { 
                    Id = 1, 
                    Name = "CS50's Introduction to Game Development", 
                    Description = "Learn about the" +
                " development of 2D and 3D interactive games in this hands-on course," +
                " as you explore the design of games such as Super Mario Bros., Pokémon, Angry Birds, and more.",
                    Price = 0,
                    LengthOfCourse = "12 weeks long", 
                    Rating = 5,
                    CategoryId = 1,
                    TutorId = 1
                },
                new Course() 
                { 
                    Id = 2, 
                    Name = "CS50: Introduction to Computer Science", 
                    Description = "An introduction" +
                " to the intellectual enterprises of computer science and the art of programming.",
                    Price = 0,
                    LengthOfCourse = "11 weeks long",
                    Rating = 5,
                    CategoryId = 1,
                    TutorId = 2
                });            
        }
        public static async Task SeedCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Programming",
                    Description = "Category about programming"
                }
                );  
        }
        public static async Task SeedTutor(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tutor>().HasData(
                new Tutor()
                {
                    Id = 1,
                    Name = "Andrew",
                    Surname = "Li",
                    Age = 26,
                    Rating = 5,
                    Email = "andli221@mail.com",
                    Phone = "+111"
                },
                new Tutor()
                {
                    Id = 2,
                    Name = "John",
                    Surname = "Bobie",
                    Age = 41,
                    Rating = 4,
                    Email = "johnbbb@gmail.com",
                    Phone = "+222"
                }
                );
        }
    }
}
