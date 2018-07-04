using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Domain.EF.Mapping
{
    public class ExecutorMap : EntityTypeConfiguration<Executor>
    {
        public ExecutorMap()
        {
            ToTable("Executors");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id").IsRequired();

            HasMany(x => x.UserRequests).WithRequired(q => q.Executor).HasForeignKey(q => q.ExecutorId);
        }
    }
}