using System.Security;

namespace KetabeKhoob.Razor.Models.Roles;

public class RoleDto : BaseDto
{
    public string Title { get; set; }
    public List<Permission>? Permissions { get; set; }
}


public enum Permission
{
    PanelAdmin,
    EditProfile,
    ChangePassword,
    CrudBanner,
    CrudSlider,
    CurdUser,
    CrudProduct,
    SellerManagement,
    OrderManagement,
    RoleManagement,
    CommentManagement,
    CategoryManagement,
    AddInventory,
    EditInventory,
    ChangeStatusInventory,
    UserManagement,
    SellerPanel
}