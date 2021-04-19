using Km.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Km.Web.Data

{
    public class KmDbContext : IdentityDbContext<User, Role, int>
    {
        private readonly ILogger<KmDbContext> logger;
        public KmDbContext() { }

        public KmDbContext(DbContextOptions<KmDbContext> optins, ILoggerFactory loggerFactory)
            : base(optins)
        {
            logger = loggerFactory.CreateLogger<KmDbContext>();
        }


        //public override DbSet<User> Users { get; set; }
        //public override DbSet<Role> Roles { get; set; }
        public DbSet<Article> Articles  { get; set; }
        public DbSet<Tag> Tags { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUserLogin<int>>()
            .Property(login => login.UserId);

            builder.Entity<User>().ToTable("Core_User");
            builder.Entity<Role>().ToTable("Core_Role");
            builder.Entity<IdentityUserClaim<int>>().ToTable("Core_UserClaim");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("Core_RoleClaim");
            builder.Entity<IdentityUserRole<int>>().ToTable("Core_UserRole");
            builder.Entity<IdentityUserLogin<int>>().ToTable("Core_UserLogin");
            builder.Entity<IdentityUserToken<int>>().ToTable("Core_UserToken");

            builder.Entity<Article>(entity =>
            {
                entity.ToTable("Article");
            });
            builder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");
            });
        }
    }
}
