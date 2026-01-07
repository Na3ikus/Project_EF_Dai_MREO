using DAI_MREO.Data;
using DAI_MREO.Services;
using DaiMreo_models;
using Microsoft.EntityFrameworkCore;

namespace DAI_MREO.Repositories
{
    public class BrandRepository : TemplateRepository<Brand>
    {
        public BrandRepository(ErrorLogger logger, MreoStorageContext context)
            : base(logger, context)
        {
        }

        protected override DbSet<Brand> DbSet => this.Context.Brands;
    }
}
