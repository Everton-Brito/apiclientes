using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaClientes_teste.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes_teste.Data.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("ENDERECO");

            builder.HasKey(e => e.IdEndereco);

            builder.Property(e => e.IdEndereco)
                .HasColumnName("IDENDERECO")
                .IsRequired();

            builder.Property(e => e.IdCliente)
                .HasColumnName("IDCLIENTE")
                .IsRequired();

            builder.Property(e => e.Rua)
                .HasColumnName("RUA")
                .IsRequired();

            builder.Property(e => e.Numero)
                .HasColumnName("NUMERO")
                .IsRequired();

            builder.Property(e => e.Complemento)
                .HasColumnName("COMPLEMENTO")
                .IsRequired();

            builder.Property(e => e.Bairro)
                .HasColumnName("BAIRRO")
                .IsRequired();

            builder.Property(e => e.Cidade)
                .HasColumnName("CIDADE")
                .IsRequired();

            builder.Property(e => e.Estado)
                .HasColumnName("ESTADO")
                .IsRequired();

            builder.Property(e => e.Cep)
                .HasColumnName("CEP")
                .IsRequired();

            builder.HasOne(e => e.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.IdCliente);
        }

      
    }
}
