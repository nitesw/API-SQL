using CoursesApi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Entities
{
    public class Tutor : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        private int age;
        public int Age
        {
            get { return age; }
            set { age = value > 17 ? value : 18; }
        }

        private int rating;
        public int Rating
        {
            get { return rating; }
            set { rating = value > 0 && value < 6 ? value : 1; }
        }

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string Phone { get; set; } = string.Empty;
    }
}
