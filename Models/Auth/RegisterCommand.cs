namespace KetabeKhoob.Razor.Models.Auth;

public class RegisterCommand
{
    public string PhoneNumber { set; get; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}