using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CQRS;
using Domain.CQRS;
using Domain.CQRS.Commands;
using Domain.CQRS.Map;
using Domain.CQRS.Queries;
using Domain.EF;
using Domain.EF.Repositories;
using Domain.EF.UnitOfWork;
using Domain.Entities.Repositories;
using Domain.Entities.UnitOfWork;
using Microsoft.Owin.Security;
using SimpleInjector;
using SimpleInjector.Extensions.LifetimeScoping;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;

namespace WebApp
{
    public class SimpleInjectorConfiguration
    {
        public static void Configure(Container container)
        {
            var scopedLifestyle = Lifestyle.CreateHybrid(() => container.GetCurrentLifetimeScope() != null,
                new LifetimeScopeLifestyle(),
                new WebRequestLifestyle());

            container.Options.DefaultScopedLifestyle = scopedLifestyle;

            container.Register<IAuthenticationManager>(
                () => HttpContext.Current.GetOwinContext().Authentication);

            container.Register<IPasswordManager, PasswordManager>(Lifestyle.Transient);

            container.Register<AuthenticationService, AuthenticationService>(Lifestyle.Transient);

            container.Register<DbContext, CallSystemDbContext>(Lifestyle.Scoped);
            container.Register<IUnitOfWorkFactory, EntityFrameworkUnitOfWorkFactory>(Lifestyle.Transient);

            container.Register(typeof(IRepository<>), typeof(EfRepository<>));

            container.RegisterDecorator(typeof(ICommandHandler<>), typeof(CommandHandlerUnitOfWorkDecorator<>),
                Lifestyle.Transient);

            container
                .Register<IQueryHandler<GetUserRequestsQuery, List<UserRequestDto>>, GetUserRequestsQueryHandler>();
            container
                .Register<ICommandHandler<OperatorCreateUserRequestCommand>, OperatorCreateUserRequestCommandHandler>();
            container
                .Register<ICommandHandler<ExecutorChangeUserRequestStatusCommand>,
                    ExecutorChangeUserRequestStatusCommandHandler>();

            container
                .Register<IQueryHandler<GetUserRequestInfoQuery, UserRequestInfoDto>, GetUserRequestInfoQueryHandler>();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}