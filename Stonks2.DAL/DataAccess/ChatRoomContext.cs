using Stonks2.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace Stonks2.DAL.DataAccess
{
    public  class ChatRoomContext : DbContext
    {
        public ChatRoomContext() : base("Stonks2Database")
        {
        }

        public DbSet<ChatHub> ChatHubs { get; set; }
        public DbSet<ChatMessage> Messages { get; set; }
        public DbSet<ChatUser> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
