namespace KetabeKhoob.Razor.Models.Users.Commands;

public class CreateUserCommand
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public GenderDto Gender { get; set; }
}