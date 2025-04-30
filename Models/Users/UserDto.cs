﻿namespace KetabeKhoob.Razor.Models.Users;

public class UserDto : BaseDto
{
    public string Name { get;  set; }
    public string Family { get;  set; }
    public string PhoneNumber { get;  set; }
    public string Email { get;  set; }
    public string Password { get;  set; }
    public string AvatarName { get;  set; }
    public bool IsActive { get; set; }
    public GenderDto Gender { get;  set; }
    public List<UserRoleDto> UserRoles { get;  set; }
}