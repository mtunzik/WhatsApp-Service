using System;

namespace ThanosApp.API.Models
{
    public class Photo
    {
        public int Id { get; set; } 
        public string Url { get; set; }
        public string Description   { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool IsMain { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateModified { get; set; }
        public int UserId { get; set; }
    }
}