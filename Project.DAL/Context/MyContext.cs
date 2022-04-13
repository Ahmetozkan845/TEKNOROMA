using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Context
{
    using MAP.Options;
    using ENTITIES.Models;
    using DAL.StrategyPattern;
    using System.Data.Entity;

    public class MyContext:DbContext
    {
        //Data Bağlantı yolunu ver
        // strateji dizayn içerisinde projedeki kişileri tanıt
        // Projede oluşturulacak classları burda tut
        /// <summary>
        ///Employee - Product - Issue - Category 
       
        ///Message - Supplier(Tedarikçi) -Expense(Harcamalar) - Territory(Bölge) -EmployeeTerritory(Çalışan bölgesi) 
        ///
        ///Shipper(nakliye) - Order  - OrderDetail - 
        /// </summary>

        public MyContext():base("MyConnection")
        {
            //Verilen bağlam türü için kullanılacak veritabanı başlatıcısını ayarlar. Veritabanına
            //DbContext ilk kez erişmek için verilen tür kullanıldığında veritabanı başlatıcısı çağırılır.
            //Code First bağlamlarının varsayılan stratejisi, örneğidir
            //CreateDatabaseIfNotExists<TContext> .
            Database.SetInitializer(new MyInit());

        }
        //modelBuilder.Configurations.Add(new MAP YAPILARINI VER---->)
        //MAP LERİ TANIMLA 
        //Mappingleri override onmodelcreating ile kullan
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new EmployeeTerritoryMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new MessageMap());
            modelBuilder.Configurations.Add(new ExpenseMap());
            modelBuilder.Configurations.Add(new IssueMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ShipperMap());
            modelBuilder.Configurations.Add(new SupplierMap());
            modelBuilder.Configurations.Add(new TerritoryMap());
            modelBuilder.Configurations.Add(new UserProfileMap());
            
            
        }

        //DbSet Propertylerini tanımla.
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public DbSet<Expense> Expenses { get; set; }      
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Message> Messages { get; set; }      
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Territory> Territories { get; set; }
        
    }
}
