using DAI_MREO.Data;
using DAI_MREO.Services;
using DaiMreo_models;
using Microsoft.EntityFrameworkCore;

namespace DAI_MREO.Repositories
{
    public class CountryRepository : TemplateRepository<Country>
    {
        public CountryRepository(ErrorLogger logger, MreoStorageContext context)
            : base(logger, context)
        {
        }

        protected override DbSet<Country> DbSet => this.Context.Countries;
    }
}