using Autofac;
using Autofac.Integration.WebApi;
using NivelServicii;
using NivelServicii.activitatiNeevaluate;
using NivelServicii.anidestudiuNS;
using NivelServicii.chestionareNS;
using NivelServicii.cicluldestudiiNS;
using NivelServicii.disciplineNS;
using NivelServicii.generareIntrebari;
using NivelServicii.programestudiuNS;
using NivelServicii.raspunsurichestionarNS;
using NivelServicii.tipuriactivitatiNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace chestionarDisciplineMVC.Infrastructura
{
    public class ContainerConfigurer
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<anidestudiuServicii>().As<IanidestudiuServicii>();
            builder.RegisterType<chestionareServicii>().As<IchestionareServicii>();
            builder.RegisterType<cicluldestudiiServicii>().As<IcicluldestudiiServicii>();
            builder.RegisterType<disciplineServicii>().As<IdisciplineServicii>();
            builder.RegisterType<programestudiuServicii>().As<IprogramestudiuServicii>();
            builder.RegisterType<raspunsurichestionarServicii>().As<IraspunsurichestionarServicii>();
            builder.RegisterType<tipuriactivitatiServicii>().As<ItipuriactivitatiServicii>();

            builder.RegisterType<activitatiNeevaluateServicii>().As<IactivitatiNeevaluateServicii>();
            builder.RegisterType<generareIntrebariServicii>().As<IgenerareIntrebariServicii>();

            var config = GlobalConfiguration.Configuration;

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
