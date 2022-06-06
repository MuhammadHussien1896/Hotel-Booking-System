using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addingNoneIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerRoom_Customers_CustomersId",
                table: "CustomerRoom");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "CustomersId",
                table: "CustomerRoom",
                newName: "CustomersCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerRoom_Customers_CustomersCustomerId",
                table: "CustomerRoom",
                column: "CustomersCustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerRoom_Customers_CustomersCustomerId",
                table: "CustomerRoom");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CustomersCustomerId",
                table: "CustomerRoom",
                newName: "CustomersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerRoom_Customers_CustomersId",
                table: "CustomerRoom",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
