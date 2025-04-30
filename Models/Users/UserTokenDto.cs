namespace KetabeKhoob.Razor.Models.Users;

public class UserTokenDto : BaseDto
{
    public long UserId { get; set; }
    public string HashJwtToken { get; set; }
    public string HashRefreshToken { get; set; }
    public DateTime AccessTokenExpireDate { get; set; }
    public DateTime RefreshTokenExpireDate { get; set; }
    public string Device { get; set; }
}