using DaiMreo_models;

namespace DAI_MREO.Repositories.Patern
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Brand> Brands { get; }

        IRepository<Person> Persons { get; }

        IRepository<Country> Countries { get; }

        IRepository<Car> Cars { get; }
    }
}