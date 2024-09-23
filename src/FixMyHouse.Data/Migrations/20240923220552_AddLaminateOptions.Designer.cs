﻿// <auto-generated />
using System;
using FixMyHouse.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FixMyHouse.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240923220552_AddLaminateOptions")]
    partial class AddLaminateOptions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FixMyHouse.Data.Entities.ArtisanEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artisans");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b27681a2-a41c-4b8e-951f-ecf8ecf3f4a7"),
                            Bio = "Георги е алпинист и специализира в покриви и външни топлоизолации",
                            FirstName = "Георги",
                            LastName = "Петров",
                            Picture = "gosho.png"
                        },
                        new
                        {
                            Id = new Guid("936f63da-8730-4344-8421-64bf343661f7"),
                            Bio = "Петър е майстор по вътрешни ремонти и бани",
                            FirstName = "Петър",
                            LastName = "Георгиев",
                            Picture = "pesho.png"
                        });
                });

            modelBuilder.Entity("FixMyHouse.Data.Entities.ArtisanServiceEntity", b =>
                {
                    b.Property<Guid>("Ref_Artisan")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Ref_Service")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomizationDefaults")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ref_Artisan", "Ref_Service");

                    b.HasIndex("Ref_Service");

                    b.ToTable("ArtisanServices");

                    b.HasData(
                        new
                        {
                            Ref_Artisan = new Guid("b27681a2-a41c-4b8e-951f-ecf8ecf3f4a7"),
                            Ref_Service = new Guid("4522c17e-c161-4f42-8467-1854344a373b"),
                            CustomizationDefaults = "[{\"$type\":\"checkbox\",\"ValueIfTrue\":100,\"Value\":false,\"Id\":\"525e7b61-27d7-4995-9338-9119b54b63b5\",\"Name\":\"\\u0415\\u043A\\u0441\\u0442\\u0440\\u0430 \\u0434\\u044E\\u0431\\u0435\\u043B\\u0438\",\"Description\":\"\\u002B2 \\u0433\\u043E\\u0434\\u0438\\u043D\\u0438 \\u0433\\u0430\\u0440\\u0430\\u043D\\u0446\\u0438\\u044F\"},{\"$type\":\"whole-number\",\"ValueMultiplier\":50,\"Value\":20,\"Id\":\"9aa0097e-135a-47af-beb3-0e3739662e51\",\"Name\":\"\\u0412\\u044A\\u043D\\u0448\\u043D\\u0430 \\u043A\\u0432\\u0430\\u0434\\u0440\\u0430\\u0442\\u0443\\u0440\\u0430\",\"Description\":\"50 \\u043B\\u0432/\\u043A\\u0432.\\u043C\"},{\"$type\":\"options\",\"AvailableOptions\":[{\"Id\":\"a4b86f3c-43c8-4c67-b6af-9f7c5cc45680\",\"Name\":\"\\u0411\\u044F\\u043B\",\"Price\":100},{\"Id\":\"6ec1d8b3-cfe5-4943-8922-ea37ad1579c5\",\"Name\":\"\\u0416\\u044A\\u043B\\u0442\",\"Price\":150},{\"Id\":\"f11c62dc-b3d5-4f5a-8cb1-9331e234f61f\",\"Name\":\"\\u0420\\u043E\\u0437\\u043E\\u0432\",\"Price\":300}],\"Value\":\"a4b86f3c-43c8-4c67-b6af-9f7c5cc45680\",\"Id\":\"16a41a23-66b9-42a0-a61d-69aedf9f9c64\",\"Name\":\"\\u0426\\u0432\\u044F\\u0442\",\"Description\":\"\\u0426\\u0432\\u044F\\u0442 \\u043D\\u0430 \\u0444\\u0430\\u0441\\u0430\\u0434\\u0430\\u0442\\u0430\"}]"
                        },
                        new
                        {
                            Ref_Artisan = new Guid("b27681a2-a41c-4b8e-951f-ecf8ecf3f4a7"),
                            Ref_Service = new Guid("f90735af-c71a-4e5a-8e3f-f13919ed4d5d"),
                            CustomizationDefaults = "[{\"$type\":\"whole-number\",\"ValueMultiplier\":70,\"Value\":250,\"Id\":\"de5a0771-df9d-408c-abce-864e54de37e8\",\"Name\":\"\\u0420\\u0430\\u0437\\u043C\\u0435\\u0440 \\u043D\\u0430 \\u043F\\u043E\\u043A\\u0440\\u0438\\u0432 (\\u043A\\u0432.\\u043C)\",\"Description\":\"\\u041A\\u043E\\u043B\\u043A\\u043E \\u0435 \\u0433\\u043E\\u043B\\u044F\\u043C \\u0432\\u0430\\u0448\\u0438\\u044F\\u0442 \\u043F\\u043E\\u043A\\u0440\\u0438\\u0432? 70\\u043B\\u0432/\\u043A\\u0432.\\u043C\"},{\"$type\":\"whole-number\",\"ValueMultiplier\":100,\"Value\":1,\"Id\":\"0f49866d-1215-49ee-8d0f-d0ebdc8fecd5\",\"Name\":\"\\u0411\\u0440\\u043E\\u0439 \\u043A\\u043E\\u043C\\u0438\\u043D\\u0438 \\u0438 \\u0434\\u0440\\u0443\\u0433\\u0438 \\u043F\\u0440\\u0435\\u043F\\u044F\\u0442\\u0441\\u0442\\u0432\\u0438\\u044F\",\"Description\":\"100\\u043B\\u0432 / \\u043A\\u043E\\u043C\\u0438\\u043D\"}]"
                        },
                        new
                        {
                            Ref_Artisan = new Guid("936f63da-8730-4344-8421-64bf343661f7"),
                            Ref_Service = new Guid("608f46ff-bd6d-4025-8435-c768df3cb434"),
                            CustomizationDefaults = "[{\"$type\":\"whole-number\",\"ValueMultiplier\":110,\"Value\":30,\"Id\":\"14a09ac4-3db2-43d1-a471-d6d74a95cd92\",\"Name\":\"\\u041E\\u0431\\u0449 \\u0440\\u0430\\u0437\\u043C\\u0435\\u0440 \\u043D\\u0430 \\u043F\\u043E\\u043C\\u0435\\u0449\\u0435\\u043D\\u0438\\u044F\\u0442\\u0430 (\\u043A\\u0432.\\u043C)\",\"Description\":\"\\u041E\\u0431\\u0449\\u0430 \\u043A\\u0432\\u0430\\u0434\\u0440\\u0430\\u0442\\u0443\\u0440\\u0430 \\u043D\\u0430 \\u0432\\u0441\\u0438\\u0447\\u043A\\u0438 \\u043F\\u043E\\u043C\\u0435\\u0449\\u0435\\u043D\\u0438\\u044F (\\u0431\\u0430\\u043D\\u0438, \\u0442\\u043E\\u0430\\u043B\\u0435\\u0442\\u043D\\u0438) 110\\u043B\\u0432/\\u043A\\u0432.\\u043C\"},{\"$type\":\"whole-number\",\"ValueMultiplier\":1000,\"Value\":1,\"Id\":\"69dc7312-25df-4705-8bf0-4fab9a5588b5\",\"Name\":\"\\u0411\\u0440\\u043E\\u0439 \\u043F\\u043E\\u043C\\u0435\\u0449\\u0435\\u043D\\u0438\\u044F\",\"Description\":\"\\u002B1000\\u043B\\u0432 / \\u043F\\u043E\\u043C\\u0435\\u0449\\u0435\\u043D\\u0438\\u0435\"}]"
                        },
                        new
                        {
                            Ref_Artisan = new Guid("936f63da-8730-4344-8421-64bf343661f7"),
                            Ref_Service = new Guid("4cb9e004-1d75-400a-9de1-1a5804303d3a"),
                            CustomizationDefaults = "[{\"$type\":\"whole-number\",\"ValueMultiplier\":55,\"Value\":70,\"Id\":\"da89dcb9-ee1a-4eb2-b09c-5d6a0c0e0bca\",\"Name\":\"\\u041E\\u0431\\u0449 \\u0440\\u0430\\u0437\\u043C\\u0435\\u0440 \\u043D\\u0430 \\u043F\\u043E\\u043C\\u0435\\u0449\\u0435\\u043D\\u0438\\u044F\\u0442\\u0430 (\\u043A\\u0432.\\u043C)\",\"Description\":\"\\u041E\\u0431\\u0449\\u0430 \\u043A\\u0432\\u0430\\u0434\\u0440\\u0430\\u0442\\u0443\\u0440\\u0430 \\u043D\\u0430 \\u0432\\u0441\\u0438\\u0447\\u043A\\u0438 \\u043F\\u043E\\u043C\\u0435\\u0449\\u0435\\u043D\\u0438\\u044F (\\u0434\\u043D\\u0435\\u0432\\u043D\\u0430, \\u043A\\u0443\\u0445\\u043D\\u044F, \\u0441\\u043F\\u0430\\u043B\\u043D\\u044F) 55\\u043B\\u0432/\\u043A\\u0432.\\u043C\"},{\"$type\":\"whole-number\",\"ValueMultiplier\":300,\"Value\":1,\"Id\":\"7d666de3-5f4f-4110-883d-100fe2ea4c2c\",\"Name\":\"\\u0411\\u0440\\u043E\\u0439 \\u043F\\u043E\\u043C\\u0435\\u0449\\u0435\\u043D\\u0438\\u044F\",\"Description\":\"\\u002B300\\u043B\\u0432 / \\u043F\\u043E\\u043C\\u0435\\u0449\\u0435\\u043D\\u0438\\u0435\"},{\"$type\":\"options\",\"AvailableOptions\":[{\"Id\":\"13f5e1d4-38d7-4189-84c7-a11765e3eac2\",\"Name\":\"\\u041C\\u043E\\u043A\\u0435\\u0442\",\"Price\":100},{\"Id\":\"e7671bf6-061e-4bb5-bd85-65caf770936f\",\"Name\":\"\\u041B\\u0430\\u043C\\u0438\\u043D\\u0430\\u0442\",\"Price\":150},{\"Id\":\"dbd2051b-8753-4454-9eee-f5655093b111\",\"Name\":\"\\u041F\\u0430\\u0440\\u043A\\u0435\\u0442\",\"Price\":300},{\"Id\":\"dbd2051b-8753-4454-9eee-f5655093b111\",\"Name\":\"\\u0411\\u0430\\u043B\\u0430\\u0442\\u0443\\u043C\",\"Price\":75}],\"Value\":\"13f5e1d4-38d7-4189-84c7-a11765e3eac2\",\"Id\":\"130820ee-1ec2-418f-b113-8485bc168d29\",\"Name\":\"\\u0412\\u0438\\u0434 \\u043D\\u0430\\u0441\\u0442\\u0438\\u043B\\u043A\\u0430\",\"Description\":\"\\u0418\\u0437\\u0431\\u0435\\u0440\\u0435\\u0442\\u0435 \\u043A\\u0430\\u043A \\u0434\\u0430 \\u0438\\u0437\\u043B\\u0435\\u0436\\u0434\\u0430 \\u0432\\u0430\\u0448\\u0438\\u044F\\u0442 \\u043F\\u043E\\u0434\"}]"
                        });
                });

            modelBuilder.Entity("FixMyHouse.Data.Entities.ServiceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4522c17e-c161-4f42-8467-1854344a373b"),
                            Description = "Външни и вътрешни топлоизолации",
                            Name = "Топлоизолация",
                            Picture = "thermal-insulation.png"
                        },
                        new
                        {
                            Id = new Guid("608f46ff-bd6d-4025-8435-c768df3cb434"),
                            Description = "Поставяне на плочки във вашата баня",
                            Name = "Лепене на плочки",
                            Picture = "bathroom-tiles.png"
                        },
                        new
                        {
                            Id = new Guid("f90735af-c71a-4e5a-8e3f-f13919ed4d5d"),
                            Description = "Хидроизолация на покриви на жилищни сгради. Обадете се, ако покрива тече!",
                            Name = "Хидроизолация на покриви",
                            Picture = "roof-hydro.png"
                        },
                        new
                        {
                            Id = new Guid("4cb9e004-1d75-400a-9de1-1a5804303d3a"),
                            Description = "Поставяне на подова настилка: паркет, ламинат, мокети и балатум",
                            Name = "Подова настилка",
                            Picture = "laminate.png"
                        });
                });

            modelBuilder.Entity("FixMyHouse.Data.Entities.ServiceReservationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CalculatedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CustomizationBooleans")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomizationGuids")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomizationWholeNumbers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Ref_Artisan")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Ref_Service")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ref_User")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("WhenUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Ref_Artisan");

                    b.HasIndex("Ref_Service");

                    b.HasIndex("Ref_User");

                    b.ToTable("ServiceReservations");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FixMyHouse.Data.Entities.ArtisanServiceEntity", b =>
                {
                    b.HasOne("FixMyHouse.Data.Entities.ArtisanEntity", "Artisan")
                        .WithMany("Services")
                        .HasForeignKey("Ref_Artisan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FixMyHouse.Data.Entities.ServiceEntity", "Service")
                        .WithMany()
                        .HasForeignKey("Ref_Service")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artisan");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("FixMyHouse.Data.Entities.ServiceReservationEntity", b =>
                {
                    b.HasOne("FixMyHouse.Data.Entities.ArtisanEntity", "Artisan")
                        .WithMany()
                        .HasForeignKey("Ref_Artisan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FixMyHouse.Data.Entities.ServiceEntity", "Service")
                        .WithMany()
                        .HasForeignKey("Ref_Service")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("Ref_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artisan");

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FixMyHouse.Data.Entities.ArtisanEntity", b =>
                {
                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
