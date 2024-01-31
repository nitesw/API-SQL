using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.Entities
{
    public class Statistics
    {
        public int Id { set; get; }
        [MaxLength(15)]
        public string VisitorIp { get; set; } = string.Empty;
        public string VisitorBrowser { get; set; } = string.Empty;
        public string VisitorCountry { get; set; } = string.Empty;

        public int NewsId { get; set; }
        public virtual News News { get; set; }
    }
}
