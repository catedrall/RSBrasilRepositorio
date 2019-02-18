using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RSBrasil.Data.Map;
using RSBrasil.Model.Entidades;
using RSBrasil.Shared.Model;
using RSBRasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RSBrasil.Data
{
    public class SistemaContext<T> : DbContext where T : ModelBase
    {
        public DbSet<T> Entity { get; set; }

        public SistemaContext()
        {
            //_configuration =  configuration;
            Database.EnsureCreated();//Cria o banco de dados, caso o mesmo não exista
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AfastamentoMedico>(new AfastamentoMedicoMap().Configure);
            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
            modelBuilder.Entity<Enderecos>(new EnderecosMap().Configure);
            modelBuilder.Entity<Uniforme>(new UniformeMap().Configure);
            modelBuilder.Entity<HistoricoFalta>(new HistoricoFaltaMap().Configure);
            modelBuilder.Entity<HistoricoBeneficios>(new HistoricoBeneficiosMap().Configure);
            modelBuilder.Entity<HistoricoSalarios>(new HistoricoSalariosMap().Configure);
            modelBuilder.Entity<TipoAfastamentos>(new TipoAfastamentosMap().Configure);
            modelBuilder.Entity<TipoBeneficios>(new TipoBeneficiosMap().Configure);
            modelBuilder.Entity<TipoDocumentos>(new TipoDocumentosMap().Configure);
            modelBuilder.Entity<HistoricoPunicao>(new HistoricoPunicaoMap().Configure);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql("server=127.0.0.1;user id=root;password=Zq1Xw2Ce3;port=3306;database=sistema;persistsecurityinfo=True");
            optionsBuilder.UseMySql("server=localhost;user id=root;password=just4fun;port=3306;database=sistema;persistsecurityinfo=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
