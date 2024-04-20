﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HotelBackendV2.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20240417174009_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Activities.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<Guid?>("InvoiceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ModifiedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("CustomerId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Activities");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Activity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Customer.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ZipCode")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("Domain.Customer.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid");

                    b.Property<string>("CustomerNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CustomerType")
                        .HasColumnType("integer");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Customers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Customer");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Invoice.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DebitorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DebitorId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Activities.Comment", b =>
                {
                    b.HasBaseType("Domain.Activities.Activity");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Comment");
                });

            modelBuilder.Entity("Domain.Activities.Email", b =>
                {
                    b.HasBaseType("Domain.Activities.Activity");

                    b.Property<string[]>("Cc")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string[]>("To")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.ToTable("Activities", t =>
                        {
                            t.Property("Content")
                                .HasColumnName("Email_Content");
                        });

                    b.HasDiscriminator().HasValue("Email");
                });

            modelBuilder.Entity("Domain.Activities.Task", b =>
                {
                    b.HasBaseType("Domain.Activities.Activity");

                    b.Property<Guid>("AssignedToId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.HasIndex("AssignedToId");

                    b.HasDiscriminator().HasValue("Task");
                });

            modelBuilder.Entity("Domain.Customer.Debitor", b =>
                {
                    b.HasBaseType("Domain.Customer.Customer");

                    b.Property<string>("DebitorNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Debitor");
                });

            modelBuilder.Entity("Domain.Activities.Activity", b =>
                {
                    b.HasOne("Domain.Users.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Customer.Customer", null)
                        .WithMany("Activities")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Invoice.Invoice", null)
                        .WithMany("Activities")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("Domain.Users.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("Domain.Customer.Customer", b =>
                {
                    b.HasOne("Domain.Customer.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Domain.Invoice.Invoice", b =>
                {
                    b.HasOne("Domain.Customer.Debitor", null)
                        .WithMany("Invoices")
                        .HasForeignKey("DebitorId");
                });

            modelBuilder.Entity("Domain.Activities.Task", b =>
                {
                    b.HasOne("Domain.Users.User", "AssignedTo")
                        .WithMany()
                        .HasForeignKey("AssignedToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedTo");
                });

            modelBuilder.Entity("Domain.Customer.Customer", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("Domain.Invoice.Invoice", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("Domain.Customer.Debitor", b =>
                {
                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}