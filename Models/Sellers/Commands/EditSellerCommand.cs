﻿namespace KetabeKhoob.Razor.Models.Sellers.Commands;

public class EditSellerCommand
{
    public long Id { get; set; }
    public string ShopName { get; set; }
    public string NationalCode { get; set; }
    public SellerStatusDto SellerStatus { get; set; }
}