using System;
using System.Collections.Generic;
using cloudCommerce.Core.Configuration;
using cloudCommerce.Core.Infrastructure.DependencyManagement;

namespace cloudCommerce.Core.Infrastructure
{
    /// <summary>
    /// Classes implementing this interface can serve as a portal for the 
    /// various services composing the cloudCommerce engine. Edit functionality, modules
    /// and implementations access most cloudCommerce functionality through this 
    /// interface.
    /// </summary>
    public interface IEngine
    {
        ContainerManager ContainerManager { get; }
        
        /// <summary>
        /// Initialize components and plugins in the cloudCommerce environment.
        /// </summary>
        void Initialize();

        T Resolve<T>(string name = null) where T : class;

        object Resolve(Type type, string name = null);

        T[] ResolveAll<T>();
    }
}
