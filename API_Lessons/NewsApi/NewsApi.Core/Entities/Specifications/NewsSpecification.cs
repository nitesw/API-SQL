using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.Entities.Specifications
{
    public static class NewsSpecification
    {
        public class All : Specification<News>
        {
            public All()
            {
                Query.Include(x => x.CategoryId);
            }            
        }
        public class ByCategory : Specification<News>
        {
            public ByCategory(int categoryId)
            {
                Query.Where(c => c.CategoryId == categoryId);
            }
        }
        public class ByAuthor : Specification<News>
        {
            public ByAuthor(string username)
            {
                Query.Where(nA => nA.Author.Username == username);
            }
        }
    }
}
