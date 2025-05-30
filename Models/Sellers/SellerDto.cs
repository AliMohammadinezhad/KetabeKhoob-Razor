﻿namespace KetabeKhoob.Razor.Models.Sellers;

public class SellerDto : BaseDto
{
    public long UserId { get; set; }
    public string ShopName { get; set; }
    public string NationalCode { get; set; }
    public SellerStatusDto Status { get; set; }
}