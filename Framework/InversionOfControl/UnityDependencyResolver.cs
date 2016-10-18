using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace WS_Hotline.Framework.InversionOfControl
{
    /// <summary>
    /// MVVM light Dependency Resolver used to encapsulate dependency on IoC/DI container
    /// </summary>
    public class UnityDependencyResolver : System.Web.Mvc.IDependencyResolver
    {
        private readonly IUnityContainer _container;

        /// <summary>
        /// Instanticate, only once in ViewModelLocator
        /// </summary>
        public UnityDependencyResolver()
        {
            this._container = ContainerConfiguration.Configure();
        }

        /// <summary>
        /// Get one service implementation for <see cref="pServiceType"/>
        /// </summary>
        /// <param name="pServiceType">Type of service requested</param>
        /// <returns>One service implementation</returns>
        public object GetService(Type pServiceType)
        {
            // According to contract, it return null if it cannot resolve "serviceType"
            // It resolves against registered types AND not abstract classes (since they are managed by Unity even if not registered)
            //return this._container.IsRegistered(pServiceType) || (pServiceType.IsClass && !pServiceType.IsAbstract) ? this._container.Resolve(pServiceType, pServiceType.Name) : null;
            return null;
        }


        public object GetInstance(Type pServiceType)
        {
            return this._container.IsRegistered(pServiceType) || (pServiceType.IsClass && !pServiceType.IsAbstract) ? this._container.Resolve(pServiceType, pServiceType.Name) : null;
        } 
        public object GetInstance(Type pServiceType, string pKey)
        {
            return this._container.IsRegistered(pServiceType) || (pServiceType.IsClass && !pServiceType.IsAbstract) ? this._container.Resolve(pServiceType, pKey) : null;
        } 
        public IEnumerable<object> GetAllInstances(Type pServiceType)
        {
            return this._container.ResolveAll(pServiceType);
        }

        public TService GetInstance<TService>()
        {
            return this._container.Resolve<TService>();
        } 
        public TService GetInstance<TService>(string pKey)
        {
            return this._container.Resolve<TService>(pKey);
        } 
        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return this._container.ResolveAll<TService>();
        }


        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.GetAllInstances(serviceType);
        }
    }
}