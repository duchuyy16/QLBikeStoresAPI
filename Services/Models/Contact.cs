﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Services.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
