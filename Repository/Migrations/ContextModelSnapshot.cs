﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

namespace Repository.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Beneficio", b =>
                {
                    b.Property<int>("BeneficioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("Descricao");

                    b.Property<int?>("EmpresaId");

                    b.Property<int>("Nivel");

                    b.Property<string>("Nome");

                    b.HasKey("BeneficioId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Beneficios");
                });

            modelBuilder.Entity("Domain.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CadastradoEm");

                    b.Property<string>("Email");

                    b.Property<long?>("EnderecoId");

                    b.Property<string>("Genero");

                    b.Property<string>("Nome");

                    b.Property<string>("Telefone");

                    b.HasKey("ClienteId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Domain.Empresa", b =>
                {
                    b.Property<int>("EmpresaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cnpj");

                    b.Property<DateTime>("CriadaEm");

                    b.Property<string>("Email");

                    b.Property<long?>("EnderecoId");

                    b.Property<string>("Razao");

                    b.Property<string>("Senha");

                    b.Property<string>("Telefone");

                    b.HasKey("EmpresaId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Domain.EmpresaCliente", b =>
                {
                    b.Property<int>("EmpresaClienteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteId");

                    b.Property<DateTime>("ContratadaEm");

                    b.Property<int?>("EmpresaId");

                    b.Property<int>("Nivel");

                    b.Property<int?>("PlanoId");

                    b.HasKey("EmpresaClienteId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("PlanoId");

                    b.ToTable("ClientesDaEmpresa");
                });

            modelBuilder.Entity("Domain.EmpresaEmpresa", b =>
                {
                    b.Property<int>("EmpresaEmpresaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CriadoEm");

                    b.Property<int?>("EmpresaDoisEmpresaId");

                    b.Property<int?>("EmpresaUmEmpresaId");

                    b.HasKey("EmpresaEmpresaId");

                    b.HasIndex("EmpresaDoisEmpresaId");

                    b.HasIndex("EmpresaUmEmpresaId");

                    b.ToTable("ParceiroDaEmpresa");
                });

            modelBuilder.Entity("Domain.Endereco", b =>
                {
                    b.Property<long>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro");

                    b.Property<string>("Cep");

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("Localidade");

                    b.Property<string>("Logradouro");

                    b.Property<string>("Uf");

                    b.HasKey("EnderecoId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Domain.Plano", b =>
                {
                    b.Property<int>("PlanoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<int?>("EmpresaId");

                    b.Property<int>("Nivel");

                    b.Property<string>("Nome");

                    b.Property<double>("Preco");

                    b.HasKey("PlanoId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Planos");
                });

            modelBuilder.Entity("Domain.Beneficio", b =>
                {
                    b.HasOne("Domain.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId");
                });

            modelBuilder.Entity("Domain.Cliente", b =>
                {
                    b.HasOne("Domain.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");
                });

            modelBuilder.Entity("Domain.Empresa", b =>
                {
                    b.HasOne("Domain.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");
                });

            modelBuilder.Entity("Domain.EmpresaCliente", b =>
                {
                    b.HasOne("Domain.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("Domain.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId");

                    b.HasOne("Domain.Plano", "Plano")
                        .WithMany()
                        .HasForeignKey("PlanoId");
                });

            modelBuilder.Entity("Domain.EmpresaEmpresa", b =>
                {
                    b.HasOne("Domain.Empresa", "EmpresaDois")
                        .WithMany()
                        .HasForeignKey("EmpresaDoisEmpresaId");

                    b.HasOne("Domain.Empresa", "EmpresaUm")
                        .WithMany()
                        .HasForeignKey("EmpresaUmEmpresaId");
                });

            modelBuilder.Entity("Domain.Plano", b =>
                {
                    b.HasOne("Domain.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId");
                });
#pragma warning restore 612, 618
        }
    }
}
