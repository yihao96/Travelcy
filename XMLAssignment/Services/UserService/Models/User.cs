﻿using System;
namespace UserService.Models
{
    public class User
    {
        public User()
        {
        }

        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
