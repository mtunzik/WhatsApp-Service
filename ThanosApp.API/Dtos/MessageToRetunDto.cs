

using System;
namespace ThanosApp.API.Dtos
{
    public class MessageToRetunDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderPhotoUrl { get; set; }
        public int RecipientId { get; set; }
        public string RecipientPhotoUrl { get; set; }
        public DateTime MessageSent { get; set; }
        public string Content { get; set; }

        public DateTime DateRead { get; set; }
        public bool  IsRead { get; set; }
        
        
    }
    
}