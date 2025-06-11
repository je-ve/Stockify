using Microsoft.EntityFrameworkCore;
using Stockify.Data;
using Stockify.Objects;

namespace Stockify.Logic;

public class MessageService : IMessageService
{
    private readonly StockifyContext _context;
    public MessageService(StockifyContext context)
    {
        _context = context;
    }
    public async Task<List<Message>> GetAllAsync()
    {
        return await _context.Messages.ToListAsync();
    }
    public async Task<Message?> GetByIdAsync(int id)
    {
        return await _context.Messages.FindAsync(id);
    }

    public async Task<List<Message>> GetByRecipientIdAsync(string recipientId)
    {
        List<Message> Messages = await _context.Messages
            .Where(m => m.RecipientId == recipientId || m.RecipientId == null)
            .OrderByDescending(m => m.CreatedAt).ToListAsync();

        foreach (var message in Messages)
        {
            await AddUserName(message);
        }
        return Messages;
    }

    private async Task AddUserName(Message message)
    {
        if (!string.IsNullOrEmpty(message.CreatedById))
        {
            //of userservice gebruiken?
            var user = await _context.Users.FindAsync(message.CreatedById);
            if (user != null)
            {
                message.CreatedByName = user.UserName;
            }
            else message.CreatedByName = "gebruiker onbekend";
        }
    }

    public async Task AddAsync(bool highPriority, string content, string currentUserId, string? recipientId = null)
    {
        Message message = new Message();
        message.HighPriority = highPriority;
        message.Content = content;
        message.CreatedAt = DateTime.UtcNow;
        message.CreatedById = currentUserId;
        message.RecipientId = recipientId;
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var message = await _context.Messages.FindAsync(id);
        if (message != null)
        {
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
        }
    }
}