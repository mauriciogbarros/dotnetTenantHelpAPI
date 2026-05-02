using Domain.Enums;

namespace Domain.Entities;

public class Technician : User
{
	public HashSet<TechnicianCapabilities> Capabilities { get; set; } = [];
}