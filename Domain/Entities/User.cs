using Domain.Enums;

namespace Domain.Entities;

public abstract class User : BaseEntity
{
	public string Name { get; set; } = default!;
	public string Email { get; set; } = default!;
	public UserRole Role { get; set; }
	public string PasswordHash { get; set; } = default!;
	public DateTime CreatedAt { get; init; }
	public DateTime? DeactivatedAt { get; set; }
}