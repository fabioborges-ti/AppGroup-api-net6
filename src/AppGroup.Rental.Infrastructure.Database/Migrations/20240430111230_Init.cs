using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppGroup.Rental.Infrastructure.Database.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_motodrivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Cnpj = table.Column<string>(type: "text", nullable: true),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Cnh = table.Column<string>(type: "text", nullable: true),
                    CnhType = table.Column<int>(type: "integer", nullable: false),
                    CnhImage = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_motodrivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_motorcycles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: true),
                    PlateNumber = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_motorcycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_prices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Days = table.Column<int>(type: "integer", nullable: false),
                    Daily = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RaceValue = table.Column<double>(type: "double precision", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    MotodriverId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Motodrivers",
                        column: x => x.MotodriverId,
                        principalTable: "tb_motodrivers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_rents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Forecast = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ValueForecast = table.Column<double>(type: "double precision", nullable: true),
                    TotalPrice = table.Column<double>(type: "double precision", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    MotodriverId = table.Column<Guid>(type: "uuid", nullable: false),
                    MotorcycleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PriceId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Motodrivers",
                        column: x => x.MotodriverId,
                        principalTable: "tb_motodrivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_Motorcycles",
                        column: x => x.MotorcycleId,
                        principalTable: "tb_motorcycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_Prices",
                        column: x => x.PriceId,
                        principalTable: "tb_prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    MotodriverId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motodrivers_Notifications",
                        column: x => x.MotodriverId,
                        principalTable: "tb_motodrivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Notifications",
                        column: x => x.OrderId,
                        principalTable: "tb_orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tb_motorcycles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "LastModifiedAt", "LastModifiedBy", "Model", "PlateNumber", "Status", "Year" },
                values: new object[,]
                {
                    { new Guid("03d4234d-49fc-4231-9998-f9fcec57bc95"), new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7729), null, null, null, null, null, "Honda Twister 250", "ABC0004", 0, 2019 },
                    { new Guid("08235c98-63f7-4168-9aaf-b1189ac9f11c"), new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7775), null, null, null, null, null, "Yamaha Fazer 250", "ABC0007", 0, 2016 },
                    { new Guid("1b2c7c2b-ec6e-4422-9539-b6da50586d31"), new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7765), null, null, null, null, null, "Honda Titan 160", "ABC0006", 0, 2017 },
                    { new Guid("2ed74138-9577-4531-a976-79770081369a"), new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7720), null, null, null, null, null, "Honda Twister 250", "ABC0003", 0, 2018 },
                    { new Guid("40bc36d8-e64d-43cb-8db4-1ee2921370d6"), new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7695), null, null, null, null, null, "Honda CB 300 R", "ABC0001", 0, 2015 },
                    { new Guid("5aafa0de-b564-4874-bd64-98ea8269f7fb"), new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7784), null, null, null, null, null, "Yamaha Fazer 250", "ABC0008", 0, 2020 },
                    { new Guid("ad8aa3fe-03f4-45bd-946a-20fe64d4ad7a"), new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7739), null, null, null, null, null, "Honda Titan 160", "ABC0005", 0, 2016 },
                    { new Guid("e16af1cc-a93e-44a2-9218-b169793c692d"), new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7711), null, null, null, null, null, "Honda CB 300 F", "ABC0002", 0, 2017 }
                });

            migrationBuilder.InsertData(
                table: "tb_prices",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Daily", "Days", "DeletedAt", "DeletedBy", "LastModifiedAt", "LastModifiedBy" },
                values: new object[,]
                {
                    { new Guid("1d8d6248-ec0c-41e7-9738-798c06654610"), new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7677), null, 28.0, 15, null, null, null, null },
                    { new Guid("c29ff565-557d-4eee-b93d-dfec01e31afc"), new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7633), null, 30.0, 7, null, null, null, null },
                    { new Guid("ddd5ab8b-3b6e-43fa-b3a4-f761918d004b"), new DateTime(2024, 4, 30, 11, 12, 30, 534, DateTimeKind.Utc).AddTicks(7686), null, 22.0, 30, null, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_motodrivers_Cnh",
                table: "tb_motodrivers",
                column: "Cnh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_motodrivers_Cnpj",
                table: "tb_motodrivers",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_motorcycles_PlateNumber",
                table: "tb_motorcycles",
                column: "PlateNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_notifications_MotodriverId",
                table: "tb_notifications",
                column: "MotodriverId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_notifications_OrderId",
                table: "tb_notifications",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_orders_MotodriverId",
                table: "tb_orders",
                column: "MotodriverId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_rents_MotodriverId",
                table: "tb_rents",
                column: "MotodriverId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_rents_MotorcycleId",
                table: "tb_rents",
                column: "MotorcycleId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_rents_PriceId",
                table: "tb_rents",
                column: "PriceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_notifications");

            migrationBuilder.DropTable(
                name: "tb_rents");

            migrationBuilder.DropTable(
                name: "tb_orders");

            migrationBuilder.DropTable(
                name: "tb_prices");

            migrationBuilder.DropTable(
                name: "tb_motodrivers");

            migrationBuilder.DropTable(
                name: "tb_motorcycles");
        }
    }
}
