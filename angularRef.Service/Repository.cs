using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using angularRef.EntityFramework;
using Entities;

namespace angularRef.Service
{
	public class Repository<TEntity> : IDisposable, IRepository<TEntity>
		where TEntity : class, IEntity
	{
		protected DbSet<TEntity> DbSet { get; private set; }

		public Repository(AppContext context)
		{

			AppContext = context;
			Debug.WriteLine("Constructor()");
			Debug.WriteLine("Repository context = " + AppContext.GetHashCode());
			DbSet = AppContext.Set<TEntity>();
		}

		public virtual IQueryable<TEntity> All(params Expression<Func<TEntity, object>>[] entitiesToInclude)
		{
			Debug.WriteLine("All()");
			Debug.WriteLine("Repository context = " + AppContext.GetHashCode());

			return entitiesToInclude.Aggregate((IQueryable<TEntity>)DbSet, (current, entityToInclude) => current.Include(entityToInclude));
		}

		protected AppContext AppContext { get; private set; }

		public virtual void Insert(TEntity entity)
		{
			DbSet.Add(entity);
		}

		public virtual void InsertRange(IEnumerable<TEntity> entities)
		{
			foreach (var entity in entities)
			{
				Insert(entity);
			}
		}

		public virtual void Delete(int id)
		{
			var entity = FindById(id);
			if (entity != null)
			{
				Delete(entity);
			}
		}

		public virtual void Delete(TEntity entity)
		{
			DbSet.Remove(entity);
		}

		public virtual TEntity FindById(int id, params Expression<Func<TEntity, object>>[] entitiesToInclude)
		{
			Debug.WriteLine("FindById()");
			Debug.WriteLine("Repository context = " + AppContext.GetHashCode());
			return Find(x => x.Id == id, entitiesToInclude).FirstOrDefault();
			//return AppContext.Set<TEntity>().FirstOrDefault(f => f.Id == id);
		}

		public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] entitiesToInclude)
		{
			return entitiesToInclude.Aggregate(DbSet.Where(predicate), (current, entityToInclude) => current.Include(entityToInclude));
		}

		public int SaveChanges()
		{
			Debug.WriteLine("SaveChanges()");
			Debug.WriteLine("Repository context = " + AppContext.GetHashCode());
			AppContext.ChangeTracker.DetectChanges();
			return AppContext.SaveChanges();
		}

		public void Dispose()
		{
			if (AppContext != null)
			{
				AppContext.Dispose();
			}
			GC.SuppressFinalize(this);

		}
	}
}