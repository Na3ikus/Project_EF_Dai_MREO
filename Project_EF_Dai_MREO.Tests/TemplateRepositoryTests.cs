using NUnit.Framework;
using DAI_MREO.Repositories;
using DAI_MREO.Services;
using DAI_MREO.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace DAI_MREO.Tests
{
#nullable enable
    public class TemplateRepositoryTests
    {
        private TestMreoContext? context;
        private ErrorLogger? logger;
        private PersonRepository? repo;

        [SetUp]
        public void Setup()
        {
            string dbName = Guid.NewGuid().ToString();
            context = new TestMreoContext(dbName);

            logger = new ErrorLogger();
            repo = new PersonRepository(logger, context);

            context.Persons.AddRange(
                new DaiMreo_models.Person { PersonId = 1, Name = "John", Surname = "Doe", MiddleName = "", DateOfBirth = DateTime.UtcNow },
                new DaiMreo_models.Person { PersonId = 2, Name = "Jane", Surname = "Smith", MiddleName = "", DateOfBirth = DateTime.UtcNow }
            );
            context.SaveChanges();
        }

        [Test]
        public void GetAll_ReturnsAll()
        {
            var all = repo!.GetAll().ToList();
            Assert.AreEqual(2, all.Count);
        }

        [Test]
        public void GetById_ReturnsEntity()
        {
            var p = repo!.GetById(1);
            Assert.IsNotNull(p);
            Assert.AreEqual("John", p!.Name);
            Assert.AreEqual("Doe", p.Surname);
        }

        class TestMreoContext : MreoStorageContext
        {
            private readonly string dbName;

            public TestMreoContext(string dbName)
            {
                this.dbName = dbName;
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseInMemoryDatabase(this.dbName);
                }
            }
        }
    }
}

