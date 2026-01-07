using DaiMreo_models;

namespace CSSD_2025_CSSD_Hutsol_N_A_Lab_2.Data.AbstractFactory
{
    public class DataFactory : IDataFactory
    {
        public IEnumerable<Color> GetColors() => new List<Color>
        {
            new Color { ColorId = 1, ColorName = "Red" },
            new Color { ColorId = 2, ColorName = "Blue" },
            new Color { ColorId = 3, ColorName = "Green" },
        };

        public IEnumerable<VehicleType> GetVehicleTypes() => new List<VehicleType>
        {
            new VehicleType { VehicleTypeId = 1, TypeName = "Sedan" },
            new VehicleType { VehicleTypeId = 2, TypeName = "SUV" },
            new VehicleType { VehicleTypeId = 3, TypeName = "Truck" },
        };

        public IEnumerable<Person> GetPersons()
        {
            return new List<Person>
    {
        new Person { PersonId = 1, Surname = "Smith", MiddleName = "John", Name = "Doe", DateOfBirth = new DateTime(1985, 5, 20, 0, 0, 0, DateTimeKind.Utc) },
        new Person { PersonId = 2, Surname = "Johnson", MiddleName = "Michael", Name = "Brown", DateOfBirth = new DateTime(1990, 8, 15, 0, 0, 0, DateTimeKind.Utc) },
        new Person { PersonId = 3, Surname = "Williams", MiddleName = "David", Name = "Taylor", DateOfBirth = new DateTime(1978, 12, 5, 0, 0, 0, DateTimeKind.Utc) },
    };
        }

        public IEnumerable<Brand> GetBrands() => new List<Brand>
        {
            new Brand { BrandId = 1, BrandName = "Toyota" },
            new Brand { BrandId = 2, BrandName = "Honda" },
            new Brand { BrandId = 3, BrandName = "Ford" },
        };

        public IEnumerable<TypeAdress> GetTypeAdresses() => new List<TypeAdress>
        {
            new TypeAdress { TypeAdressId = 1, TypeAdresName = "Residential" },
            new TypeAdress { TypeAdressId = 2, TypeAdresName = "Commercial" },
            new TypeAdress { TypeAdressId = 3, TypeAdresName = "Industrial" },
        };

        public IEnumerable<Country> GetCountries() => new List<Country>
        {
            new Country { CountryId = 1, CountryName = "Ukraine", Citizenship = "Ukrainian" },
        };

        public IEnumerable<Region> GetRegions() => new List<Region>
        {
            new Region { RegionId = 1, CountryId = 1, RegionName = "Kyivska Oblast" },
            new Region { RegionId = 2, CountryId = 1, RegionName = "Lvivska Oblast" },
            new Region { RegionId = 3, CountryId = 1, RegionName = "Odeska Oblast" },
        };

        public IEnumerable<City> GetCities() => new List<City>
        {
            new City { CityId = 1, RegionId = 1, CityName = "Kyiv" },
            new City { CityId = 2, RegionId = 2, CityName = "Lviv" },
            new City { CityId = 3, RegionId = 3, CityName = "Odesa" },
        };

        public IEnumerable<CarModel> GetModels() => new List<CarModel>
        {
            new CarModel { ModelId = 1, BrandId = 1, ModelName = "Corolla", ReleaseYear = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new CarModel { ModelId = 2, BrandId = 2, ModelName = "Civic", ReleaseYear = new DateTime(2005, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new CarModel { ModelId = 3, BrandId = 3, ModelName = "Mustang", ReleaseYear = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
        };

        public IEnumerable<Adress> GetAdresses() => new List<Adress>
        {
            new Adress { AdressId = 1, CityId = 1, AdressName = "Peremohy St, 1" },
            new Adress { AdressId = 2, CityId = 2, AdressName = "Svobody Av, 2" },
            new Adress { AdressId = 3, CityId = 3, AdressName = "Derybasivska St, 3" },
        };

        public IEnumerable<Factory> GetFactories() => new List<Factory>
        {
            new Factory { FactoryId = 1, TypeAdressId = 1, AdressId = 1, Building = "A", FactoryName = "Toyota Factory" },
            new Factory { FactoryId = 2, TypeAdressId = 2, AdressId = 2, Building = "B", FactoryName = "Honda Factory" },
            new Factory { FactoryId = 3, TypeAdressId = 3, AdressId = 3, Building = "C", FactoryName = "Ford Factory" },
        };

        public IEnumerable<ModelFactory> GetModelFactories() => new List<ModelFactory>
        {
            new ModelFactory { ModelFactoryId = 1, ModelId = 1, FactoryId = 1, ProductionStartDate = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new ModelFactory { ModelFactoryId = 2, ModelId = 2, FactoryId = 2, ProductionStartDate = new DateTime(2005, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new ModelFactory { ModelFactoryId = 3, ModelId = 3, FactoryId = 3, ProductionStartDate = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
        };
    }
}