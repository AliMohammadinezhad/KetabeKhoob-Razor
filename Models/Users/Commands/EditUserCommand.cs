using System.Reflection;

namespace KetabeKhoob.Razor.Models.Users.Commands;

public class EditUserCommand
{
    public long UserId { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public IFormFile? Avatar { get; set; }
    public GenderDto Gender { get; set; }
}