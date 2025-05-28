using Core.Enums;

namespace Core.Model.DTO.User;

public class UserResponse
{
    public Guid Id { get; set; } = Guid.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public UserRoles Role { get; set; } = UserRoles.User;
}

