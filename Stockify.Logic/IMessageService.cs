using Stockify.Objects;

namespace Stockify.Logic
{
    public interface IMessageService
    {
        Task AddAsync(bool highPriority, string content, string currentUserId, string? recipientId = null);
        Task DeleteAsync(int id);
        Task<List<Message>> GetAllAsync();
        Task<Message?> GetByIdAsync(int id);
        Task<List<Message>> GetByRecipientIdAsync(string recipientId);
    }
}