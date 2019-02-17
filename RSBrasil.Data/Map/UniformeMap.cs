using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSBrasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Data.Map
{
    public class UniformeMap
    {
        public void Configure(EntityTypeBuilder<Uniforme> builder)
        {
            builder.ToTable("uniforme");

            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Descricao)
                .HasColumnName("Descricao");

            builder.Property(c => c.DataCompra)
                .HasColumnName("DataCompra");

            builder.Property(c => c.Duracao)
                .HasColumnName("Duracao");

            builder.Property(c => c.DataAlteracao)
                .HasColumnName("DataAlteracao");

            builder.Property(c => c.DataInclusao)
                .HasColumnName("DataInclusao");
        }
    }
}
