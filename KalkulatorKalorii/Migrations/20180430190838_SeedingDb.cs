using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KalkulatorKalorii.Migrations
{
    public partial class SeedingDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Macronutrients (Fat, Carbs, Protein, Roughage) VALUES (3, 41, 13, 0)");
            migrationBuilder.Sql("INSERT INTO Macronutrients (Fat, Carbs, Protein, Roughage) VALUES (1, 30, 7, 2)");
            migrationBuilder.Sql("INSERT INTO Macronutrients (Fat, Carbs, Protein, Roughage) VALUES (3, 0, 17, 0)");

            migrationBuilder.Sql("INSERT INTO ProductTypes (Type, Content, IsVegan) VALUES (4, 1, 0)");
            migrationBuilder.Sql("INSERT INTO ProductTypes (Type, Content, IsVegan) VALUES (7, 1, 0)");
            migrationBuilder.Sql("INSERT INTO ProductTypes (Type, Content, IsVegan) VALUES (1, 2, 0)");

            migrationBuilder.Sql("INSERT INTO Products (Description, Producer, Calories, ProductTypeId, MacronutrientId) VALUES ('Chleb', '', 247, 1, 1)");
            migrationBuilder.Sql("INSERT INTO Products (Description, Producer, Calories, ProductTypeId, MacronutrientId) VALUES ('Makaron Spagetti', '', 154, 2, 2)");
            migrationBuilder.Sql("INSERT INTO Products (Description, Producer, Calories, ProductTypeId, MacronutrientId) VALUES ('Szynka', '', 96, 3, 3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Macronutrients");
            migrationBuilder.Sql("DELETE FROM ProductTypes");
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
