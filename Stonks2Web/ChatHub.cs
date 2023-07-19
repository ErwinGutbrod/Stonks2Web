using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stonks2Web
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            IStockBot stockBot = new StockBot();
            if (message.StartsWith("/"))
            {
                name = "StockBot";
                message = stockBot.CheckStock(message.Substring(message.IndexOf("=") + 1));
            }
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }
    }
}