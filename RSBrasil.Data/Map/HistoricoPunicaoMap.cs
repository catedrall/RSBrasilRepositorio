using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSBrasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Data.Map
{
    public class HistoricoPunicaoMap : IEntityTypeConfiguration<HistoricoPunicao>
    {
        public void Configure(EntityTypeBuilder<HistoricoPunicao> builder)
        {
            builder.ToTable("historicopunicoes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.DataPunicao)
                .HasColumnName("DataPunicao");

            builder.Property(c => c.Descricao)
                .HasColumnName("Descricao");

            builder.Property(c => c.IdFuncionario)
                .HasColumnName("IdFuncionario");

            builder.Property(c => c.DataAlteracao)
                .HasColumnName("DataAlteracao");

            builder.Property(c => c.DataInclusao)
                .HasColumnName("DataInclusao");
        }
    }
}