﻿// <auto-generated />
using System;
using LocadoraVeiculos.Infra.Orm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    [DbContext(typeof(GeradorLocadoraDbContext))]
    [Migration("20220721182017_CampoUnicoEObrigatorio")]
    partial class CampoUnicoEObrigatorio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloTaxas.Taxas", b =>
                {
                    b.Property<Guid>("Id")
                        .IsUnicode(true)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TB_TAXAS");
                });
#pragma warning restore 612, 618
        }
    }
}