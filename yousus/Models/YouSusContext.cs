using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace yousus.Models
{
    public class YouSusContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public YouSusContext() : base("name=YouSusContext")
        {
        }

        public System.Data.Entity.DbSet<yousus.Models.Usuario> Usuarios { get; set; }

        public List<TBase> ListarTodos<TBase>() where TBase : Base
        {
            return Set<TBase>().ToList();
        }

        public List<TBase> Buscar<TBase>(Expression<Func<TBase, bool>> where) where TBase : Base
        {
            return Set<TBase>().Where(where).ToList();
        }

        public TBase BuscarPorId<TBase>(int id) where TBase : Base
        {
            return Set<TBase>().FirstOrDefault(e => e.Id == id);
        }

        public void Inserir<TBase>(TBase obj) where TBase : Base
        {
            obj.DataCriacao = DateTime.Now;
            obj.DataAtualizacao = DateTime.Now;
            Set<TBase>().Add(obj);
            SaveChanges();
        }

        public List<TBase> BuscarComPaginacao<TBase>(Expression<Func<TBase, bool>> where, int take, int skip) where TBase : Base
        {
            return Set<TBase>()
                .Where(where)
                .OrderBy(o => o.Id)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public void Atualizar<TBase>(TBase obj) where TBase : Base
        {
            obj.DataAtualizacao = DateTime.Now;
            SaveChanges();
        }

        public void Excluir<TBase>(TBase obj) where TBase : Base
        {
            Set<TBase>().Remove(obj);
            SaveChanges();
        }

        public void Excluir<TBase>(Expression<Func<TBase, bool>> where) where TBase : Base
        {
            var lista = Set<TBase>().Where(where).ToList();
            Set<TBase>().RemoveRange(lista);
            SaveChanges();
        }

        public System.Data.Entity.DbSet<yousus.Models.Evento> Eventoes { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.Alerta> Alertas { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.Acao> Acaos { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.Area> Areas { get; set; }
    
        public System.Data.Entity.DbSet<yousus.Models.Administrador> Administradores { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.ComposicaoQuimica> ComposicaoQuimicas { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.DataRota> DataRotas { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.Denuncia> Denuncias { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.Foto> Fotoes { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.Informativo> Informativoes { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.Localizacao> Localizacaos { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.Modulo> Moduloes { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.Origem> Origems { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.Periculosidade> Periculosidades { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.Periodo> Periodoes { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.PontoDescarte> PontoDescartes { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.Privilegio> Privilegios { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.Residuo> Residuos { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.RotaColeta> RotaColetas { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.Tipo> Tipoes { get; set; }

        public System.Data.Entity.DbSet<yousus.Models.ZonaVerde> ZonaVerdes { get; set; }
    }
}
