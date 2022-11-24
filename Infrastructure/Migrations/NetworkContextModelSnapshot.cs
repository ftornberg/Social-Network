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

                    b.Property<int?>("PostedById")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("PostedById");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Entity.Conversation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Conversations");
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

                    b.Property<int>("Reciever")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sender")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeSent")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.ToTable("DirectMessages");
                });

            modelBuilder.Entity("Entity.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostedMessage")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PostedTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

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
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entity.Comment", b =>
                {
                    b.HasOne("Entity.Post", null)
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.User", "PostedBy")
                        .WithMany()
                        .HasForeignKey("PostedById");

                    b.Navigation("PostedBy");
                });

            modelBuilder.Entity("Entity.Conversation", b =>
                {
                    b.HasOne("Entity.User", null)
                        .WithMany("Messages")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Entity.DirectMessage", b =>
                {
                    b.HasOne("Entity.Conversation", null)
                        .WithMany("Messages")
                        .HasForeignKey("ConversationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entity.Post", b =>
                {
                    b.HasOne("Entity.User", null)
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entity.User", b =>
                {
                    b.HasOne("Entity.User", null)
                        .WithMany("Followers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Entity.Conversation", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Entity.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Entity.User", b =>
                {
                    b.Navigation("Followers");

                    b.Navigation("Messages");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
