using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThanosApp.API.Models {
    public class User {
        public int Id { get; set; }
        public string UId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Introduction { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public DateTime? DateofBirth { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? LastActive { get; set; }
        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection <Message>  MessagesSent{ get; set; }
        public ICollection <Message>  MessagesRecieved{ get; set; }


    }
}