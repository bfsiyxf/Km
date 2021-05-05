
using Km.Data.Model;
using Km.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fan.Data
{
    /// <summary>
    /// The core entity model.
    /// </summary>
    public class CoreEntityModelBuilder : IEntityModelBuilder
    {
        public void CreateModel(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Core_User");
            builder.Entity<Role>().ToTable("Core_Role");
            builder.Entity<IdentityUserClaim<int>>().ToTable("Core_UserClaim");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("Core_RoleClaim");
            builder.Entity<IdentityUserRole<int>>().ToTable("Core_UserRole");
            builder.Entity<IdentityUserLogin<int>>().ToTable("Core_UserLogin");
            builder.Entity<IdentityUserToken<int>>().ToTable("Core_UserToken");
            builder.Entity<Article>(entity =>
            {
                entity.ToTable("Articles");
                entity.HasKey(e => e.Id);
            });
            builder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tags");
                entity.HasKey(e => e.Id);
            });
            builder.Entity<ArticleTag>(entity =>
            {
                entity.ToTable("ArticleTag");
                entity.HasKey(e =>new { e.ArticlesId, e.TagsId });
            });
        }
    }
}
