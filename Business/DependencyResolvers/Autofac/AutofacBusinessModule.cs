using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SessionManager>().As<ISessionService>().SingleInstance();
            builder.RegisterType<EfSessionDal>().As<ISessionDal>().SingleInstance();

            builder.RegisterType<LanguageManager>().As<ILanguageService>().SingleInstance();
            builder.RegisterType<EfLanguageDal>().As<ILanguageDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthorizationManager>().As<IAuthorizationService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            //builder.RegisterType<LookupManager>().As<ILookupService>().SingleInstance();
            //builder.RegisterType<EfLookupDal>().As<ILookupDal>().SingleInstance();

            //builder.RegisterType<LookupResourceManager>().As<ILookupResourceService>().SingleInstance();
            //builder.RegisterType<EfLookupResourceDal>().As<ILookupResourceDal>().SingleInstance();


            //// builder.RegisterType<IQueryableRepository<>>().As<EfQueryableRepository>();






            //#region Adress

            //builder.RegisterType<CountryManager>().As<ICountryService>().SingleInstance();
            //builder.RegisterType<EfCountryDal>().As<ICountryDal>().SingleInstance();

            //builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            //builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();

            //builder.RegisterType<TownManager>().As<ITownService>().SingleInstance();
            //builder.RegisterType<EfTownDal>().As<ITownDal>().SingleInstance();

            //builder.RegisterType<DistrictManager>().As<IDistrictService>().SingleInstance();
            //builder.RegisterType<EfDistrictDal>().As<IDistrictDal>().SingleInstance();     

            //builder.RegisterType<NeighborhoodManager>().As<INeighborhoodService>().SingleInstance();
            //builder.RegisterType<EfNeighborhoodDal>().As<INeighborhoodDal>().SingleInstance();

            //#endregion



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
