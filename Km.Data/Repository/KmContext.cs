using Km.Data.Helpers;
using Km.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // find entities and model builders from app assemblies
            var entityTypes = TypeFinder.Find<Entity>();
            var modelBuilderTypes = TypeFinder.Find<IEntityModelBuilder>();

            // add entity types to the model
            foreach (var type in entityTypes)
            {
                modelBuilder.Entity(type);
                logger.LogDebug($"Entity: '{type.Name}' added to model");
            }

            // call base
            base.OnModelCreating(modelBuilder);


            // add mappings and relations
            foreach (var builderType in modelBuilderTypes)
            {
                if (builderType != null && builderType != typeof(IEntityModelBuilder))
                {
                    logger.LogDebug($"ModelBuilder '{builderType.Name}' added to model");
                    var builder = (IEntityModelBuilder)Activator.CreateInstance(builderType);
                    builder.CreateModel(modelBuilder);
                }
            }






            //builder.Entity<User>().ToTable("Core_User");
            //builder.Entity<Role>().ToTable("Core_Role");
            //builder.Entity<IdentityUserClaim<int>>().ToTable("Core_UserClaim");
            //builder.Entity<IdentityRoleClaim<int>>().ToTable("Core_RoleClaim");
            //builder.Entity<IdentityUserRole<int>>().ToTable("Core_UserRole");
            //builder.Entity<IdentityUserLogin<int>>().ToTable("Core_UserLogin");
            //builder.Entity<IdentityUserToken<int>>().ToTable("Core_UserToken");

            ////builder.Entity<Article>().ToTable("Article");
            ////builder.Entity<Tag>().ToTable("Tag");

            //builder.Entity<Article>(entity =>
            //{
            //    entity.ToTable("Articles");
            //    entity.HasKey(e => e.Id);
            //});
            //builder.Entity<Tag>(entity =>
            //{
            //    entity.ToTable("Tags");
            //    entity.HasKey(e => e.Id);
            //});
        }
    }
}
