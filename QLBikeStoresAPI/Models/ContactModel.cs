﻿using System;

namespace QLBikeStoresAPI.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
