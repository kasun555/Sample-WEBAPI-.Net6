using System;
using System.Collections.Generic;

namespace UserWebAPI.Models
{
    public partial class Employee
    {
        public int Empid { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
    }
}
