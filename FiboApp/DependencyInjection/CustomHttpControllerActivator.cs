using FiboApp.Computation.Services;
using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Unity;

namespace FiboApp.DependencyInjection
{
    /// <summary>
    /// CustomHttpControllerActivator.
    /// </summary>
    public class CustomHttpControllerActivator : IHttpControllerActivator
    {
        private readonly IUnityContainer _unityContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomHttpControllerActivator"/> class.
        /// </summary>
        public CustomHttpControllerActivator()
        {
            _unityContainer = new UnityContainer();
            _unityContainer.RegisterType<IComputationService, ComputationService>();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="request">HttpRequestMessage</param>
        /// <param name="controllerDescriptor">HttpControllerDescriptor</param>
        /// <param name="controllerType">Type</param>
        /// <returns>IHttpController</returns>
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return (IHttpController)_unityContainer.Resolve(controllerType);
        }
    }
}
