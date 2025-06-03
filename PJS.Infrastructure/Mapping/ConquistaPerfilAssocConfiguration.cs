using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJS.Domain.Entities._Assoc._ConquistaPerfilAssoc;
using PJS.Domain.Entities._Conquista;
using PJS.Domain.Entities._Perfil;

namespace PJS.Infrastructure.Mapping
{
    public class ConquistaPerfilAssocConfiguration : IEntityTypeConfiguration<ConquistaPerfilAssocEntity>
    {
        public void Configure(EntityTypeBuilder<ConquistaPerfilAssocEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ConquistaId)
                .IsRequired();

            builder.Property(c => c.PerfilId)
                .IsRequired();

            builder.HasOne(c => c.Conquista)
                .WithMany(c => c.Perfis)
                .HasForeignKey(c => c.ConquistaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Perfil)
                .WithMany(p => p.Conquistas)
                .HasForeignKey(c => c.PerfilId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}