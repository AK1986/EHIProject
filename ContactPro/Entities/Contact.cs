using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactPro.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        
    }

    public enum Status
    {
        Active, Inactive
    }
}
