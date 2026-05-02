namespace Domain.Entities;

public class TicketComment : BaseEntity
{
	public Ticket Ticket { get; set; } = default!;
	public string Comment { get; set; } = default!;
}