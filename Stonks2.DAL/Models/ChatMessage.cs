using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stonks2.DAL.Models
{
    [Table("ChatMessage")]
    public class ChatMessage
    {
        [Key]
        public int ChatMessageId { get; set; }

        public string Message { get; set; }

        public virtual ChatUser Sender { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
