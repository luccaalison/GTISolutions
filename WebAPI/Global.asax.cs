using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;
using Unity.Lifetime;
using WebAPI;
using WebAPI.Interfaces;
using WebAPI.Repositories;
using WebAPI.Services;
using Swashbuckle.Application;
using WebAPI.Handles;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start() {

            ConfigureSwagger();

            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                name: "SwaggerStart",
                routeTemplate: string.Empty,
                defaults: null,
                constraints: null,
                handler: new RedirectToSwaggerHandler()
            );

            var container = new UnityContainer();
            RegisterTypes(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }

        private void RegisterTypes(IUnityContainer container) {
            container.RegisterType<IClienteRepository, ClienteRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IClienteService, ClienteService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEnderecoClienteRepository, EnderecoClienteRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEnderecoClienteService, EnderecoClienteService>(new HierarchicalLifetimeManager());
        }

        private void ConfigureSwagger() {
            GlobalConfiguration.Configuration.EnableSwagger(c => {
                c.SingleApiVersion("v1", "Sua API");
                c.IncludeXmlComments(GetXmlCommentsPath());
            })
            .EnableSwaggerUi(c => {});
        }

        private static string GetXmlCommentsPath() {
            return System.String.Format(@"{0}\bin\WebAPI.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
