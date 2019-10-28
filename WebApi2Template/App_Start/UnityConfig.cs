using DoCAS.Service.Katalog.Utils.Authentication.Http;
using DoCAS.Service.Katalog.Utils.Unity;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using WebApi2Template.Interfaces.Authentication;
using WebApi2Template.Interfaces.Repositories;
using WebApi2Template.Repositories;

namespace WebApi2Template
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterInstance<IAuthService>(new AuthService());
            container.RegisterType<IPersonRepository, PersonRepository>();
            container.RegisterType<IDataBaseConnection, HoldRepository>();

            DependencyFactory.SetFactory(() => container.Resolve<IAuthService>());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}