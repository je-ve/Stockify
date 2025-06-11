using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stockify.Objects;
public class Message
{
    public int Id { get; set; }
    public bool HighPriority { get; set; } = false;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string CreatedById { get; set; } = string.Empty;
    public string? CreatedByName { get; set; } = string.Empty;
    public string? RecipientId { get; set; } = null;
}
