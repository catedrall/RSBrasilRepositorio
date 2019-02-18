using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSBrasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSBrasil.Data.Map
{
    public class EnderecosMap : IEntityTypeConfiguration<Enderecos>
    {
        public void Configure(EntityTypeBuilder<Enderecos> builder)
        {
            builder.ToTable("enderecos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Bairro)
                .HasColumnName("bairro");

            builder.Property(c => c.Cep)
                .HasColumnName("cep");

            builder.Property(c => c.Cidade)
                .HasColumnName("cidade");

            builder.Property(c => c.Complemento)
                .HasColumnName("complemento");

            builder.Property(c => c.DataAlteracao)
                .HasColumnName("DataAlteracao");

            builder.Property(c => c.DataInclusao)
                .HasColumnName("DataInclusao");

            builder.Property(c => c.Idclientefuncionario)
                .HasColumnName("idclientefuncionario");

            builder.Property(c => c.Logradouro)
                .HasColumnName("logradouro");

            builder.Property(c => c.Numero)
                .HasColumnName("numero");

            builder.Property(c => c.Pais)
                .HasColumnName("pais");

            builder.Property(c => c.Residenciapropria)
                .HasColumnName("residenciapropria");

            builder.Property(c => c.Uf)
                .HasColumnName("uf");
        }
    }
}
