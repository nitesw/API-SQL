using CoursesApi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Entities
{
    public class IpAdress : IEntity
    {
        public int Id { get; set; }

        public TimeOnly Time { get; set; }
        public DateOnly Date { get; set; }
        public string Operation { get; set; } = string.Empty;
        public string Ip { get; set; } = string.Empty;
    }
}
