using DAI_MREO.Data;
using DAI_MREO.Repositories.Patern;
using DAI_MREO.Services;
using DaiMreo_models;

namespace DAI_MREO.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MreoStorageContext context;
        private readonly ErrorLogger logger;

        private IRepository<Brand>? brands;
        private IRepository<Person>? persons;
        private IRepository<Country>? countries;
        private IRepository<Car>? cars;

        private bool disposed;

        public UnitOfWork(MreoStorageContext context, ErrorLogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public IRepository<Brand> Brands =>
            this.brands ??= new BrandRepository(this.logger, this.context);

        public IRepository<Person> Persons =>
            this.persons ??= new PersonRepository(this.logger, this.context);

        public IRepository<Country> Countries =>
            this.countries ??= new CountryRepository(this.logger, this.context);

        public IRepository<Car> Cars =>
            this.cars ??= new CarRepository(this.logger, this.context);

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }

                this.disposed = true;
            }
        }
    }
}