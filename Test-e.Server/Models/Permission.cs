namespace Test_e.Server.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string Key { get; set; } = default!;   // e.g. "Products.View"
        public string? Description { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();

    }
}
