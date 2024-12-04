using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    AddByUserId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    LocationName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    AddByUserId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    AddByUserId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Citys_CityId",
                        column: x => x.CityId,
                        principalTable: "Citys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HotelContactType = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false),
                    AddByUserId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelContacts_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelLocationContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false),
                    AddByUserId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelLocationContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelLocationContacts_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelOfficials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    SurName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CorporateTitle = table.Column<string>(type: "text", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false),
                    AddByUserId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelOfficials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelOfficials_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    DistrictId = table.Column<int>(type: "integer", nullable: false),
                    AddByUserId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Citys_CityId",
                        column: x => x.CityId,
                        principalTable: "Citys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactLocationMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false),
                    HotelLocationContactId = table.Column<int>(type: "integer", nullable: true),
                    AddByUserId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactLocationMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactLocationMappings_HotelLocationContacts_HotelLocation~",
                        column: x => x.HotelLocationContactId,
                        principalTable: "HotelLocationContacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactLocationMappings_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactLocationMappings_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Citys",
                columns: new[] { "Id", "AddByUserId", "CreatedDate", "IsActive", "IsDeleted", "Name", "UpdatedByUserId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 4, 4, 58, 0, 0, DateTimeKind.Local), true, false, "Adana", null, null },
                    { 2, 1, new DateTime(2024, 12, 4, 4, 58, 0, 0, DateTimeKind.Local), true, false, "Adıyaman", null, null },
                    { 3, 1, new DateTime(2024, 12, 4, 4, 58, 0, 0, DateTimeKind.Local), true, false, "Afyonkarahisar", null, null }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "AddByUserId", "CreatedDate", "Description", "IsActive", "IsDeleted", "Latitude", "LocationName", "Longitude", "Name", "UpdatedByUserId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 4, 4, 58, 0, 0, DateTimeKind.Local), "Havuzlu Villalı Suit Her Şey Dahil", true, false, 0m, "İstanbul Merkez Hacı Osman", 0m, "Antalya Suit Otel", null, null },
                    { 2, 1, new DateTime(2024, 12, 4, 4, 58, 0, 0, DateTimeKind.Local), "Havuzlu Villalı Suit Her Şey Dahil", true, false, 0m, "İstanbul Merkez Hacı Osman", 0m, "İstanbul Suit Otel", null, null }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "AddByUserId", "CityId", "CreatedDate", "IsActive", "IsDeleted", "Name", "UpdatedByUserId", "UpdatedDate" },
                values: new object[] { 1, 1, 2, new DateTime(2024, 12, 4, 4, 58, 0, 0, DateTimeKind.Local), true, false, "AdanaDistrict", null, null });

            migrationBuilder.InsertData(
                table: "HotelContacts",
                columns: new[] { "Id", "AddByUserId", "Content", "CreatedDate", "HotelContactType", "HotelId", "IsActive", "IsDeleted", "UpdatedByUserId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, "905412045792", new DateTime(2024, 12, 4, 4, 58, 0, 0, DateTimeKind.Local), 1, 1, true, false, null, null },
                    { 2, 1, "mustafa_yener05@hotmail.com", new DateTime(2024, 12, 4, 4, 58, 0, 0, DateTimeKind.Local), 2, 2, true, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "HotelOfficials",
                columns: new[] { "Id", "AddByUserId", "CorporateTitle", "CreatedDate", "HotelId", "IsActive", "IsDeleted", "Name", "SurName", "UpdatedByUserId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, "Müdür", new DateTime(2024, 12, 4, 4, 58, 0, 0, DateTimeKind.Local), 1, true, false, "Mustafa", "Yener", null, null },
                    { 2, 1, "Müdür2", new DateTime(2024, 12, 4, 4, 58, 0, 0, DateTimeKind.Local), 1, true, false, "Mustafa2", "Yener2", null, null }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AddByUserId", "CityId", "CreatedDate", "DistrictId", "IsActive", "IsDeleted", "Latitude", "Longitude", "Name", "UpdatedByUserId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 12, 4, 4, 58, 0, 0, DateTimeKind.Local), 1, true, false, 3542m, 5542m, "LocationName", null, null },
                    { 2, 1, 1, new DateTime(2024, 12, 4, 4, 58, 0, 0, DateTimeKind.Local), 1, true, false, 3542m, 5542m, "LocationName2", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactLocationMappings_HotelId",
                table: "ContactLocationMappings",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactLocationMappings_HotelLocationContactId",
                table: "ContactLocationMappings",
                column: "HotelLocationContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactLocationMappings_LocationId",
                table: "ContactLocationMappings",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_Contact_Content",
                table: "HotelContacts",
                column: "Content");

            migrationBuilder.CreateIndex(
                name: "IX_HotelContacts_HotelId",
                table: "HotelContacts",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_Location_Contact_Name",
                table: "HotelLocationContacts",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelLocationContacts_HotelId",
                table: "HotelLocationContacts",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_Official_Name",
                table: "HotelOfficials",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_HotelOfficials_HotelId",
                table: "HotelOfficials",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_Name",
                table: "Hotels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CityId",
                table: "Locations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_DistrictId",
                table: "Locations",
                column: "DistrictId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactLocationMappings");

            migrationBuilder.DropTable(
                name: "HotelContacts");

            migrationBuilder.DropTable(
                name: "HotelOfficials");

            migrationBuilder.DropTable(
                name: "HotelLocationContacts");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Citys");
        }
    }
}
