using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
	public class LanguageMap : IEntityTypeConfiguration<Language>
	{
		public void Configure(EntityTypeBuilder<Language> builder)
		{
			 builder.ToTable("Languages");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasColumnName("Id");
			builder.Property(x => x.LangKey).HasColumnName("LangKey");
			builder.Property(x => x.Name).HasColumnName("Name");
			builder.Property(x => x.LocalName).HasColumnName("LocalName");
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

