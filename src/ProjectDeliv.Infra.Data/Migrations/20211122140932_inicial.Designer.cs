﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectDeliv.Infra.Data.Contexts;

#nullable disable

namespace ProjectDeliv.Infra.Data.Migrations
{
    [DbContext(typeof(ContextSQL))]
    [Migration("20211122140932_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("ProjectDeliv.Domain.Entidades.ProdutoGrupo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("AtualizadoPor")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deletado")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DeletadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeletadoPor")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagemUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("InseridoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("InseridoPor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProdutoGrupo");
                });
#pragma warning restore 612, 618
        }
    }
}