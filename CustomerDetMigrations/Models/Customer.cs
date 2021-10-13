using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerDetMigrations.Models
{
    public class Customer
    {
        // [Key]
        public long Id { get; set; }
        
        [DisplayName("Code")]
        public string custCode { get; set; }

        [DisplayName("Name")]
        public string custName { get; set; }

        [DisplayName("Address")]
        public string custAddress { get; set; }

        [DisplayName("Country")]
        public int country { get; set; }

        [DisplayName("EMail")]
        public string custEmail { get; set; }

        [DisplayName("Phone No.")]
        public string custContactNo { get; set; }


        private int _isDeleted = 0;

        public int isDeleted 
        { 
            get
            {
                return _isDeleted;
            }
            set
            {
                _isDeleted = value;
            } 
        }
    }
}
