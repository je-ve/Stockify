using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Stockify.Data;
using Stockify.Objects;

namespace Stockify.Logic;

/// <summary>
/// Service responsible for managing system messages between users, including priority notices.
/// </summary>
public class MessageService : IMessageService
{
    private readonly StockifyContext _context;

    public MessageService(StockifyContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves all messages from the database.
    /// </summary>
    public async Task<List<Message>> GetAllAsync()
    {
        return await _context.Messages.ToListAsync();
    }

    /// <summary>
    /// Retrieves a specific message by its ID.
    /// </summary>
    public async Task<Message?> GetByIdAsync(int id)
    {
        return await _context.Messages.FindAsync(id);
    }

    /// <summary>
    /// Retrieves all messages for a specific recipient.
    /// Includes public messages (with null RecipientId) as well.
    /// Also adds the creator's username to each message.
    /// </summary>
    public async Task<List<Message>> GetByRecipientIdAsync(string recipientId)
    {
        var messages = await _context.Messages
            .Where(m => m.RecipientId == recipientId || m.RecipientId == null)
            .OrderByDescending(m => m.CreatedAt)
            .ToListAsync();

        // Enrich each message with the creator's username
        foreach (var message in messages)
        {
            await AddUserName(message);
        }

        return messages;
    }

    /// <summary>
    /// Adds the creator's username to a message, using their ID.
    /// If the user is not found, sets name to "gebruiker onbekend".
    /// </summary>
    private async Task AddUserName(Message message)
    {
        if (!string.IsNullOrEmpty(message.CreatedById))
        {
            var user = await _context.Users.FindAsync(message.CreatedById);
            message.CreatedByName = user?.UserName ?? "gebruiker onbekend";
        }
    }

    /// <summary>
    /// Adds a new message to the database.
    /// Supports optional recipient and high-priority flag.
    /// </summary>
    public async Task AddAsync(bool highPriority, string content, string currentUserId, string? recipientId = null)
    {
        var message = new Message
        {
            HighPriority = highPriority,
            Content = content,
            CreatedAt = DateTime.UtcNow,
            CreatedById = currentUserId,
            RecipientId = recipientId
        };

        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes a message by its ID  
    /// </summary>
    public async Task DeleteByIdAsync(int id)
    {
        var message = await _context.Messages.FindAsync(id);
        if (message != null)
        {
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
        }
    }
}


/*
using System.Runtime.CompilerServices;
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

    public async Task DeleteByIdAsync (int id)
    {
        var message = await _context.Messages.FindAsync(id);
        if (message != null)
        {
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
        }
    }
}

*/