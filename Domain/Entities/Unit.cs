namespace Domain.Entities;

public class Unit : BaseEntity
{
	public int Number { get; set; }
	public Tenant? Tenant { get; set; }
	public string Description { get; set; } = default!;
	public ICollection<Ticket> Tickets { get; set; } = [];

	public Unit(int number, string description)
	{
		Id = Guid.NewGuid();
		Number = number;
		Description = description;
	}

	public bool IsEmpty()
	{
		return Tenant == null;
	}

	public void AssignTenant(Tenant tenant)
	{
		if (!IsEmpty())
			throw new ArgumentException("This unit is occupied.");

		Tenant = tenant;
	}

	public void DeassignTenant()
	{
		if (IsEmpty())
			throw new ArgumentException("This unit is not occupied.");

		Tenant = null;
	}
}