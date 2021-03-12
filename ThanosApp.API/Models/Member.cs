using System;
namespace ThanosApp.API.Models
{
    public class Member
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CommitteeId { get; set; }

        public User User { get; set; }
        public Committee Committees { get; set; }
    }
}