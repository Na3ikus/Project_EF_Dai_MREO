using CSSD_2025_CSSD_Hutsol_N_A_Lab_2.Data.AbstractFactory;
using DaiMreo_models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAI_MREO.Data
{
    public class MreoStorageContext : DbContext
    {
        private readonly string? customConnectionString;

        public MreoStorageContext()
        {
        }

        public MreoStorageContext(string connectionString)
        {
            this.customConnectionString = connectionString;
        }

        public virtual DbSet<Accident> Accidents { get; set; }

        public virtual DbSet<ActionType> ActionTypes { get; set; }

        public virtual DbSet<Adress> Adresses { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<CarOwnersAction> CarOwnersActions { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<ContactType> ContactTypes { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Document> Documents { get; set; }

        public virtual DbSet<DocumentType> DocumentTypes { get; set; }

        public virtual DbSet<DriverLicense> DriverLicenses { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<EmployeeContact> EmployeeContacts { get; set; }

        public virtual DbSet<EmployeeDocument> EmployeeDocuments { get; set; }

        public virtual DbSet<Factory> Factories { get; set; }

        public virtual DbSet<Login> Logins { get; set; }

        public virtual DbSet<CarModel> Models { get; set; }

        public virtual DbSet<ModelFactory> ModelFactories { get; set; }

        public virtual DbSet<MreoLocation> MreoLocations { get; set; }

        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<PersonAdress> PersonAdresses { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<Region> Regions { get; set; }

        public virtual DbSet<TypeAdress> TypeAdreses { get; set; }

        public virtual DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ArgumentNullException.ThrowIfNull(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                if (!string.IsNullOrEmpty(this.customConnectionString))
                {
                    optionsBuilder.UseMySQL(this.customConnectionString);
                    return;
                }

                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("app_config.json", optional: false, reloadOnChange: true);

                IConfigurationRoot configuration = builder.Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection")
                    ?? throw new InvalidOperationException("Рядок підключення 'DefaultConnection' не знайдено у файлі app_config.json.");
                optionsBuilder.UseMySQL(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ArgumentNullException.ThrowIfNull(modelBuilder);

            base.OnModelCreating(modelBuilder);

            var dataFactory = new DataFactory();

            modelBuilder.Entity<Color>().HasData(dataFactory.GetColors());
            modelBuilder.Entity<VehicleType>().HasData(dataFactory.GetVehicleTypes());
            modelBuilder.Entity<Person>().HasData(dataFactory.GetPersons());
            modelBuilder.Entity<Brand>().HasData(dataFactory.GetBrands());
            modelBuilder.Entity<TypeAdress>().HasData(dataFactory.GetTypeAdresses());
            modelBuilder.Entity<Country>().HasData(dataFactory.GetCountries());
            modelBuilder.Entity<Region>().HasData(dataFactory.GetRegions());
            modelBuilder.Entity<City>().HasData(dataFactory.GetCities());
            modelBuilder.Entity<CarModel>().HasData(dataFactory.GetModels());
            modelBuilder.Entity<Adress>().HasData(dataFactory.GetAdresses());
            modelBuilder.Entity<Factory>().HasData(dataFactory.GetFactories());
            modelBuilder.Entity<ModelFactory>().HasData(dataFactory.GetModelFactories());
        }
    }
}