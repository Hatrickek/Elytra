using Elytra.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elytra.App
{
    public interface IMessageService
    {
        Task AddMessage(Message message);
        Task<List<Message>?> GetAllMessages();
        
    }
}
