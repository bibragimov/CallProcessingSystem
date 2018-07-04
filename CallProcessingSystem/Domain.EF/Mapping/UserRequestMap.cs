using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Domain.EF.Mapping
{
    public class UserRequestMap : EntityTypeConfiguration<UserRequest>
    {
        public UserRequestMap()
        {
            ToTable("UserRequests");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.CreateDate).HasColumnName("CreateDate").IsRequired();
            Property(x => x.UserName).HasColumnName("UserName").IsRequired();
            Property(x => x.Phone).HasColumnName("Phone").IsRequired();
            Property(x => x.ComplaintMessage).HasColumnName("ComplaintMessage").IsRequired();
            Property(x => x.Status).HasColumnName("Status").IsRequired();
            Property(x => x.Comment).HasColumnName("Comment").IsOptional();
        }
    }
}