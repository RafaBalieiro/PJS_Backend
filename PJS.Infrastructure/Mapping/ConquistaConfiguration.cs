using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJS.Domain.Entities._Conquista;

namespace PJS.Infrastructure.Mapping
{
    public class ConquistaConfiguration : IEntityTypeConfiguration<ConquistaEntity>
    {
        public void Configure(EntityTypeBuilder<ConquistaEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.XpBonus)
                .IsRequired();

            builder.Property(p => p.Logo)
                .HasColumnType("bytea");

            builder.HasMany(p => p.Perfis)
            .WithOne(cp => cp.Conquista)
            .HasForeignKey(cp => cp.ConquistaId)
            .OnDelete(DeleteBehavior.Cascade);

        }
    }
}