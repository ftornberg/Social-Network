﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(NetworkContext))]
    partial class NetworkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Entity.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CommentedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PostedById")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PostedById");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Entity.DirectMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ConversationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.Property<int>("Receiver")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sender")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeSent")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DirectMessages");
                });

            modelBuilder.Entity("Entity.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PostedByUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostedMessage")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PostedTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("PostedToUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedTime = new DateTime(2022, 12, 3, 13, 31, 30, 893, DateTimeKind.Local).AddTicks(6934),
                            Email = "john@email.com",
                            Name = "John",
                            Password = "password"
                        },
                        new
                        {
                            Id = 2,
                            CreatedTime = new DateTime(2022, 12, 3, 13, 31, 30, 893, DateTimeKind.Local).AddTicks(7018),
                            Email = "bill@email.com",
                            Name = "Bill",
                            Password = "password"
                        });
                });

            modelBuilder.Entity("Entity.Comment", b =>
                {
                    b.HasOne("Entity.User", "PostedBy")
                        .WithMany()
                        .HasForeignKey("PostedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostedBy");
                });
#pragma warning restore 612, 618
        }
    }
}
