using System;
using System.Collections.Generic;

namespace UserWebAPI.Models
{
    public partial class TblUser
    {
        public int IUserId { get; set; }
        public string StrFirstName { get; set; } = null!;
        public string? StrLastName { get; set; }
        public string StrEmail { get; set; } = null!;
        public DateTime DtDateOfBirth { get; set; }
    }
}
