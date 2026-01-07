using DaiMreo_models;

namespace CSSD_2025_CSSD_Hutsol_N_A_Lab_2.Data.AbstractFactory
{
    public interface IDataFactory
    {
        IEnumerable<Color> GetColors();

        IEnumerable<VehicleType> GetVehicleTypes();

        IEnumerable<Person> GetPersons();

        IEnumerable<Brand> GetBrands();

        IEnumerable<TypeAdress> GetTypeAdresses();

        IEnumerable<Country> GetCountries();

        IEnumerable<Region> GetRegions();

        IEnumerable<City> GetCities();

        IEnumerable<CarModel> GetModels();

        IEnumerable<Adress> GetAdresses();

        IEnumerable<Factory> GetFactories();

        IEnumerable<ModelFactory> GetModelFactories();
    }
}