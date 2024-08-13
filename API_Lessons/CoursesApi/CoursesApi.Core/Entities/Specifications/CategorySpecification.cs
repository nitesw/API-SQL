using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Entities.Specifications
{
    public static class CategorySpecification
    {
        public class ByName : Specification<Category>
        {
            public ByName(string name)
            {
                Query.Where(c => c.Name == name);
            }
        }
    }
}
