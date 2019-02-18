using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSBrasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Data.Map
{
    public class HistoricoBeneficiosMap
    {
        public void Configure(EntityTypeBuilder<HistoricoBeneficios> builder)
        {
            builder.ToTable("historicobeneficios");

            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.IdTipoBeneficios)
                .HasColumnName("IdTipoBeneficios");

            builder.Property(c => c.IdFuncionario)
                .HasColumnName("IdFuncionario");

            builder.Property(c => c.DataPagamento)
                .HasColumnName("DataPagamento");

            builder.Property(c => c.DataInclusao)
                .HasColumnName("DataInclusao");

            builder.Property(c => c.DataAlteracao)
                .HasColumnName("DataAlteracao");
        }
    }
}
