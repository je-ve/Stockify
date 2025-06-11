using System.ComponentModel.DataAnnotations;
namespace Stockify.Web.ViewModels;
public class MessageInputModel
{
    [Required(ErrorMessage = "Prioriteit is verplicht")]
    public bool HighPriority { get; set; } = false;

    [Required(ErrorMessage = "Berichttype is verplicht")]
    public bool PrivateMessage { get; set; }
    
    [Required(ErrorMessage = "Bericht is verplicht")]
    [StringLength(1000, ErrorMessage = "Bericht mag maximaal 1000 tekens bevatten")]
    [MinLength(1, ErrorMessage = "Bericht moet minimaal 1 teken bevatten")]
    public string Content { get; set; } = string.Empty;    
    public string CreatedById { get; set; } = string.Empty;    
    public string? RecipientId { get; set; } = null;
}
