using System.Web;
using System.Web.Mvc;
using angularRef.Service;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace angularRef
{
	public static class Bootstrapper
	{
		public static IUnityContainer Initialise()
		{
			var container = BuildUnityContainer();

			DependencyResolver.SetResolver(new UnityDependencyResolver(container));

			return container;
		}

		private static IUnityContainer BuildUnityContainer()
		{
			var container = UnityConfigurator.Configurate(new PerRequestLifetimeManager());
			RegisterTypes(container);
			return container;
		}

		public static void RegisterTypes(IUnityContainer container)
		{

		}
	}

	public class PerRequestLifetimeManager : LifetimeManager
	{
		private readonly object key = new object();

		public override object GetValue()
		{
			if (HttpContext.Current != null &&
				HttpContext.Current.Items.Contains(key))
				return HttpContext.Current.Items[key];
			else
				return null;
		}

		public override void RemoveValue()
		{
			if (HttpContext.Current != null)
				HttpContext.Current.Items.Remove(key);
		}

		public override void SetValue(object newValue)
		{
			if (HttpContext.Current != null)
				HttpContext.Current.Items[key] = newValue;
		}
	}
}