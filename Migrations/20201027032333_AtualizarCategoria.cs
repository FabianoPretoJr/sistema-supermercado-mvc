﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace sistema_supermercado_mvc.Migrations
{
    public partial class AtualizarCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Categorias",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Categorias");
        }
    }
}
