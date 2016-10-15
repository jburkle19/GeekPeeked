using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GeekPeeked.Web.Startup))]
namespace GeekPeeked.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var builder = new ContainerBuilder();
            //HttpConfiguration config = new HttpConfiguration();

            //builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            //builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            //builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            //builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            //builder.Register<IAuthenticationManager>(x => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            //builder.Register<IDataProtectionProvider>(x => app.GetDataProtectionProvider()).InstancePerRequest();
            //builder.RegisterType<CustomEmailService>().As<IIdentityMessageService>().InstancePerRequest();
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //       .Where(x => x.Namespace.EndsWith(".Repositories"))
            //       .AsImplementedInterfaces();

            //builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterWebApiFilterProvider(config);

            //var container = builder.Build();

            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //app.UseAutofacMiddleware(container);
            //app.UseAutofacMvc();

            //ConfigureOAuth(app);
            //WebApiConfig.Register(config);
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            //app.UseWebApi(config);

            //ConfigureAuth(app);
            ConfigureAuth(app);
        }

        //public void ConfigureOAuth(IAppBuilder app)
        //{
        //    OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
        //    {
        //        AllowInsecureHttp = true,
        //        TokenEndpointPath = new PathString("/Api/v1/Users/Login"),
        //        AccessTokenExpireTimeSpan = TimeSpan.FromDays(30),
        //        Provider = new SimpleAuthorizationServerProvider()
        //    };

        //    app.UseOAuthAuthorizationServer(OAuthServerOptions);
        //    app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        //}
    }
}
