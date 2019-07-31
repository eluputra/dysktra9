using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ContosoUniversity.Migrations
{
    public partial class Inheritance : Migration
    {
        //replacing the up method 
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey( //Removes foreign key constraints and indexes that point to the Student table.
                name: "FK_Enrollment_Student_StudentID",
                table: "Enrollment");

            migrationBuilder.DropIndex(name: "IX_Enrollment_StudentID", table: "Enrollment");

            migrationBuilder.RenameTable(name: "Instructor", newName: "Person");// Renames the Instructor table as Person and makes changes needed for it to store Student data:
            migrationBuilder.AddColumn<DateTime>(name: "EnrollmentDate", table: "Person", nullable: true);// Adds nullable EnrollmentDate for students.
            migrationBuilder.AddColumn<string>(name: "Discriminator", table: "Person", nullable: false, maxLength: 128, defaultValue: "Instructor"); //Adds Discriminator column to indicate whether a row is for a student or an instructor.
            migrationBuilder.AlterColumn<DateTime>(name: "HireDate", table: "Person", nullable: true);// Makes HireDate nullable since student rows won't have hire dates.
            migrationBuilder.AddColumn<int>(name: "OldId", table: "Person", nullable: true);// Adds a temporary field that will be used to update foreign keys that point to students. When you copy students into the Person table they will get new primary key values.

            // Copy existing Student data into new Person table.
            migrationBuilder.Sql("INSERT INTO dbo.Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator, OldId) SELECT LastName, FirstName, null AS HireDate, EnrollmentDate, 'Student' AS Discriminator, ID AS OldId FROM dbo.Student");
            // Fix up existing relationships to match new PK's.
            migrationBuilder.Sql("UPDATE dbo.Enrollment SET StudentId = (SELECT ID FROM dbo.Person WHERE OldId = Enrollment.StudentId AND Discriminator = 'Student')");

            // Remove temporary key
            migrationBuilder.DropColumn(name: "OldID", table: "Person");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.CreateIndex(
                 name: "IX_Enrollment_StudentID",
                 table: "Enrollment",
                 column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Person_StudentID",
                table: "Enrollment",
                column: "StudentID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
