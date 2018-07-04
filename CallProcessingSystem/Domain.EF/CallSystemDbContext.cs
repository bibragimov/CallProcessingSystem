using System.Data.Entity;
using Domain.EF.Conventions;
using Domain.EF.Mapping;
using Domain.EF.Migrations;

namespace Domain.EF
{
    public class CallSystemDbContext : DbContext
    {
        public CallSystemDbContext()
            : base("MyDefault")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CallSystemDbContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add<DateTime2Convention>();

            modelBuilder.Configurations.Add(new IdentityMap());
            modelBuilder.Configurations.Add(new ExecutorMap());
            modelBuilder.Configurations.Add(new OperatorMap());
            modelBuilder.Configurations.Add(new UserRequestMap());
            modelBuilder.Configurations.Add(new RequestThemeMap());
        }
    }
}