using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSBRasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Data.Map
{
    public class AfastamentoMedicoMap : IEntityTypeConfiguration<AfastamentoMedico>
    {
        public void Configure(EntityTypeBuilder<AfastamentoMedico> builder)
        {
            builder.ToTable("afastamentomedico");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.DataFimAfastamento)
                .HasColumnName("DataFimAfastamento");

            builder.Property(c => c.DataInicioAfastamento)
                .HasColumnName("DataInicioAfastamento");

            builder.Property(c => c.DataAlteracao)
                .HasColumnName("DataAlteracao");

            builder.Property(c => c.DataInclusao)
                .HasColumnName("DataInclusao");

            builder.Property(c => c.Descricao)
                .HasColumnName("Descricao");

            builder.Property(c => c.IdDocumento)
                .HasColumnName("IdDocumento");

            builder.Property(c => c.IdFuncionario)
                .HasColumnName("IdFuncionario");

            builder.Property(c => c.IdTipoAfastamento)
                .HasColumnName("IdTipoAfastamento");

        }
    }
}
