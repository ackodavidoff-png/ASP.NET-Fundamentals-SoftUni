using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "LastName", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 1, null, "Ivan", true, "Ivanov", "0888555123", "Vankata04" },
                    { 2, "go6opetroff@something.com", "Georgi", false, "Petrov", "0899123456", "Go6o.petroff" },
                    { 3, "st_dimitrov@mail.com", "Stojan", false, "Dimitrov", "0887654321", "stojandmtrv" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "CreatedOn", "Description", "EngineType", "HorsePower", "ImageUrl", "Mileage", "Model", "Price", "SellerId", "State", "TransmissionType", "Year" },
                values: new object[,]
                {
                    { 1, "Peugeot", new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Real kilometres,very well preserved.This car has never been in an accident.", 1, 250, null, 150000, "308SW", 10000.0, 1, 1, 1, 2015 },
                    { 2, "Toyota", new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Very well preserved.", 2, 180, null, 80000, "Yaris", 4000.0, 2, 1, 1, 2018 },
                    { 3, "VW", new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Very well preserved.The car is good for in-town and out-of-town driving.", 0, 250, null, 50000, "Golf", 7000.0, 3, 1, 0, 2020 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
