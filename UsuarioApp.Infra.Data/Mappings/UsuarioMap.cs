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
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
           builder.ToTable("USUARIO");
           builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x=> x.Nome).HasColumnName("NOME").HasMaxLength(150).IsRequired();
            builder.Property(x=> x.Email).HasColumnName("EMAIL").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Senha).HasColumnName("SENHA").HasMaxLength(100).IsRequired();
            builder.Property(x => x.PerfilId).HasColumnName("PERFIL_ID").IsRequired();


            builder.HasOne(x => x.Perfil)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(x => x.PerfilId);
        }
    }
}
