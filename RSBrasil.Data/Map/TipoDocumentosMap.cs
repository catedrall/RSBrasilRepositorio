using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSBrasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Data.Map
{
    public class TipoDocumentosMap
    {
        public void Configure(EntityTypeBuilder<TipoDocumentos> builder)
        {
            builder.ToTable("tipodocumento");

            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Descricao)
                .HasColumnName("Descricao");
            
            builder.Property(c => c.DataAlteracao)
                .HasColumnName("DataAlteracao");

            builder.Property(c => c.DataInclusao)
                .HasColumnName("DataInclusao");
        }
    }
}
