using System;
using System.Collections.Generic;

namespace UserWebAPI.Models
{
    public partial class EmployeeV2
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
    }
}
