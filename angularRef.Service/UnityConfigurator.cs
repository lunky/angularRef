using System.Data.Entity;
using angularRef.EntityFramework;
using Entities;
using Microsoft.Practices.Unity;
using Shared;

namespace angularRef.Service
{
	public static class UnityConfigurator
	{
		public static IUnityContainer Configurate(LifetimeManager lifetimeManager)
		{
			var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers

			container.RegisterType<DbContext, AppContext>(lifetimeManager);

			// Register Repositories
			container.RegisterType(typeof (IRepository<>), typeof (Repository<>));
			container.RegisterType<IRepository<Kid>, Repository<Kid>>();

			container.RegisterType<IKidService, KidService>();
			container.RegisterType<IUnitOfWork, UnitOfWork>();

			// e.g. container.RegisterType<ITestService, TestService>();    

			return container;
		}
	}
}