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

            context.Origems.AddOrUpdate(x => x.Id,
                new Origem() { Id = 1, Descricao = "Domiciliar", Peso = 1},
                new Origem() { Id = 2, Descricao = "Comercial", Peso = 1 },
                new Origem() { Id = 3, Descricao = "Industrial", Peso = 1 },
                new Origem() { Id = 4, Descricao = "Hospitalar", Peso = 1 },
                new Origem() { Id = 5, Descricao = "Limpesa Pública", Peso = 1 }
            );

            context.Tipoes.AddOrUpdate(x => x.Id,
                new Tipo() { Id = 1, Descricao = "Reciclável", Peso = 1 },
                new Tipo() { Id = 2, Descricao = "Não Reciclável", Peso = 1 }
            );

            context.ComposicaoQuimicas.AddOrUpdate(x => x.Id,
                new ComposicaoQuimica() { Id = 1, Descricao = "Papel", Peso = 1 },
                new ComposicaoQuimica() { Id = 2, Descricao = "Vidro", Peso = 1 },
                new ComposicaoQuimica() { Id = 3, Descricao = "Plástico", Peso = 1 },
                new ComposicaoQuimica() { Id = 4, Descricao = "Metal", Peso = 1 },
                new ComposicaoQuimica() { Id = 5, Descricao = "Orgânico", Peso = 1 }
            );

            context.Periculosidades.AddOrUpdate(x => x.Id,
                new Periculosidade() { Id = 1, Descricao = "Tóxico", Peso = 1 },
                new Periculosidade() { Id = 2, Descricao = "Inflamável", Peso = 1 },
                new Periculosidade() { Id = 3, Descricao = "Radioativo", Peso = 1 },
                new Periculosidade() { Id = 4, Descricao = "Corrosivo", Peso = 1 }
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
