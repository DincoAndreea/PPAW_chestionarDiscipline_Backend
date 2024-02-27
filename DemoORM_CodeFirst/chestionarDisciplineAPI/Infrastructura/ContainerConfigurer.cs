using Autofac;
using Autofac.Integration.WebApi;
using NivelDataAccess.anidestudiuDAL;
using NivelDataAccess.chestionareDAL;
using NivelDataAccess.cicluldestudiiDAL;
using NivelDataAccess.disciplineDAL;
using NivelDataAccess.intrebariDAL;
using NivelDataAccess.programestudiuDAL;
using NivelDataAccess.raspunsurichestionarDAL;
using NivelDataAccess.tipuriactivitatiDAL;
using NivelServicii;
using NivelServicii.activitatiNeevaluate;
using NivelServicii.anidestudiuNS;
using NivelServicii.cache;
using NivelServicii.chestionareNS;
using NivelServicii.cicluldestudiiNS;
using NivelServicii.disciplineNS;
using NivelServicii.generareIntrebari;
using NivelServicii.intrebariNS;
using NivelServicii.programestudiuNS;
using NivelServicii.raspunsurichestionarNS;
using NivelServicii.tipuriactivitatiNS;
using Repository_CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace chestionarDisciplineAPI.Infrastructura
{
    public class ContainerConfigurer
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ContextDb>().As<IContextDB>();
            builder.RegisterType<anidestudiuServicii>().As<IanidestudiuServicii>();
            builder.RegisterType<chestionareServicii>().As<IchestionareServicii>();
            builder.RegisterType<cicluldestudiiServicii>().As<IcicluldestudiiServicii>();
            builder.RegisterType<disciplineServicii>().As<IdisciplineServicii>();
            builder.RegisterType<programestudiuServicii>().As<IprogramestudiuServicii>();
            builder.RegisterType<raspunsurichestionarServicii>().As<IraspunsurichestionarServicii>();
            builder.RegisterType<tipuriactivitatiServicii>().As<ItipuriactivitatiServicii>();
            builder.RegisterType<intrebariServicii>().As<IintrebariServicii>();

            builder.RegisterType<activitatiNeevaluateServicii>().As<IactivitatiNeevaluateServicii>();
            builder.RegisterType<generareIntrebariServicii>().As<IgenerareIntrebariServicii>();

            builder.RegisterType<anidestudiuAccesor>().As<IanidestudiuAccesor>();
            builder.RegisterType<chestionareAccesor>().As<IchestionareAccesor>();
            builder.RegisterType<cicluldestudiiAccesor>().As<IcicluldestudiiAccesor>();
            builder.RegisterType<disciplineAccesor>().As<IdisciplineAccesor>();
            builder.RegisterType<programestudiuAccesor>().As<IprogramestudiuAccesor>();
            builder.RegisterType<raspunsurichestionarAccesor>().As<IraspunsurichestionarAccesor>();
            builder.RegisterType<tipuriactivitatiAccesor>().As<ItipuriactivitatiAccesor>();
            builder.RegisterType<intrebariAccesor>().As<IintrebariAccesor>();

            builder.RegisterType<MemoryCacheService>().As<ICache>();

            var config = GlobalConfiguration.Configuration;

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
