using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerDetMigrations.Models
{
    public class Country
    {
        // [Key]
        public long Id { get; set; }

        public string countryName { get; set; }
        public string countryCode { get; set; }
    }
}
