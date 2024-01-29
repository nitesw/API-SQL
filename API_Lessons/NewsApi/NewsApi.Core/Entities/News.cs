using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.Entities
{
    public class News
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        public virtual Category Category { get; set; }
        /*public TimeOnly CreationTime { get; set; }
        public DateOnly CreationDate { get; set; }*/
    }
}
