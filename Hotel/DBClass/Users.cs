﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DBClass
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserTitle { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int UserStatus { get; set; }
        public int RoleId { get; set; }
        public DateTime InsertionDateTime { get; set; }

       
    }
}