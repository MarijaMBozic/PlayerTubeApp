using Server.Helper.Exeptions;
using Server.Repository;
using Server.Repository.Interface;
using Server.Resolver;
using Server.Service;
using Server.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using Unity.Lifetime;

namespace Server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // CORS
            var
            cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            
            // Web API configuration and services
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
            config.Filters.Add(new AuthorizeAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Unity
            var container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommentRepository, CommentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommentService, CommentService>(new HierarchicalLifetimeManager());
            container.RegisterType<ILoginRepository, LoginRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ILoginService, LoginService>(new HierarchicalLifetimeManager());
            container.RegisterType<IVideoRepository, VideoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IVideoService, VideoService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
