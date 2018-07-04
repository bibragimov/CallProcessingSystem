using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Domain.EF.Mapping
{
    public class IdentityMap : EntityTypeConfiguration<Identity>
    {
        public IdentityMap()
        {
            ToTable("Identities");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.Email).HasColumnName("Email").IsRequired();
            Property(x => x.Name).HasColumnName("Name").IsRequired();
            Property(x => x.Password).HasColumnName("Password").IsRequired();
            Property(x => x.CreateDate).HasColumnName("CreateDate").IsRequired();
            Property(x => x.Avatar).HasColumnName("Avatar").IsOptional();
            Property(x => x.Role).HasColumnName("Role").IsRequired();
            Property(x => x.RecoveryPasswordCode).HasColumnName("RecoveryPasswordCode").IsOptional();
            Property(x => x.Locale).HasColumnName("Locale").IsOptional();
        }
    }
}