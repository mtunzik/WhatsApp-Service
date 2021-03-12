
using System;
namespace ThanosApp.API.Models
{
    public class Committee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }  
        public DateTime? DateModified { get; set; }
        public bool IsPublic { get; set; }
        public bool IsDeleted { get; set; }
        public Member Members { get; set; }
    }
}