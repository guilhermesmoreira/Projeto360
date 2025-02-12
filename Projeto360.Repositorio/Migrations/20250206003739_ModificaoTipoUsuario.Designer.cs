﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Projeto360.Repositorio.Migrations
{
    [DbContext(typeof(Projeto360Contexto))]
    [Migration("20250206003739_ModificaoTipoUsuario")]
    partial class ModificaoTipoUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Projeto360.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("UsuarioId");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Ativo");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Senha");

                    b.Property<int>("Tipo")
                        .HasColumnType("INTEGER")
                        .HasColumnName("TipoDeUsuario");

                    b.HasKey("ID");

                    b.ToTable("Usuario", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
