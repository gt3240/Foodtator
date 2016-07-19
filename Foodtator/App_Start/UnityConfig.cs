using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using System.Web.Http;
using Foodtator.Interfaces;
using Foodtator.Services;
using Foodtator.Core.Injection;
using System.Linq;
using System.Web.Http.Filters;

namespace Foodtator
{
    public static class UnityConfig
    {
        private static UnityContainer _container;

        public static UnityContainer GetContainer()
        {
            return _container;
        }
        public static void RegisterComponents(HttpConfiguration config)
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IResultsService, ResultsService>();
            container.RegisterType<ICheckInService, CheckInService>();
            container.RegisterType<IMediaService, MediaService>();
            container.RegisterType<IFileUploadService, FileUploadService>();
            container.RegisterType<IPointsService, PointsService>();
            container.RegisterType<ICouponService, CouponService>();
            container.RegisterType<ILocationService, LocationService>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            //  this line is needed so that the resolver can be used by api controllers 
            config.DependencyResolver = new UnityResolver(container);

            _container = container;

            //  we have to make a custom filter injector to provide DI to our custom action filters.
            //  see http://michael-mckenna.com/blog/dependency-injection-for-asp-net-web-api-action-filters-in-3-easy-steps
            var providers = config.Services.GetFilterProviders().ToList();

            var defaultprovider = providers.Single(i => i is ActionDescriptorFilterProvider);
            config.Services.Remove(typeof(System.Web.Http.Filters.IFilterProvider), defaultprovider);

            config.Services.Add(typeof(System.Web.Http.Filters.IFilterProvider), new UnityActionFilterProvider(container));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}