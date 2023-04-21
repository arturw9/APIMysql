﻿// <auto-generated />
using APIMysql.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIMysql.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20230421200827_itens")]
    partial class itens
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("APIMysql.Models.Itens", b =>
                {
                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("quantidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("valor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Nome");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("APIMysql.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Email");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
