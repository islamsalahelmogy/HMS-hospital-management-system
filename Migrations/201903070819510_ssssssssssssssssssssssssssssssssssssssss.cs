namespace HMS_ITI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ssssssssssssssssssssssssssssssssssssssss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Register_Medicine", "Id_Nozom", "dbo.Patients");
            DropForeignKey("dbo.Registrations", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Role_ActionName", "ActionNameId", "dbo.ActionsNames");
            DropIndex("dbo.ActionsNames", new[] { "ActionName" });
            DropIndex("dbo.ActionsNames", new[] { "ShowName" });
            DropIndex("dbo.Registrations", new[] { "RoleId" });
            DropIndex("dbo.Clinic_Register", new[] { "DepartmentId" });
            DropIndex("dbo.Register_Medicine", new[] { "Id_Nozom" });
            DropPrimaryKey("dbo.ActionsNames");
            AddColumn("dbo.Crit_Data", "UserId", c => c.Int());
            AddColumn("dbo.Diagnosis", "UserId", c => c.Int());
            AddColumn("dbo.Recommendation_Adv", "UserId", c => c.Int());
            AlterColumn("dbo.ActionsNames", "ID", c => c.Int(nullable: false));
            AlterColumn("dbo.ActionsNames", "ActionName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ActionsNames", "ShowName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Roles", "RoleNameEn", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Registrations", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.Critical_Data", "Critic_Data", c => c.String(maxLength: 500));
            AlterColumn("dbo.Nationalities", "Nationa", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Recommendation_Adv", "Notes", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Faqs", "Description", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Images", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Images", "Image1", c => c.String());
            AlterColumn("dbo.Images", "Image2", c => c.String());
            AlterColumn("dbo.Images", "Image3", c => c.String());
            AlterColumn("dbo.Images", "Image4", c => c.String());
            AlterColumn("dbo.Main_Group_Medicine", "NameArabic", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Main_Group_Medicine", "NameEnglish", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Part_Group_Medicine", "NameArabic", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Part_Group_Medicine", "NameEnglish", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Medicines", "MedNameArabic", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Medicines", "MedNameEnglish", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Medicine_Shape", "Name_Arabic", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Medicine_Shape", "Name_English", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Number_Of_Take_Medicine", "Number", c => c.String(maxLength: 100));
            AlterColumn("dbo.Time_Take_Medicine2", "Time", c => c.String(maxLength: 50));
            AlterColumn("dbo.Specialists", "SpecialistNameEn", c => c.String(maxLength: 100));
            AlterColumn("dbo.Staffs", "Bio", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Staffs", "Position", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Staffs", "FullName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Systolic_Blood_Pressure", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Systolic_Blood_Pressure", "DateOf_TakeTheStatment", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Systolic_Blood_Pressure", "TimeOf_TakeTheStatment", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.ActionsNames", "ID");
            CreateIndex("dbo.ActionsNames", "ActionName", unique: true);
            CreateIndex("dbo.ActionsNames", "ShowName", unique: true);
            CreateIndex("dbo.Registrations", "RoleId");
            CreateIndex("dbo.Clinic_Register", new[] { "Id_patient", "DateIncoming", "DepartmentId" }, unique: true, name: "cln");
            AddForeignKey("dbo.Registrations", "RoleId", "dbo.Roles", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Role_ActionName", "ActionNameId", "dbo.ActionsNames", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Role_ActionName", "ActionNameId", "dbo.ActionsNames");
            DropForeignKey("dbo.Registrations", "RoleId", "dbo.Roles");
            DropIndex("dbo.Clinic_Register", "cln");
            DropIndex("dbo.Registrations", new[] { "RoleId" });
            DropIndex("dbo.ActionsNames", new[] { "ShowName" });
            DropIndex("dbo.ActionsNames", new[] { "ActionName" });
            DropPrimaryKey("dbo.ActionsNames");
            AlterColumn("dbo.Systolic_Blood_Pressure", "TimeOf_TakeTheStatment", c => c.String(maxLength: 50));
            AlterColumn("dbo.Systolic_Blood_Pressure", "DateOf_TakeTheStatment", c => c.String(maxLength: 50));
            AlterColumn("dbo.Systolic_Blood_Pressure", "Date", c => c.String(maxLength: 50));
            AlterColumn("dbo.Staffs", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.Staffs", "Position", c => c.String(nullable: false));
            AlterColumn("dbo.Staffs", "Bio", c => c.String(nullable: false));
            AlterColumn("dbo.Specialists", "SpecialistNameEn", c => c.String(maxLength: 50));
            AlterColumn("dbo.Time_Take_Medicine2", "Time", c => c.String(maxLength: 20));
            AlterColumn("dbo.Number_Of_Take_Medicine", "Number", c => c.String(maxLength: 50));
            AlterColumn("dbo.Medicine_Shape", "Name_English", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Medicine_Shape", "Name_Arabic", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Medicines", "MedNameEnglish", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Medicines", "MedNameArabic", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Part_Group_Medicine", "NameEnglish", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Part_Group_Medicine", "NameArabic", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Main_Group_Medicine", "NameEnglish", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Main_Group_Medicine", "NameArabic", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Images", "Image4", c => c.String(maxLength: 100));
            AlterColumn("dbo.Images", "Image3", c => c.String(maxLength: 100));
            AlterColumn("dbo.Images", "Image2", c => c.String(maxLength: 100));
            AlterColumn("dbo.Images", "Image1", c => c.String(maxLength: 100));
            AlterColumn("dbo.Images", "Date", c => c.String(maxLength: 50));
            AlterColumn("dbo.Faqs", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Recommendation_Adv", "Notes", c => c.String());
            AlterColumn("dbo.Nationalities", "Nationa", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Critical_Data", "Critic_Data", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Registrations", "RoleId", c => c.Int());
            AlterColumn("dbo.Roles", "RoleNameEn", c => c.String(nullable: false));
            AlterColumn("dbo.ActionsNames", "ShowName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.ActionsNames", "ActionName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.ActionsNames", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Recommendation_Adv", "UserId");
            DropColumn("dbo.Diagnosis", "UserId");
            DropColumn("dbo.Crit_Data", "UserId");
            AddPrimaryKey("dbo.ActionsNames", "ID");
            CreateIndex("dbo.Register_Medicine", "Id_Nozom");
            CreateIndex("dbo.Clinic_Register", "DepartmentId");
            CreateIndex("dbo.Registrations", "RoleId");
            CreateIndex("dbo.ActionsNames", "ShowName", unique: true);
            CreateIndex("dbo.ActionsNames", "ActionName", unique: true);
            AddForeignKey("dbo.Role_ActionName", "ActionNameId", "dbo.ActionsNames", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Registrations", "RoleId", "dbo.Roles", "ID");
            AddForeignKey("dbo.Register_Medicine", "Id_Nozom", "dbo.Patients", "ID_Nozom");
        }
    }
}
