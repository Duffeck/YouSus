namespace yousus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataRotas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiasSemana = c.Int(nullable: false),
                        DiaUnico = c.DateTime(nullable: false),
                        Horario = c.DateTime(nullable: false),
                        DataCriacao = c.DateTime(),
                        DataAtualizacao = c.DateTime(),
                        RotaColeta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RotaColetas", t => t.RotaColeta_Id)
                .Index(t => t.RotaColeta_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DataRotas", "RotaColeta_Id", "dbo.RotaColetas");
            DropIndex("dbo.DataRotas", new[] { "RotaColeta_Id" });
            DropTable("dbo.DataRotas");
        }
    }
}
