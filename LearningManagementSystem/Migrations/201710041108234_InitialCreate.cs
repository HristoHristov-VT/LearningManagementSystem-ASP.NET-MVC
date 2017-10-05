namespace LearningManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Attended = c.Boolean(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.String(),
                        Created = c.DateTime(nullable: false),
                        City = c.String(),
                        Adress = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        Phone = c.String(),
                        Status = c.Boolean(nullable: false),
                        Rude = c.String(),
                        Observation = c.String(),
                        IDGetGradeParallel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GradeParallels", t => t.IDGetGradeParallel_ID)
                .Index(t => t.IDGetGradeParallel_ID);
            
            CreateTable(
                "dbo.GradeParallels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IDGrade_ID = c.Int(),
                        IDStaff_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Grades", t => t.IDGrade_ID)
                .ForeignKey("dbo.Staffs", t => t.IDStaff_ID)
                .Index(t => t.IDGrade_ID)
                .Index(t => t.IDStaff_ID);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IDLevel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Levels", t => t.IDLevel_ID)
                .Index(t => t.IDLevel_ID);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Principle = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Gender = c.String(),
                        Created = c.DateTime(nullable: false),
                        City = c.String(),
                        Adress = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        Phone = c.String(),
                        Status = c.Boolean(nullable: false),
                        Category = c.String(),
                        DateOfHiring = c.DateTime(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDStaffType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.StaffTypes", t => t.IDStaffType_ID)
                .Index(t => t.IDStaffType_ID);
            
            CreateTable(
                "dbo.StaffTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cources",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SubjectGrades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDGrade_ID = c.Int(),
                        IDSubject_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Grades", t => t.IDGrade_ID)
                .ForeignKey("dbo.Subjects", t => t.IDSubject_ID)
                .Index(t => t.IDGrade_ID)
                .Index(t => t.IDSubject_ID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                        IDArea_ID = c.Int(),
                        IDStudent_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Areas", t => t.IDArea_ID)
                .ForeignKey("dbo.Students", t => t.IDStudent_ID)
                .Index(t => t.IDArea_ID)
                .Index(t => t.IDStudent_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectGrades", "IDSubject_ID", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "IDStudent_ID", "dbo.Students");
            DropForeignKey("dbo.Subjects", "IDArea_ID", "dbo.Areas");
            DropForeignKey("dbo.SubjectGrades", "IDGrade_ID", "dbo.Grades");
            DropForeignKey("dbo.Attendances", "ID", "dbo.Students");
            DropForeignKey("dbo.Students", "IDGetGradeParallel_ID", "dbo.GradeParallels");
            DropForeignKey("dbo.GradeParallels", "IDStaff_ID", "dbo.Staffs");
            DropForeignKey("dbo.Staffs", "IDStaffType_ID", "dbo.StaffTypes");
            DropForeignKey("dbo.GradeParallels", "IDGrade_ID", "dbo.Grades");
            DropForeignKey("dbo.Grades", "IDLevel_ID", "dbo.Levels");
            DropIndex("dbo.Subjects", new[] { "IDStudent_ID" });
            DropIndex("dbo.Subjects", new[] { "IDArea_ID" });
            DropIndex("dbo.SubjectGrades", new[] { "IDSubject_ID" });
            DropIndex("dbo.SubjectGrades", new[] { "IDGrade_ID" });
            DropIndex("dbo.Staffs", new[] { "IDStaffType_ID" });
            DropIndex("dbo.Grades", new[] { "IDLevel_ID" });
            DropIndex("dbo.GradeParallels", new[] { "IDStaff_ID" });
            DropIndex("dbo.GradeParallels", new[] { "IDGrade_ID" });
            DropIndex("dbo.Students", new[] { "IDGetGradeParallel_ID" });
            DropIndex("dbo.Attendances", new[] { "ID" });
            DropTable("dbo.Subjects");
            DropTable("dbo.SubjectGrades");
            DropTable("dbo.Cources");
            DropTable("dbo.StaffTypes");
            DropTable("dbo.Staffs");
            DropTable("dbo.Levels");
            DropTable("dbo.Grades");
            DropTable("dbo.GradeParallels");
            DropTable("dbo.Students");
            DropTable("dbo.Attendances");
            DropTable("dbo.Areas");
        }
    }
}
