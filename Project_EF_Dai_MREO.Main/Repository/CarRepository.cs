using DAI_MREO.Data;
using DAI_MREO.Services;
using DaiMreo_models;
using Microsoft.EntityFrameworkCore;

namespace DAI_MREO.Repositories
{
    public class CarRepository : TemplateRepository<Car>
    {
        public CarRepository(ErrorLogger logger, MreoStorageContext context)
            : base(logger, context)
        {
        }

        protected override DbSet<Car> DbSet => this.Context.Cars;
    }
}