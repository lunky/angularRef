using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using angularRef.EntityFramework;

namespace angularRef.Service
{
	public class UnitOfWork: IUnitOfWork
	{
		private readonly AppContext _context;

		public UnitOfWork(AppContext context)
		{
			_context = context;
		}

		public int SaveChanges()
		{
			return _context.SaveChanges();
		}
	}
}
