using Flunt.Notifications;
using GoodHealth.Data.Usuario.Configurations;
using ModelUser = GoodHealth.Domain.Usuario.Entities;
using ModelEmpresa = GoodHealth.Domain.Empresa.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace GoodHealth.Data.Shared.Context
{
    public class GlobalContext : DbContext
    {
        public DbSet<ModelUser.Usuario> Usuario { get; set; }
        public DbSet<ModelEmpresa.Empresa> Empresa { get; set; }

        public GlobalContext(DbContextOptions<GlobalContext> options) : base(options)
        {
            Database.SetCommandTimeout(TimeSpan.FromMinutes(1));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

        }
    }
}