using DAI_MREO.Data;
using DAI_MREO.Services;
using DaiMreo_models;
using Microsoft.EntityFrameworkCore;

namespace DAI_MREO.Repositories
{
    public class PersonRepository : TemplateRepository<Person>
    {
        public PersonRepository(ErrorLogger logger, MreoStorageContext context)
            : base(logger, context)
        {
        }

        protected override DbSet<Person> DbSet => this.Context.Persons;
    }
}