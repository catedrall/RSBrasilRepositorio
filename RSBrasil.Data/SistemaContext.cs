﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RSBrasil.Data.Map;
using RSBrasil.Model.Entidades;
using RSBrasil.Shared.Model;
using RSBRasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RSBrasil.Data
{
    public class SistemaContext<T> : DbContext where T : ModelBase
    {
        public DbSet<T> Entity { get; set; }

        public SistemaContext()
        {
            //_configuration =  configuration;
            Database.EnsureCreated();//Cria o banco de dados, caso o mesmo não exista
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;user id=root;password=just4fun;port=3306;database=sistema;persistsecurityinfo=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}