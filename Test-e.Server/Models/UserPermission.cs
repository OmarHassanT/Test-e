﻿namespace Test_e.Server.Models
{
    public class UserPermission
    {
        public int UserId { get; set; }
        public User User { get; set; } = default!;

        public int PermissionId { get; set; }
        public Permission Permission { get; set; } = default!;
    }
}
