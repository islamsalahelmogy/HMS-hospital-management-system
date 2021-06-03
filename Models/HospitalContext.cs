namespace HMS_ITI.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
            : base("name=Hospital")
        {
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Patient>().MapToStoredProcedures();
        //    base.OnModelCreating(modelBuilder);
        //}
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Faq> FaQ { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<RequestRegisterClinic> RequestRegisterClinic { get; set; }
        public virtual DbSet<Role_ActionName> Role_ActionNames { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ActionsName> ActionsNames { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Career> Careers { get; set; }
        public virtual DbSet<Clinic_Register> Clinic_Registers { get; set; }
        public virtual DbSet<Clinic_Type> Clinic_Types { get; set; }
        public virtual DbSet<Critical_Data> Critical_Datas { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Diagnosis> Diagnosis { get; set; }
        public virtual DbSet<Main_Group_Medicine> Main_Group_Medicines { get; set; }
        public virtual DbSet<Part_Group_Medicine> Part_Group_Medicines { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Medicine_Company> Medicine_Companies{ get; set; }
        public virtual DbSet<Medicine_Shape> Medicine_Shapes { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Wa7dat_Elmed> Wa7Dat_Elmeds { get; set; }
        public virtual DbSet<Sex_Type> Sex_Types { get; set; }
        public virtual DbSet<Systolic_Blood_Pressure> Systolic_Blood_Pressures { get; set; }
        public virtual DbSet<Recommendation_Adv> Recommendation_Advs { get; set; }
        public virtual DbSet<Recommendation_Advice> Recommendation_Advices { get; set; }
        public virtual DbSet<Religion> Religions { get; set; }
        public virtual DbSet<Time_Take_Medicine1> Time_Take_Medicine1s { get; set; }
        public virtual DbSet<Time_Take_Medicine2> Time_Take_Medicine2s { get; set; }
        public virtual DbSet<Specialist> Specialists { get; set; }
        public virtual DbSet<Number_Of_Take_Medicine> Number_Of_Take_Medicines { get; set; }
        public virtual DbSet<Register_Medicine> Register_Medicines { get; set; }
        public virtual DbSet<Crit_Data> Crit_Datas { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}