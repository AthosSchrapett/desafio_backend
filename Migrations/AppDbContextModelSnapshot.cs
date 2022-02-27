﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using desafio_backend.Data;

#nullable disable

namespace desafio_backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("desafio_backend.Models.Pagamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("ValorPago")
                        .HasColumnType("double precision");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("desafio_backend.Models.Troco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("PagamentoId")
                        .HasColumnType("uuid");

                    b.Property<double>("ValorTroco")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("PagamentoId");

                    b.ToTable("Troco");
                });

            modelBuilder.Entity("desafio_backend.Models.Troco", b =>
                {
                    b.HasOne("desafio_backend.Models.Pagamento", "Pagamento")
                        .WithMany()
                        .HasForeignKey("PagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pagamento");
                });
#pragma warning restore 612, 618
        }
    }
}