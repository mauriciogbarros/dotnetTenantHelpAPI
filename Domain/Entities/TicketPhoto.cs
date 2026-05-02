namespace Domain.Entities;

public class TicketPhoto : BaseEntity
{
	public Ticket Ticket { get; set; } = default!;
	public string FilePath { get; set; } = default!;
	public DateTime UploadedAt { get; init; } = DateTime.UtcNow;
}