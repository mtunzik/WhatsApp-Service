using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ThanosApp.API.Models;

namespace ThanosApp.API.Dtos {
    public class UserForListDto {
        public int Id { get; set; }
        public string UId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Introduction { get; set; }
        public string Username { get; set; }

        public int Age { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime LastActive { get; set; }

        public Gender Gender { get; set; }
        public string PhotoUrl { get; set; }

    }
}