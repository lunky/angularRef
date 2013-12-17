using System;
using System.Diagnostics;
using angularRef.EntityFramework;
using Entities;
using Ninject;
using Ninject.Web.Common;
using Shared;

namespace angularRef.Service
{
	public static class NinjectConfigurator
	{
		public static void Configurate(IKernel kernel )
		{
			kernel.Bind<AppContext>().ToSelf().InRequestScope();
		//	kernel.Bind(typeof(IRepository<>), typeof(Repository<>));
			kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
			kernel.Bind<IRepository<Kid>>().To<Repository<Kid>>().InRequestScope();
			kernel.Bind<IKidService>().To<KidService>().InRequestScope();
		}
	}
}

