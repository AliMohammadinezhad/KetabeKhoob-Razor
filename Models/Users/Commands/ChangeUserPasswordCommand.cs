using System.ComponentModel.DataAnnotations;

namespace KetabeKhoob.Razor.Models.Users.Commands;

public class ChangeUserPasswordCommand
{
    public string CurrentPassword { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}