using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAT.MVC.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademyMagazines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MagazineNumber = table.Column<int>(type: "int", nullable: false),
                    PdfFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademyMagazines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carousals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    CarousalText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paragraph = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    buttonText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    buttonLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carousals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificatesInquiries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificatesInquiries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeciesionCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeciesionCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoutubeLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuBars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogoName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuBars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monthes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monthes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "statItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    BackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TempPage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempPage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paragraph = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListedItems = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TopHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplainsPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopHeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CarousalImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarousalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarousalImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarousalImages_Carousals_CarousalId",
                        column: x => x.CarousalId,
                        principalTable: "Carousals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FooterSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FooterSections_Footers_FooterId",
                        column: x => x.FooterId,
                        principalTable: "Footers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dropdowns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DropdownName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MenuBarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dropdowns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dropdowns_MenuBars_MenuBarId",
                        column: x => x.MenuBarId,
                        principalTable: "MenuBars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MenuBarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuLinks_MenuBars_MenuBarId",
                        column: x => x.MenuBarId,
                        principalTable: "MenuBars",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tempModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Describtion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempPageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tempModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tempModels_TempPage_TempPageId",
                        column: x => x.TempPageId,
                        principalTable: "TempPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TopHeaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMedia_TopHeaders_TopHeaderId",
                        column: x => x.TopHeaderId,
                        principalTable: "TopHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FooterLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    sectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FooterLinks_FooterSections_sectionId",
                        column: x => x.sectionId,
                        principalTable: "FooterSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrobdownLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DropdownId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrobdownLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrobdownLinks_Dropdowns_DropdownId",
                        column: x => x.DropdownId,
                        principalTable: "Dropdowns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Responsibilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.id);
                    table.ForeignKey(
                        name: "FK_AboutUs_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcademyGoals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoalDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademyGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademyGoals_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcademyRoles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademyRoles", x => x.id);
                    table.ForeignKey(
                        name: "FK_AcademyRoles_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccreditationProcedureCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccreditationProcedureCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccreditationProcedureCategories_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccreditedCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccreditedCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccreditedCenters_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    branchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    statistics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    branchPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    branchFax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    branchEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    branchManager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    branchManagerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    branchManagerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    branchAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.id);
                    table.ForeignKey(
                        name: "FK_Branches_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificateProcedureCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateProcedureCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificateProcedureCategories_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactUSTopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUSTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactUSTopics_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FAQCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FAQCategories_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Governments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Governments_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MinisterialEmploymentDescisions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PdfFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false),
                    DeciesionCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinisterialEmploymentDescisions", x => x.id);
                    table.ForeignKey(
                        name: "FK_MinisterialEmploymentDescisions_DeciesionCategories_DeciesionCategoryId",
                        column: x => x.DeciesionCategoryId,
                        principalTable: "DeciesionCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MinisterialEmploymentDescisions_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MinisterialPromotionDescisions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinisterialPromotionDescisions", x => x.id);
                    table.ForeignKey(
                        name: "FK_MinisterialPromotionDescisions_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsCategories_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partners_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Positions_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => x.id);
                    table.ForeignKey(
                        name: "FK_PostCategories_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromotionExamTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prerequisite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionExamTypes", x => x.id);
                    table.ForeignKey(
                        name: "FK_PromotionExamTypes_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.id);
                    table.ForeignKey(
                        name: "FK_Services_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherGetways",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherGetways", x => x.id);
                    table.ForeignKey(
                        name: "FK_TeacherGetways_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userCertificateRequests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    certificateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userCertificateRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_userCertificateRequests_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AccreditationProcedures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccreditationProcedureCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccreditationProcedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccreditationProcedures_AccreditationProcedureCategories_AccreditationProcedureCategoryId",
                        column: x => x.AccreditationProcedureCategoryId,
                        principalTable: "AccreditationProcedureCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reply = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sender = table.Column<int>(type: "int", nullable: false),
                    Reviewer = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_MessageTypes_Type",
                        column: x => x.Type,
                        principalTable: "MessageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificateProcedures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateProcedureCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateProcedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificateProcedures_CertificateProcedureCategories_CertificateProcedureCategoryId",
                        column: x => x.CertificateProcedureCategoryId,
                        principalTable: "CertificateProcedureCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactUsTopicId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactUs_ContactUSTopics_ContactUsTopicId",
                        column: x => x.ContactUsTopicId,
                        principalTable: "ContactUSTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactUs_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "FAQModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FAQModels_FAQCategories_Category",
                        column: x => x.Category,
                        principalTable: "FAQCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FAQModels_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducitionalAdministrations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducitionalAdministrations", x => x.id);
                    table.ForeignKey(
                        name: "FK_EducitionalAdministrations_Governments_GovernmentId",
                        column: x => x.GovernmentId,
                        principalTable: "Governments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducitionalAdministrations_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PATManagers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    birthPlace = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Userid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PATManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PATManagers_Governments_birthPlace",
                        column: x => x.birthPlace,
                        principalTable: "Governments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PATManagers_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AcademyNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademyNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademyNews_NewsCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "NewsCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademyNews_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    postCategoryId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Posts_PostCategories_postCategoryId",
                        column: x => x.postCategoryId,
                        principalTable: "PostCategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PromotionExams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionExams", x => x.id);
                    table.ForeignKey(
                        name: "FK_PromotionExams_PromotionExamTypes_ExamTypeId",
                        column: x => x.ExamTypeId,
                        principalTable: "PromotionExamTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromotionExams_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "FaQQuestionAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FAQModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaQQuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaQQuestionAnswer_FAQModels_FAQModelId",
                        column: x => x.FAQModelId,
                        principalTable: "FAQModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userCertificates",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    certificateType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    certificateTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    certificateUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    certificateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    certificateIssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    certificateExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    certificateStatus = table.Column<int>(type: "int", nullable: false),
                    certificateRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    certificateImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    educitionalAdministrationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userCertificates", x => x.id);
                    table.ForeignKey(
                        name: "FK_userCertificates_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userCertificates_EducitionalAdministrations_educitionalAdministrationId",
                        column: x => x.educitionalAdministrationId,
                        principalTable: "EducitionalAdministrations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_userCertificates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    familyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    governmentId = table.Column<int>(type: "int", nullable: true),
                    positionId = table.Column<int>(type: "int", nullable: true),
                    educitionalAdministrationId = table.Column<int>(type: "int", nullable: false),
                    teacherCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nationalId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserDetails_EducitionalAdministrations_educitionalAdministrationId",
                        column: x => x.educitionalAdministrationId,
                        principalTable: "EducitionalAdministrations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDetails_Governments_governmentId",
                        column: x => x.governmentId,
                        principalTable: "Governments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UserDetails_Positions_positionId",
                        column: x => x.positionId,
                        principalTable: "Positions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UserDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    certificateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    institutionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false),
                    PATManagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.id);
                    table.ForeignKey(
                        name: "FK_Certificates_PATManagers_PATManagerId",
                        column: x => x.PATManagerId,
                        principalTable: "PATManagers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Certificates_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBY = table.Column<int>(type: "int", nullable: false),
                    PATManagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.id);
                    table.ForeignKey(
                        name: "FK_Experiences_PATManagers_PATManagerId",
                        column: x => x.PATManagerId,
                        principalTable: "PATManagers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Experiences_Users_CreatedBY",
                        column: x => x.CreatedBY,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserExamRequests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExamRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserExamRequests_PromotionExams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "PromotionExams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExamRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutUs_CreatedBy",
                table: "AboutUs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AcademyGoals_CreatedBy",
                table: "AcademyGoals",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AcademyNews_CategoryId",
                table: "AcademyNews",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademyNews_CreatedBY",
                table: "AcademyNews",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_AcademyRoles_CreatedBY",
                table: "AcademyRoles",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_AccreditationProcedureCategories_CreatedBY",
                table: "AccreditationProcedureCategories",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_AccreditationProcedures_AccreditationProcedureCategoryId",
                table: "AccreditationProcedures",
                column: "AccreditationProcedureCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AccreditedCenters_CreatedBY",
                table: "AccreditedCenters",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CreatedBy",
                table: "Branches",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CarousalImages_CarousalId",
                table: "CarousalImages",
                column: "CarousalId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateProcedureCategories_CreatedBY",
                table: "CertificateProcedureCategories",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateProcedures_CertificateProcedureCategoryId",
                table: "CertificateProcedures",
                column: "CertificateProcedureCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_CreatedBY",
                table: "Certificates",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_PATManagerId",
                table: "Certificates",
                column: "PATManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_ContactUsTopicId",
                table: "ContactUs",
                column: "ContactUsTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_CreatedBy",
                table: "ContactUs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUSTopics_CreatedBy",
                table: "ContactUSTopics",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DrobdownLinks_DropdownId",
                table: "DrobdownLinks",
                column: "DropdownId");

            migrationBuilder.CreateIndex(
                name: "IX_Dropdowns_MenuBarId",
                table: "Dropdowns",
                column: "MenuBarId");

            migrationBuilder.CreateIndex(
                name: "IX_EducitionalAdministrations_CreatedBY",
                table: "EducitionalAdministrations",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_EducitionalAdministrations_GovernmentId",
                table: "EducitionalAdministrations",
                column: "GovernmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_CreatedBY",
                table: "Experiences",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_PATManagerId",
                table: "Experiences",
                column: "PATManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQCategories_CreatedBY",
                table: "FAQCategories",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_FAQModels_Category",
                table: "FAQModels",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_FAQModels_CreatedBY",
                table: "FAQModels",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_FaQQuestionAnswer_FAQModelId",
                table: "FaQQuestionAnswer",
                column: "FAQModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FooterLinks_sectionId",
                table: "FooterLinks",
                column: "sectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FooterSections_FooterId",
                table: "FooterSections",
                column: "FooterId");

            migrationBuilder.CreateIndex(
                name: "IX_Governments_CreatedBY",
                table: "Governments",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_MenuLinks_MenuBarId",
                table: "MenuLinks",
                column: "MenuBarId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_BranchId",
                table: "Messages",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_Type",
                table: "Messages",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_MinisterialEmploymentDescisions_CreatedBY",
                table: "MinisterialEmploymentDescisions",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_MinisterialEmploymentDescisions_DeciesionCategoryId",
                table: "MinisterialEmploymentDescisions",
                column: "DeciesionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MinisterialPromotionDescisions_CreatedBY",
                table: "MinisterialPromotionDescisions",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_NewsCategories_CreatedBY",
                table: "NewsCategories",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_CreatedBY",
                table: "Partners",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_PATManagers_birthPlace",
                table: "PATManagers",
                column: "birthPlace");

            migrationBuilder.CreateIndex(
                name: "IX_PATManagers_Userid",
                table: "PATManagers",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_CreatedBY",
                table: "Positions",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_CreatedBY",
                table: "PostCategories",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_postCategoryId",
                table: "Posts",
                column: "postCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionExams_CreatedBY",
                table: "PromotionExams",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionExams_ExamTypeId",
                table: "PromotionExams",
                column: "ExamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionExamTypes_CreatedBY",
                table: "PromotionExamTypes",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CreatedBY",
                table: "Services",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedia_TopHeaderId",
                table: "SocialMedia",
                column: "TopHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherGetways_CreatedBY",
                table: "TeacherGetways",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_CreatedBY",
                table: "TeamMembers",
                column: "CreatedBY");

            migrationBuilder.CreateIndex(
                name: "IX_tempModels_TempPageId",
                table: "tempModels",
                column: "TempPageId");

            migrationBuilder.CreateIndex(
                name: "IX_userCertificateRequests_userId",
                table: "userCertificateRequests",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_userCertificates_BranchId",
                table: "userCertificates",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_userCertificates_educitionalAdministrationId",
                table: "userCertificates",
                column: "educitionalAdministrationId");

            migrationBuilder.CreateIndex(
                name: "IX_userCertificates_UserId",
                table: "userCertificates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_educitionalAdministrationId",
                table: "UserDetails",
                column: "educitionalAdministrationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_governmentId",
                table: "UserDetails",
                column: "governmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_positionId",
                table: "UserDetails",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserId",
                table: "UserDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExamRequests_ExamId",
                table: "UserExamRequests",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExamRequests_UserId",
                table: "UserExamRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");

            migrationBuilder.DropTable(
                name: "AcademyGoals");

            migrationBuilder.DropTable(
                name: "AcademyMagazines");

            migrationBuilder.DropTable(
                name: "AcademyNews");

            migrationBuilder.DropTable(
                name: "AcademyRoles");

            migrationBuilder.DropTable(
                name: "AccreditationProcedures");

            migrationBuilder.DropTable(
                name: "AccreditedCenters");

            migrationBuilder.DropTable(
                name: "CarousalImages");

            migrationBuilder.DropTable(
                name: "CertificateProcedures");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "CertificatesInquiries");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "DrobdownLinks");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "FaQQuestionAnswer");

            migrationBuilder.DropTable(
                name: "FooterLinks");

            migrationBuilder.DropTable(
                name: "MenuLinks");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "MinisterialEmploymentDescisions");

            migrationBuilder.DropTable(
                name: "MinisterialPromotionDescisions");

            migrationBuilder.DropTable(
                name: "Monthes");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "SocialMedia");

            migrationBuilder.DropTable(
                name: "statItems");

            migrationBuilder.DropTable(
                name: "TeacherGetways");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "tempModels");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.DropTable(
                name: "userCertificateRequests");

            migrationBuilder.DropTable(
                name: "userCertificates");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "UserExamRequests");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "NewsCategories");

            migrationBuilder.DropTable(
                name: "AccreditationProcedureCategories");

            migrationBuilder.DropTable(
                name: "Carousals");

            migrationBuilder.DropTable(
                name: "CertificateProcedureCategories");

            migrationBuilder.DropTable(
                name: "ContactUSTopics");

            migrationBuilder.DropTable(
                name: "Dropdowns");

            migrationBuilder.DropTable(
                name: "PATManagers");

            migrationBuilder.DropTable(
                name: "FAQModels");

            migrationBuilder.DropTable(
                name: "FooterSections");

            migrationBuilder.DropTable(
                name: "MessageTypes");

            migrationBuilder.DropTable(
                name: "DeciesionCategories");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "TopHeaders");

            migrationBuilder.DropTable(
                name: "TempPage");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "EducitionalAdministrations");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "PromotionExams");

            migrationBuilder.DropTable(
                name: "MenuBars");

            migrationBuilder.DropTable(
                name: "FAQCategories");

            migrationBuilder.DropTable(
                name: "Footers");

            migrationBuilder.DropTable(
                name: "Governments");

            migrationBuilder.DropTable(
                name: "PromotionExamTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
