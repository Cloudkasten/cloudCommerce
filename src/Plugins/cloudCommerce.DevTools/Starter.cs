using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using cloudCommerce.Core.Infrastructure;
using cloudCommerce.Core.Plugins;
using cloudCommerce.Web.Framework;

namespace cloudCommerce.DevTools
{
	
	public class ProfilerPreApplicationStart : IPreApplicationStart
	{
		public void Start()
		{
			DynamicModuleUtility.RegisterModule(typeof(ProfilerHttpModule));
			SmartUrlRoutingModule.RegisterRoutablePath("/mini-profiler-resources/(.*)");
		}
	}

	public class ProfilerStartupTask : IStartupTask
	{
		public void Execute()
		{
			StackExchange.Profiling.EntityFramework6.MiniProfilerEF6.Initialize();
		}

		public int Order
		{
			get { return int.MinValue; }
		}
	}

}