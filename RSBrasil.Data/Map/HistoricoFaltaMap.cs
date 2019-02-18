using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSBrasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Data.Map
{
    public class HistoricoFaltaMap : IEntityTypeConfiguration<HistoricoFalta>
    {
        public void Configure(EntityTypeBuilder<HistoricoFalta> builder)
        {
            builder.ToTable("historicodefalta");

            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.DataFalta)
                .HasColumnName("DataFalta");

            builder.Property(c => c.IdCliente)
                .HasColumnName("IdCliente");

            builder.Property(c => c.DataAlteracao)
                .HasColumnName("DataAlteracao");

            builder.Property(c => c.DataInclusao)
                .HasColumnName("DataInclusao");

            builder.Property(c => c.IdCliente)
                .HasColumnName("IdFuncionario");

        }
    }
}
