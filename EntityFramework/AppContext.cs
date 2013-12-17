
using System.Data.Entity;
using Entities;

namespace angularRef.EntityFramework
{
	public class AppContext : DbContext
	{
		public IDbSet<Kid> Kids { get; set; }

		public AppContext()
			: base("angular.AppContext")
		{
			Configuration.AutoDetectChangesEnabled = false;
		}
	}
}