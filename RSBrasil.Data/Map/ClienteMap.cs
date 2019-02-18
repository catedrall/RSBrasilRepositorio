using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSBrasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.RazaoSocial)
                .HasColumnName("RazaoSocial");

            builder.Property(c => c.CNPJ)
                .HasColumnName("CNPJ");

            builder.Property(c => c.Contato)
                .HasColumnName("Contato");

            builder.Property(c => c.DataAlteracao)
                .HasColumnName("DataAlteracao");

            builder.Property(c => c.DataInclusao)
                .HasColumnName("DataInclusao");

            builder.Property(c => c.Email)
                .HasColumnName("Email");

            builder.Property(c => c.IdContrato)
                .HasColumnName("IdContrato");

            builder.Property(c => c.NomeFantasia)
                .HasColumnName("NomeFantasia");

            builder.Property(c => c.Telefone)
                .HasColumnName("Telefone");
        }
    }
}
