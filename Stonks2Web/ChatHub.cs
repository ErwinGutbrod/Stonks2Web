using Microsoft.AspNet.SignalR;
using Stonks2.DAL.DataAccess;
using Stonks2.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stonks2Web
{
    public class ChatHub : Hub
    {
        public void Send(int chatRoomId, string name, string message)
        {
            ChatRoomContext roomContext = new ChatRoomContext();
            IStockBot stockBot = new StockBot();
            if (message.StartsWith("/"))
            {
                name = "StockBot";
                if (message.Substring(0,message.IndexOf('=')) == "/stock") {
                    try
                    {
                        message = stockBot.CheckStock(message.Substring(message.IndexOf("=") + 1));
                    }
                    catch (Exception)
                    {

                        message = "Stock symbol " + message.Substring(message.IndexOf("=")).ToUpper() + " not found.";
                    }
                }
                else
                {
                    message = "Please use only /stock=CODE command, where CODE is your stock Symbol.";
                }
                
            }
            Stonks2.DAL.Models.ChatHub chatHub =  roomContext.ChatHubs.Find(chatRoomId);
            ChatMessage chatMessage = new ChatMessage();
            ChatUser user = new ChatUser();
            user.Email = name;
            chatMessage.Message = message;
            chatMessage.Sender = user;
            chatMessage.TimeStamp = DateTime.Now;
            chatHub.Messages.Add(chatMessage);            
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(chatMessage.TimeStamp.ToString(), name, message);
            roomContext.SaveChanges();
        }
    }
}