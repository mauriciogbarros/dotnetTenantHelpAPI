using Domain.Enums;

namespace Domain.Entities;

public class Tenant : User
{
	public Unit? Unit { get; set; }
	public ICollection<Ticket> Tickets { get; set; } = [];

	public void CreateTicket(string title, TicketPriority priority, string comment, string? photoPath)
	{
		Ticket newTicket = new Ticket()
		{
			Unit = this.Unit,
			CreatedBy = this,
			CreatedAt = DateTime.UtcNow,
			Title = title,
			Priority = priority
		};

		TicketComment newTicketComment = new TicketComment()
		{
			Ticket = newTicket,
			Comment = comment
		};

		newTicket.Comments.Add(newTicketComment);

		if (photoPath != null)
		{
			TicketPhoto newTicketPhoto = new TicketPhoto()
			{
				Ticket = newTicket,
				FilePath = photoPath
			};

			newTicket.Photos.Add(newTicketPhoto);
		}
	}

	public void CommentTicket(Ticket ticket, string comment)
	{
		TicketComment newTicketComment = new TicketComment()
		{
			Ticket = ticket,
			Comment = comment
		};
		ticket.Comments.Add(newTicketComment);
	}

	public void AddPhotoToTicket(Ticket ticket, string photoPath)
	{
		TicketPhoto newTicketPhoto = new TicketPhoto()
		{
			Ticket = ticket,
			FilePath = photoPath
		};
		ticket.Photos.Add(newTicketPhoto);
	}

	
}