using Elytra.Domain.Models;

namespace Elytra.App
{
    public interface IMessageService
    {
        Task AddMessage(Message message);
        Task<List<Message>?> GetAllMessages();
    }
}
