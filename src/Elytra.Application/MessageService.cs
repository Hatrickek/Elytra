using Elytra.Database;
using Elytra.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elytra.App
{
    public class MessageService : IMessageService
    {
        private readonly ElytraContext _context;

        public MessageService(ElytraContext context)
        {
            _context = context;
        }
        
        public async Task AddMessage(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Message>?> GetAllMessages()
        {
            return await _context.Messages.Include(x => x.User).ToListAsync();
        }
    }
}
