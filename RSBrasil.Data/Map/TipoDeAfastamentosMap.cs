using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSBrasil.Model.Entidades;

namespace RSBrasil.Data.Map
{
    public class TipoDeAfastamentosMap
    {
        public void Configure(EntityTypeBuilder<TipoDeAfastamentos> builder)
        {
            builder.ToTable("tipoafastamento");

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
