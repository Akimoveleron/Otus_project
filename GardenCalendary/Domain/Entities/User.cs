using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

/// <summary>
/// Пользователь
/// </summary>
public class User : IdentityUser<int>
{
    public string Password { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string SecondName { get; set; } = string.Empty;

    public string? LastName { get; set; }
}
