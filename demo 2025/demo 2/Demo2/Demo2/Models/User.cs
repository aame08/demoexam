namespace Demo2.Models;

public partial class User
{
    public int UserId { get; set; }

    public string SurnameUser { get; set; } = null!;

    public string NameUser { get; set; } = null!;

    public string PatronymicUser { get; set; } = null!;

    public string LoginUser { get; set; } = null!;

    public string PasswordUser { get; set; } = null!;

    public int RoleUser { get; set; }

    public virtual Role RoleUserNavigation { get; set; } = null!;
}
