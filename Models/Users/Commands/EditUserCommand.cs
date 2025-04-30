namespace KetabeKhoob.Razor.Models.Users.Commands;

public class EditUserCommand
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public GenderDto Gender { get; set; }
}