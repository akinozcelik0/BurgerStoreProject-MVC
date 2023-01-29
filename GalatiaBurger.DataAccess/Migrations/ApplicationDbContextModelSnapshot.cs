﻿// <auto-generated />
using System;
using GalatiaBurger.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GalatiaBurger.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExtraIngredientMenu", b =>
                {
                    b.Property<int>("ExtraIngredientsId")
                        .HasColumnType("int");

                    b.Property<int>("MenusId")
                        .HasColumnType("int");

                    b.HasKey("ExtraIngredientsId", "MenusId");

                    b.HasIndex("MenusId");

                    b.ToTable("ExtraIngredientMenu");
                });

            modelBuilder.Entity("GalatiaBurger.Models.ExtraIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ExtraIngredients");
                });

            modelBuilder.Entity("GalatiaBurger.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "\\images\\menus\\b55eaa24-3bb5-4da2-aac9-dc7630c99fce.png",
                            Name = "Hamburger",
                            Price = 50.0
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "\\images\\menus\\aa441fab-2272-4ff0-b301-651f11e1a45d.png",
                            Name = "Cheeseburger",
                            Price = 60.0
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "\\images\\menus\\e1be850d-5420-4922-b08b-d041281e60e8.png",
                            Name = "Doubleburger",
                            Price = 80.0
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "\\images\\menus\\1f5e765c-8b7b-4ea6-bdf1-8a17dc507958.png",
                            Name = "MixBurger",
                            Price = 70.0
                        });
                });

            modelBuilder.Entity("GalatiaBurger.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("ExtraIngredientId")
                        .HasColumnType("int");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<double>("OrderNo")
                        .HasColumnType("float");

                    b.Property<int>("SideMealId")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExtraIngredientId");

                    b.HasIndex("MenuId");

                    b.HasIndex("SideMealId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GalatiaBurger.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int?>("ExtraIngredientId")
                        .HasColumnType("int");

                    b.Property<int?>("MenuId")
                        .HasColumnType("int");

                    b.Property<int?>("SideMealId")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExtraIngredientId");

                    b.HasIndex("MenuId");

                    b.HasIndex("SideMealId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("GalatiaBurger.Models.SideMeal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("SideMeals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "\\images\\sidemeals\\f25d8304-e7b4-4196-bac4-5c8eb78c2e46.png",
                            Name = "French Fries",
                            Price = 20.0
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "\\images\\sidemeals\\170b0e23-382a-45de-8fa1-0d60a1ebeaf2.png",
                            Name = "Onion Rings",
                            Price = 25.0
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "\\images\\sidemeals\\68c08a58-cbe9-4349-bf29-cf877b93190d.png",
                            Name = "Fried Cheese ",
                            Price = 30.0
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "\\images\\sidemeals\\cd664b15-0fd1-481d-852d-a100deb55315.png",
                            Name = "Chicken Bites",
                            Price = 40.0
                        });
                });

            modelBuilder.Entity("ExtraIngredientMenu", b =>
                {
                    b.HasOne("GalatiaBurger.Models.ExtraIngredient", null)
                        .WithMany()
                        .HasForeignKey("ExtraIngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GalatiaBurger.Models.Menu", null)
                        .WithMany()
                        .HasForeignKey("MenusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GalatiaBurger.Models.Order", b =>
                {
                    b.HasOne("GalatiaBurger.Models.ExtraIngredient", "ExtraIngredient")
                        .WithMany()
                        .HasForeignKey("ExtraIngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GalatiaBurger.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GalatiaBurger.Models.SideMeal", "SideMeal")
                        .WithMany()
                        .HasForeignKey("SideMealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtraIngredient");

                    b.Navigation("Menu");

                    b.Navigation("SideMeal");
                });

            modelBuilder.Entity("GalatiaBurger.Models.ShoppingCart", b =>
                {
                    b.HasOne("GalatiaBurger.Models.ExtraIngredient", "ExtraIngredient")
                        .WithMany()
                        .HasForeignKey("ExtraIngredientId");

                    b.HasOne("GalatiaBurger.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId");

                    b.HasOne("GalatiaBurger.Models.SideMeal", "SideMeal")
                        .WithMany()
                        .HasForeignKey("SideMealId");

                    b.Navigation("ExtraIngredient");

                    b.Navigation("Menu");

                    b.Navigation("SideMeal");
                });
#pragma warning restore 612, 618
        }
    }
}
