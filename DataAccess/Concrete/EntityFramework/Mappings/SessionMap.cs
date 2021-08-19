using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
	public class SessionMap : IEntityTypeConfiguration<Session>
	{
		public void Configure(EntityTypeBuilder<Session> builder)
		{
			 builder.ToTable("Sessions");
			builder.HasKey(x => x.AccessToken);
			builder.Property(x => x.AccessToken).HasColumnName("AccessToken");
			builder.Property(x => x.RefreshToken).HasColumnName("RefreshToken");
			builder.Property(x => x.UserId).HasColumnName("UserId");
			builder.Property(x => x.IpAddress).HasColumnName("IpAddress");
			builder.Property(x => x.IsActive).HasColumnName("IsActive");
			builder.Property(x => x.SessionExpireDate).HasColumnName("SessionExpireDate");
			builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
			builder.Property(x => x.UserAgent).HasColumnName("UserAgent");
		}
	}
}

