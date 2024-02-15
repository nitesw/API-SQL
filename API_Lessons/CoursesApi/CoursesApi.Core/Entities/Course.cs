using CoursesApi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Entities
{
    public class Course : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        private int rating;
        public int Rating
        {
            get { return rating; }
            set { rating = value > 0 && value < 6 ? value : 1; }
        }

        public int Price { get; set; }
        public string LengthOfCourse { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int TutorId { get; set; }
        public Tutor? Tutor { get; set; }
    }
}
