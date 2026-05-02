namespace Domain.Entities;

public class Property
{
	public string Address { get; set; } = default!;
	public ICollection<Unit> Units { get; set; } = [];
	public ICollection<User> Users { get; set; } = [];

	public Property(string address)
	{
		Address = address;
	}

	public void AddUnit(Unit unit)
	{
		Units.Add(unit);
	}

	public void RemoveUnit(int unitNumber)
	{
		var unitToRemove = Units.FirstOrDefault(u => u.Number == unitNumber);
		if (unitToRemove != null)
			Units.Remove(unitToRemove);
	}
}