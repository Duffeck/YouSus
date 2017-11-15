namespace yousus.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Linq;
    using yousus.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<yousus.Models.YouSusContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //var configuration = new DbMigrationsConfiguration();
            //var migrator = new DbMigrator(this);
            //migrator.Update();
        }

        protected override void Seed(yousus.Models.YouSusContext context)
        {
            context.Usuarios.AddOrUpdate(x => x.Id,
                new Usuario() {Id = 1, Nome = "Lucas Duffeck", Email = "lucas", Senha = "senha"}
            );
        }

        public void InitializeDatabase(YouSusContext context)
        {
            if (!context.Database.Exists() || !context.Database.CompatibleWithModel(false))
            {
                var configuration = new DbMigrationsConfiguration();
                var migrator = new DbMigrator(configuration);
                migrator.Configuration.TargetDatabase = new DbConnectionInfo(context.Database.Connection.ConnectionString, "System.Data.SqlClient");
                var migrations = migrator.GetPendingMigrations();
                if (migrations.Any())
                {
                    var scriptor = new MigratorScriptingDecorator(migrator);
                    var script = scriptor.ScriptUpdate(null, migrations.Last());

                    if (!string.IsNullOrEmpty(script))
                    {
                        context.Database.ExecuteSqlCommand(script);
                    }
                }
            }
        }
    }
}
