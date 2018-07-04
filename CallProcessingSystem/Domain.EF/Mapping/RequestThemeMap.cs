using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Domain.EF.Mapping
{
    public class RequestThemeMap : EntityTypeConfiguration<RequestTheme>
    {
        public RequestThemeMap()
        {
            ToTable("RequestThemes");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.CreateDate).HasColumnName("CreateDate").IsRequired();
            Property(x => x.Title).HasColumnName("Title").IsRequired();

            HasMany(x => x.UserRequests).WithRequired(q => q.Theme).HasForeignKey(q => q.ThemeId);
        }
    }
}