using Microsoft.EntityFrameworkCore;
using PAT.AccessModel.Models.Info;
using PAT.AccessModel.Models.PermessionsRolesModels;



namespace PAT.AccessModel.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<AboutUs> AboutUs { get; set; }

        public DbSet<Role> UsersRoles { get; set; }

        public DbSet<User> Users { get; set; }


        public DbSet<UserType> UserTypes { get; set; }





        // permessions Models
        public DbSet<MethodType> MethodTypes { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);














        }

    }

}