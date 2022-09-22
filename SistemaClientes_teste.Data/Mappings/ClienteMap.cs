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
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTE");

            builder.HasKey(c => c.IdCliente);

            builder.Property(c => c.IdCliente)
                    .HasColumnName("IDCLIENTE")
                   .IsRequired();

            builder.Property(c => c.Nome)
                    .HasColumnName("NOME")
                    .HasMaxLength(150)
                    .IsRequired();
            builder.Property(c => c.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsRequired();
            builder.Property(c => c.Telefone)
                    .HasColumnName("TELEFONE")
                    .HasMaxLength(11)
                    .IsRequired();
            builder.Property(c => c.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsRequired();
            builder.HasIndex(c => c.Email)
                    .IsUnique();

            builder.Property(c => c.DataNascimento)
                    .HasColumnName("DATANASCIMENTO")
                    .IsRequired();
        }
    }
}
