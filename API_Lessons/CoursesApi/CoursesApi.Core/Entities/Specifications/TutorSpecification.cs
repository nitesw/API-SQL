using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Entities.Specifications
{
    public static class TutorSpecification
    {
        public class ByRating : Specification<Tutor>
        {
            public ByRating(int rating)
            {
                if (rating >= 1 || rating <= 5)
                {
                    Query.Where(t => t.Rating == rating);
                }
            }
        }
        public class ByEmail : Specification<Tutor>
        {
            public ByEmail(string email)
            {
                Query.Where(t => t.Email == email);
            }
        }
    }
}
