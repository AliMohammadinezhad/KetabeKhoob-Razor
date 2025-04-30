﻿namespace KetabeKhoob.Razor.Models.Users;

public class UserFilterData : BaseDto
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string AvatarName { get; set; }
    public GenderDto Gender { get; set; }
}