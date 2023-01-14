using System.Diagnostics;
using Elytra.Database;
using Elytra.Domain.Models;
using Microsoft.EntityFrameworkCore;

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
            _context.Messages?.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Message>?> GetAllMessages()
        {
            Debug.Assert(_context.Messages != null, "Context messages are null!");
            return await _context.Messages.Include(x => x.User).ToListAsync();
        }
    }
}
