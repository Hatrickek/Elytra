using Elytra.App;
using Elytra.Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace Elytra.Server.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMessageService _messageService;
        public ChatHub(IMessageService messageService)
        {
            _messageService = messageService;
        }
        
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
            //add to database using MessageService
            await _messageService.AddMessage(message);
        }

        public async Task GetMessages()
        {
            var messages = await _messageService.GetAllMessages();
            await Clients.All.SendAsync("GetMessages", messages);
        }
    }
}
