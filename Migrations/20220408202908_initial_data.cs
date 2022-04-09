using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsLessons.Migrations
{
    public partial class initial_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql(@"
            //    INSERT INTO [dbo].[Course] ([Name]) VALUES ('Jedi')
            //    INSERT INTO [dbo].[Course] ([Name]) VALUES ('Combat Pilot')
            //    INSERT INTO [dbo].[Course] ([Name]) VALUES ('Bounty Hunter')
            //    INSERT INTO [dbo].[Course] ([Name]) VALUES ('Smuggler')
                
            //    DECLARE @course1Id INT
            //    SELECT @course1Id = [Id] FROM [dbo].[Course] WHERE [Name] = 'Jedi'
            //    DECLARE @course2Id INT
            //    SELECT @course2Id = [Id] FROM [dbo].[Course] WHERE [Name] = 'Combat Pilot'
            //    DECLARE @course3Id INT
            //    SELECT @course3Id = [Id] FROM [dbo].[Course] WHERE [Name] = 'Bounty Hunter'
            //    DECLARE @course4Id INT
            //    SELECT @course4Id = [Id] FROM [dbo].[Course] WHERE [Name] = 'Smuggler'

            //    INSERT INTO [dbo].[Lesson] ([Name], [CourseId]) VALUES ('Light Saber', @course1Id)
            //    INSERT INTO [dbo].[Lesson] ([Name], [CourseId]) VALUES ('Use of the Force', @course1Id)
            //    INSERT INTO [dbo].[Lesson] ([Name], [CourseId]) VALUES ('X Wing Pilot', @course2Id)
            //    INSERT INTO [dbo].[Lesson] ([Name], [CourseId]) VALUES ('Millenium Falcon Pilot', @course4Id)
            //    INSERT INTO [dbo].[Lesson] ([Name], [CourseId]) VALUES ('Combat Skills', @course3Id)

            //    DECLARE @lesson1Id INT
            //    SELECT @lesson1Id = [Id] FROM [dbo].[Course] WHERE [Name] = 'Light Saber'
            //    DECLARE @lesson2Id INT
            //    SELECT @lesson2Id = [Id] FROM [dbo].[Course] WHERE [Name] = 'Use of the Force'
            //    DECLARE @lesson3Id INT
            //    SELECT @lesson3Id = [Id] FROM [dbo].[Course] WHERE [Name] = 'X wing Pilot'
            //    DECLARE @lesson4Id INT
            //    SELECT @lesson4Id = [Id] FROM [dbo].[Course] WHERE [Name] = 'Millenium Falcon Pilot'
            //    DECLARE @lesson5Id INT
            //    SELECT @lesson5Id = [Id] FROM [dbo].[Course] WHERE [Name] = 'Combat Skills'

            //    INSERT INTO [dbo].[User]([FirstName], [LastName]) VALUES('Luke', 'Skywalker')
            //    INSERT INTO [dbo].[User]([FirstName], [LastName]) VALUES('Han', 'Solo')
            //    INSERT INTO [dbo].[User]([FirstName], [LastName]) VALUES('ObiWan', 'Kenobi')
            //    INSERT INTO [dbo].[User]([FirstName], [LastName]) VALUES('Booba', 'Fett')
            //    INSERT INTO [dbo].[User]([FirstName], [LastName]) VALUES('Lando', 'Calrissian')

            //");

        }



        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
