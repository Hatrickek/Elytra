using Elytra.Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace Elytra.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
            //Store chat in database
            
        }
    }
}
