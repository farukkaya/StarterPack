using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
	public class UserMap : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			 builder.ToTable("Users");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasColumnName("Id");
			builder.Property(x => x.IdentityNo).HasColumnName("IdentityNo");
			builder.Property(x => x.FirstName).HasColumnName("FirstName");
			builder.Property(x => x.LastName).HasColumnName("LastName");
			builder.Property(x => x.Email).HasColumnName("Email");
			builder.Property(x => x.PasswordSalt).HasColumnName("PasswordSalt");
			builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash");
			builder.Property(x => x.IsActive).HasColumnName("IsActive");
			builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
			builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy");
			builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
			builder.Property(x => x.UpdatedBy).HasColumnName("UpdatedBy");
			builder.Property(x => x.IsDeleted).HasColumnName("IsDeleted");
			builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");
			builder.Property(x => x.DeletedBy).HasColumnName("DeletedBy");
		}
	}
}

