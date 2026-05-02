using System.Text.RegularExpressions;
using Domain.Enums;

namespace Domain.Entities;

public class Manager : User
{
	static Property Property { get; set; } = default!;

	protected static readonly Regex EmailRegex = new Regex(
		@"^[a-zA-Z0-9._%+\-]+@[a-zA-Z0-9.\-]+\.[a-zA-Z]{2,}$",
		RegexOptions.Compiled | RegexOptions.IgnoreCase
	);

	public Manager(string name, string email,	string passwordHash, Property property)
	{
		if (string.IsNullOrEmpty(name))
			throw new ArgumentException("Name cannot be empty.");

		if (string.IsNullOrEmpty(email))
			throw new ArgumentException("Email cannot be empty.");

		if (!EmailRegex.IsMatch(email))
			throw new ArgumentException("Invalid email format.");

		Name = name;
		Email = email;
		Role = UserRole.Manager;
		PasswordHash = passwordHash;
		CreatedAt = DateTime.UtcNow;
		Property = property;

		Property.Users.Add(this);
	}

	public void CreateManager(string name, string email, string passwordHash)
	{
		if (string.IsNullOrEmpty(name))
			throw new ArgumentException("Name cannot be empty.");

		if (string.IsNullOrEmpty(email))
			throw new ArgumentException("Email cannot be empty.");

		if (!EmailRegex.IsMatch(email))
			throw new ArgumentException("Invalid email format.");
		
		var newManager = new Manager(name, email, passwordHash, Property);

		Property.Users.Add(newManager);
	}

	public void CreateTenant(string name, string email, string passwordHash)
	{
		if (string.IsNullOrEmpty(name))
			throw new ArgumentException("Name cannot be empty.");

		if (string.IsNullOrEmpty(email))
			throw new ArgumentException("Email cannot be empty.");

		if (!EmailRegex.IsMatch(email))
			throw new ArgumentException("Invalid email format.");

		if (string.IsNullOrEmpty(passwordHash))
			throw new ArgumentException("Password cannot be empty.");

		var newTenant = new Tenant()
		{
			Name = name,
			Email = email,
			Role = UserRole.Tenant,
			PasswordHash = passwordHash,
			CreatedAt = DateTime.UtcNow,
			Unit = null
		};

		Property.Users.Add(newTenant);
	}
	public void CreateTechnician(string name, string email, string passwordHash)
	{
		if (string.IsNullOrEmpty(name))
			throw new ArgumentException("Name cannot be empty.");

		if (string.IsNullOrEmpty(email))
			throw new ArgumentException("Email cannot be empty.");

		if (!EmailRegex.IsMatch(email))
			throw new ArgumentException("Invalid email format.");

		if (string.IsNullOrEmpty(passwordHash))
			throw new ArgumentException("Password cannot be empty.");

		var newTechnician = new Technician()
		{
			Name = name,
			Email = email,
			Role = UserRole.Technician,
			PasswordHash = passwordHash,
			CreatedAt = DateTime.UtcNow
		};

		Property.Users.Add(newTechnician);
	}

	public void GetUsers()
	{
		foreach(User user in Property.Users)
		{
			Console.WriteLine($"{user.Role} - {user.Name} - {user.Email} - {user.CreatedAt}");
		}
	}

	public void GetTenants()
	{
		ICollection<Tenant> tenants = Property.Users.OfType<Tenant>().ToList();
		foreach (Tenant tenant in tenants)
		{
			Console.Write($"{tenant.Name} - ");
			string unitNumber = tenant.Unit == null ? "---" : tenant.Unit.Number.ToString();
			Console.WriteLine(unitNumber);
		}
	}

	public void GetManagers()
	{
		ICollection<Manager> managers = Property.Users.OfType<Manager>().ToList();
		foreach(Manager manager in managers)
		{
			Console.WriteLine($"{manager.Name} - {manager.Email} - {manager.CreatedAt}");
		}
	}

	public void GetTechnicians()
	{
		ICollection<Technician> technicians = Property.Users.OfType<Technician>().ToList();
		foreach(Technician technician in technicians)
		{
			Console.WriteLine($"{technician.Name} - {technician.Email}");
		}
	}

	public void GetUnits()
	{
		foreach(Unit unit in Property.Units)
		{
			Console.Write($"{unit.Number} - ");
			string unitTenant = unit.Tenant == null ? "Empty" : unit.Tenant.Name;
			Console.WriteLine(unitTenant);
		}
	}
	public void AssignTenantUnit(Tenant tenant, int unitNumber)
	{
		var unit = Property.Units.FirstOrDefault(u => u.Number == unitNumber);
		if (unit == null)
			throw new ArgumentException("Invalid unit number.");

		unit.AssignTenant(tenant);
	}

	public void DeassignTenantUnit(int unitNumber)
	{
		var unit = Property.Units.FirstOrDefault(u => u.Number == unitNumber);
		if (unit == null)
			throw new ArgumentException("Invalid unit number.");

		unit.DeassignTenant();
	}
}