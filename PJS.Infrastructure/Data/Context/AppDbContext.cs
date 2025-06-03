using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PJS.Domain.Entities._Assoc._ConquistaPerfilAssoc;
using PJS.Domain.Entities._Conquista;
using PJS.Domain.Entities._Evento;
using PJS.Domain.Entities._Nivel;
using PJS.Domain.Entities._Perfil;
using PJS.Domain.Entities._Rotina;
using PJS.Domain.Entities._Tarefas;
using PJS.Domain.Entities._Usuario;
using PJS.Infrastructure.Mapping;

namespace PJS.Infrastructure.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<PerfilEntity> Perfis { get; set; }
        public DbSet<TarefaEntity> Tarefas { get; set; }
        public DbSet<RotinaEntity> Rotinas { get; set; }
        public DbSet<EventoEntity> Eventos { get; set; }
        public DbSet<ConquistaEntity> Conquistas { get; set; }
        public DbSet<NivelEntity> Niveis { get; set; }
        public DbSet<ConquistaPerfilAssocEntity> ConquistasPerfisAssoc { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ConquistaPerfilAssocConfiguration());
            modelBuilder.ApplyConfiguration(new PerfilConfiguration());
            modelBuilder.ApplyConfiguration(new ConquistaConfiguration());
        }

    }
}