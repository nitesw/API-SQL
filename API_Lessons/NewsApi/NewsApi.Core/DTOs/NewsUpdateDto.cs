﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.DTOs
{
    public class NewsUpdateDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

        public int AuthorId { get; set; }
        public int CategoryId { get; set; }

        public string Image { get; set; } = string.Empty;
    }
}
