﻿using System;

namespace MVVMDemo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
