using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsuarioApp.Domain.Entities;

namespace UsuarioApp.Infra.Data.Mappings
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("PERFIL");
            builder.HasKey(x => x.Id);

            builder.Property(x=> x.Id).HasColumnName("ID");
            builder.Property(x=> x.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(25)
                .IsRequired();

            builder.HasIndex(x => x.Nome)
                .IsUnique();
        }
    }
}
