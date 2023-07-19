using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stonks2.DAL.Models
{
    [Table("ChatHub")]
    public class ChatHub
    {
        public ChatHub() { 
            this.Messages = new List<ChatMessage>();
        }
        [Key]
        public int ChatHubId { get; set; }

        public string ChatHubName { get; set; }
       
        public string ChatHubDescription { get; set;}

        public virtual ChatUser Owner { get; set; }

        public virtual ICollection<ChatUser> Members { get; set; }

        public virtual ICollection<ChatMessage> Messages { get; set; }
    }    
}
