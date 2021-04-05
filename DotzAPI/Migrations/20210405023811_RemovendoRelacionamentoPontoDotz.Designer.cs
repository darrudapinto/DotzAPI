﻿// <auto-generated />
using System;
using DotzAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotzAPI.Migrations
{
    [DbContext(typeof(AplicacaoDbContexto))]
    [Migration("20210405023811_RemovendoRelacionamentoPontoDotz")]
    partial class RemovendoRelacionamentoPontoDotz
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("DotzAPI.Modelos.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("DotzAPI.Modelos.CategoriaSubcategoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("SubcategoriaId")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId", "SubcategoriaId");

                    b.HasIndex("SubcategoriaId");

                    b.ToTable("CategoriaSubcategorias");
                });

            modelBuilder.Entity("DotzAPI.Modelos.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Cep")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Cidade")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Complemento")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Estado")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Logradouro")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("EnderecoId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("DotzAPI.Modelos.PontoDotz", b =>
                {
                    b.Property<int>("PontoDotzId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EmpresaGeradora")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("TipoOperacao")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("PontoDotzId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("PontosDotz");
                });

            modelBuilder.Entity("DotzAPI.Modelos.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("QuantidadePontosDotzParaResgate")
                        .HasColumnType("int");

                    b.Property<int?>("SubcategoriaId")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId");

                    b.HasIndex("SubcategoriaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("DotzAPI.Modelos.Subcategoria", b =>
                {
                    b.Property<int>("SubcategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("SubcategoriaId");

                    b.ToTable("SubCategorias");
                });

            modelBuilder.Entity("DotzAPI.Modelos.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("QuantidadePontosDotzAcumulados")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("DotzAPI.Modelos.CategoriaSubcategoria", b =>
                {
                    b.HasOne("DotzAPI.Modelos.Categoria", "Categoria")
                        .WithMany("CategoriaSubcategorias")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotzAPI.Modelos.Subcategoria", "Subcategoria")
                        .WithMany("CategoriaSubcategorias")
                        .HasForeignKey("SubcategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Subcategoria");
                });

            modelBuilder.Entity("DotzAPI.Modelos.Endereco", b =>
                {
                    b.HasOne("DotzAPI.Modelos.Usuario", "Usuario")
                        .WithOne("Endereco")
                        .HasForeignKey("DotzAPI.Modelos.Endereco", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("DotzAPI.Modelos.PontoDotz", b =>
                {
                    b.HasOne("DotzAPI.Modelos.Usuario", "Usuario")
                        .WithMany("PontosDotz")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("DotzAPI.Modelos.Produto", b =>
                {
                    b.HasOne("DotzAPI.Modelos.Subcategoria", null)
                        .WithMany("Produtos")
                        .HasForeignKey("SubcategoriaId");
                });

            modelBuilder.Entity("DotzAPI.Modelos.Categoria", b =>
                {
                    b.Navigation("CategoriaSubcategorias");
                });

            modelBuilder.Entity("DotzAPI.Modelos.Subcategoria", b =>
                {
                    b.Navigation("CategoriaSubcategorias");

                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("DotzAPI.Modelos.Usuario", b =>
                {
                    b.Navigation("Endereco");

                    b.Navigation("PontosDotz");
                });
#pragma warning restore 612, 618
        }
    }
}
