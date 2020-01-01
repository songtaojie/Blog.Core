﻿// <auto-generated />
using System;
using HxCore.Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HxCore.Migrate.Migrations
{
    [DbContext(typeof(HxContext))]
    [Migration("20200101140759_AddSeed")]
    partial class AddSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HxCore.Entity.BasicInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("CardId")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Delete")
                        .HasColumnType("char(1)");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletelUserId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<DateTime?>("LastModifyTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("QQ")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("RealName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("School")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("WeChat")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("BasicInfo");
                });

            modelBuilder.Entity("HxCore.Entity.Blog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("BlogTags")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("BlogTypeId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("CanCmt")
                        .HasColumnType("char(1)");

                    b.Property<string>("Carousel")
                        .HasColumnType("char(1)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<long>("CmtCount")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentHtml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Delete")
                        .HasColumnType("char(1)");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletelUserId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Essence")
                        .HasColumnType("char(1)");

                    b.Property<long>("FavCount")
                        .HasColumnType("bigint");

                    b.Property<string>("Forward")
                        .HasColumnType("char(1)");

                    b.Property<string>("ForwardUrl")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("ImgName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("LastModifyTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("LikeCount")
                        .HasColumnType("bigint");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("MarkDown")
                        .HasColumnType("char(1)");

                    b.Property<DateTime?>("OldPublishTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("OrderFactor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PersonTop")
                        .HasColumnType("char(1)");

                    b.Property<string>("Private")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Publish")
                        .HasColumnType("char(1)");

                    b.Property<DateTime?>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ReadCount")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Top")
                        .HasColumnType("char(1)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("HxCore.Entity.BlogType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Delete")
                        .HasColumnType("char(1)");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletelUserId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifyTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("BlogType");

                    b.HasData(
                        new
                        {
                            Id = "821142707052216320",
                            CreateTime = new DateTime(2020, 1, 1, 22, 7, 58, 476, DateTimeKind.Local).AddTicks(1010),
                            Delete = "N",
                            Name = "原创",
                            UserId = "821142707031244800",
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = "821142707056410624",
                            CreateTime = new DateTime(2020, 1, 1, 22, 7, 58, 476, DateTimeKind.Local).AddTicks(1586),
                            Delete = "N",
                            Name = "转载",
                            UserId = "821142707031244800",
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = "821142707056410625",
                            CreateTime = new DateTime(2020, 1, 1, 22, 7, 58, 476, DateTimeKind.Local).AddTicks(1593),
                            Delete = "N",
                            Name = "翻译",
                            UserId = "821142707031244800",
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("HxCore.Entity.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Delete")
                        .HasColumnType("char(1)");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletelUserId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifyTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = "821142707056410626",
                            CreateTime = new DateTime(2020, 1, 1, 22, 7, 58, 476, DateTimeKind.Local).AddTicks(2788),
                            Delete = "N",
                            Name = "前端",
                            UserId = "821142707031244800",
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = "821142707056410627",
                            CreateTime = new DateTime(2020, 1, 1, 22, 7, 58, 476, DateTimeKind.Local).AddTicks(2828),
                            Delete = "N",
                            Name = "后端",
                            UserId = "821142707031244800",
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = "821142707056410628",
                            CreateTime = new DateTime(2020, 1, 1, 22, 7, 58, 476, DateTimeKind.Local).AddTicks(2832),
                            Delete = "N",
                            Name = "编程语言",
                            UserId = "821142707031244800",
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("HxCore.Entity.JobInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Delete")
                        .HasColumnType("char(1)");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletelUserId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("GoodAreas")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("Industry")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("LastModifyTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Skills")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("WorkUnit")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("WorkYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("JobInfo");
                });

            modelBuilder.Entity("HxCore.Entity.UserInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Activate")
                        .HasColumnType("char(1)");

                    b.Property<string>("Admin")
                        .HasColumnType("char(1)");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("BasicInfoId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Delete")
                        .HasColumnType("char(1)");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("JobInfoId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("LastLoginTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lock")
                        .HasColumnType("char(1)");

                    b.Property<string>("LoginIp")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("OpenId")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<DateTime>("RegisterTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UseMdEdit")
                        .HasColumnType("char(1)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("UserInfo");

                    b.HasData(
                        new
                        {
                            Id = "821142707031244800",
                            Activate = "Y",
                            Admin = "N",
                            Delete = "N",
                            Email = "stjworkemail@163.com",
                            LastLoginTime = new DateTime(2020, 1, 1, 22, 7, 58, 473, DateTimeKind.Local).AddTicks(7568),
                            Lock = "N",
                            NickName = "超级管理员",
                            PassWord = "F59BD65F7EDAFB087A81D4DCA06C4910",
                            RegisterTime = new DateTime(2020, 1, 1, 22, 7, 58, 469, DateTimeKind.Local).AddTicks(7140),
                            UseMdEdit = "N",
                            UserName = "Admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
