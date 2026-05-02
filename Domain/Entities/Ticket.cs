using Domain.Enums;

namespace Domain.Entities;

public class Ticket : BaseEntity
{
	public required Unit Unit { get; set; }
	public required User CreatedBy { get; set; }
	public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	public required string Title { get; set; }
	public TicketPriority Priority { get; set; } = TicketPriority.Medium;
	public TicketStatus Status { get; set; } = TicketStatus.Open;
	public ICollection<TicketComment> Comments { get; set; } = [];
	public ICollection<TicketPhoto> Photos { get; set; } = [];
}