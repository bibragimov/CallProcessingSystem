using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Domain.EF.Mapping
{
    public class OperatorMap : EntityTypeConfiguration<Operator>
    {
        public OperatorMap()
        {
            ToTable("Operators");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id").IsRequired();

            HasMany(x => x.UserRequests).WithRequired(q => q.Operator).HasForeignKey(q => q.OperatorId);
        }
    }
}