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

namespace Km.Data.Repository
{
    public class KmContext : IdentityDbContext<User, Role, int>
    {
        private readonly ILogger<KmContext> logger;

        public KmContext(DbContextOptions<KmContext> optins, ILoggerFactory loggerFactory)
            : base(optins)
        {
            logger = loggerFactory.CreateLogger<KmContext>();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Core_User");
            builder.Entity<Role>().ToTable("Core_Role");
            builder.Entity<IdentityUserClaim<int>>().ToTable("Core_UserClaim");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("Core_RoleClaim");
            builder.Entity<IdentityUserRole<int>>().ToTable("Core_UserRole");
            builder.Entity<IdentityUserLogin<int>>().ToTable("Core_UserLogin");
            builder.Entity<IdentityUserToken<int>>().ToTable("Core_UserToken");

            builder.Entity<Article>().ToTable("Article");
            builder.Entity<Tag>().ToTable("Tag");
        }
    }
}
