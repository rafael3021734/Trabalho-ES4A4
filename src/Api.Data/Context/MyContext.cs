using Api.Domain.Entities;
using Api.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { } //Construtor da classe mycontext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrador",
                    Email = "rafael_santospg@yahoo.com.br",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                }
            );
        }


    }
}
