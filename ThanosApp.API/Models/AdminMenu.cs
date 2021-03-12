
using System;
using System.Collections.Generic;

namespace ThanosApp.API.Models
{
    public class AdminMenu
    {
        public int Id { get; set; }
        public string UId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ParentUId { get; set; }
        public int? ParentId { get; set; }
        public bool IsDeleted { get; set; }
        
        public DateTime?  DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

         public AdminMenu Parent { get; set; }
         public ICollection<AdminMenu> SubAdminMenu { get; set; }
        
    }
}