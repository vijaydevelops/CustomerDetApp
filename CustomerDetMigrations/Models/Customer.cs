using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerDetMigrations.Models
{
    public class Customer
    {
        // [Key]
        public long Id { get; set; }
        
        public string custCode { get; set; }
        public string custName { get; set; }
        public string custAddress { get; set; }
        public int country { get; set; }
        public string custEmail { get; set; }
        public string custContactNo { get; set; } 
    }
}
