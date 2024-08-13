using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Entities.Specifications
{
    public static class CoursesSpecification
    {
        public class ByCategory : Specification<Course>
        {
            public ByCategory(int categoryId)
            {
                Query.Where(c => c.CategoryId == categoryId);
            }
        }
        public class ByTutorMail : Specification<Course>
        {
            public ByTutorMail(string email)
            {
                Query.Where(e => e.Tutor.Email == email);
            }
        }
        public class ByName : Specification<Course>
        {
            public ByName(string name)
            {
                Query.Where(c => c.Name == name);
            }
        }
    }
}
