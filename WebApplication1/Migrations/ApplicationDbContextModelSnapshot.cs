﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Mesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<bool>("EstaDisponible")
                        .HasColumnType("bit");

                    b.Property<int>("RestauranteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestauranteId");

                    b.ToTable("Mesas");
                });

            modelBuilder.Entity("WebApplication1.Models.Resena", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Calificacion")
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestauranteId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestauranteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Resenas");
                });

            modelBuilder.Entity("WebApplication1.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaHoraReserva")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumeroDePersonas")
                        .HasColumnType("int");

                    b.Property<string>("PeticionesEspeciales")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestauranteId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestauranteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("WebApplication1.Models.Restaurante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Cocina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Restaurantes");
                });

            modelBuilder.Entity("WebApplication1.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebApplication1.Models.Mesa", b =>
                {
                    b.HasOne("WebApplication1.Models.Restaurante", "Restaurante")
                        .WithMany("Mesas")
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurante");
                });

            modelBuilder.Entity("WebApplication1.Models.Resena", b =>
                {
                    b.HasOne("WebApplication1.Models.Restaurante", "Restaurante")
                        .WithMany("Resenas")
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Usuario", "Usuario")
                        .WithMany("Resenas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurante");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebApplication1.Models.Reserva", b =>
                {
                    b.HasOne("WebApplication1.Models.Restaurante", "Restaurante")
                        .WithMany("Reservas")
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Usuario", "Usuario")
                        .WithMany("Reservas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurante");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebApplication1.Models.Restaurante", b =>
                {
                    b.Navigation("Mesas");

                    b.Navigation("Resenas");

                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("WebApplication1.Models.Usuario", b =>
                {
                    b.Navigation("Resenas");

                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
