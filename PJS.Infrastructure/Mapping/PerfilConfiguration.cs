using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJS.Domain.Entities._Perfil;

namespace PJS.Infrastructure.Mapping
{
    public class PerfilConfiguration : IEntityTypeConfiguration<PerfilEntity>
    {
        public void Configure(EntityTypeBuilder<PerfilEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.DataNascimento)
                .IsRequired();

            builder.Property(p => p.UsuarioId)
                .IsRequired();

            builder.Property(p => p.NivelId)
                .IsRequired();

            builder.HasOne(p => p.Nivel)
                .WithMany()
                .HasForeignKey(p => p.NivelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Conquistas)
                .WithOne(c => c.Perfil)
                .HasForeignKey(c => c.PerfilId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}