using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAI_MREO.Data;
using DAI_MREO.Services;
using Microsoft.EntityFrameworkCore;

namespace DAI_MREO.Repositories
{
    public abstract class TemplateRepository<T> : IRepository<T>
        where T : class
    {
        protected readonly ErrorLogger Logger;
        protected readonly MreoStorageContext Context;

        protected TemplateRepository(ErrorLogger logger, MreoStorageContext context)
        {
            this.Logger = logger;
            this.Context = context;
        }

        protected abstract DbSet<T> DbSet { get; }

        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return this.DbSet.ToList();
            }
            catch (Exception ex)
            {
                this.Logger.Log(ex);
                return new List<T>();
            }
        }

        // Додано метод Find з використанням Expression<Func<T, bool>>, для пошуку потрібного нам атрибуту
        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return this.DbSet.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                this.Logger.Log(ex);
                return new List<T>();
            }
        }

        public virtual T? GetById(long id)
        {
            try
            {
                return this.DbSet.Find(id);
            }
            catch (Exception ex)
            {
                this.Logger.Log(ex);
                return null;
            }
        }

        public virtual void Create(T entity)
        {
            try
            {
                this.DbSet.Add(entity);
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.Logger.Log(ex);
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                this.DbSet.Update(entity);
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.Logger.Log(ex);
            }
        }

        public virtual void Delete(long id)
        {
            try
            {
                var entity = this.DbSet.Find(id);
                if (entity != null)
                {
                    this.DbSet.Remove(entity);
                    this.Context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                this.Logger.Log(ex);
            }
        }
    }
}