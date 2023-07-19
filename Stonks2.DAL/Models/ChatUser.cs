using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stonks2.DAL.Models
{
    [Table("ChatUser")]
    public class ChatUser
    {
        [Key]
        public int UserId { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
    }
}
