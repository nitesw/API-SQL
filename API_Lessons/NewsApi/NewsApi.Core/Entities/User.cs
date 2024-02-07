using NewsApi.Core.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string Name { get; set; } = string.Empty;
        [StringLength(128)]
        public string Surname { get; set; } = string.Empty;
        [StringLength(128)]
        public string Username { get; set; } = string.Empty;
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value >= 18 ? value : 18; }
        }

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string Phone { get; set; } = string.Empty;

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
