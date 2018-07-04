using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CQRS;
using Domain.CQRS;
using Domain.CQRS.Commands;
using Domain.CQRS.Map;
using Domain.CQRS.Queries;
using Domain.Entities;
using Domain.Entities.Repositories;
using Microsoft.AspNet.Identity;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICommandHandler<ExecutorChangeUserRequestStatusCommand>
            _executorChangeUserRequestCommandHandler;

        private readonly IRepository<Executor> _executorRepository;
        private readonly IQueryHandler<GetUserRequestInfoQuery, UserRequestInfoDto> _getUserRequestInfoQueryHandler;

        private readonly IQueryHandler<GetUserRequestsQuery, List<UserRequestDto>> _getuserRequestsQueryHandler;
        private readonly ICommandHandler<OperatorCreateUserRequestCommand> _operatorCreateUserRequestCommandHandler;
        private readonly IRepository<RequestTheme> _themeRepository;

        public HomeController(
            ICommandHandler<ExecutorChangeUserRequestStatusCommand> executorChangeUserRequestCommandHandler,
            IQueryHandler<GetUserRequestsQuery, List<UserRequestDto>> getuserRequestsQueryHandler,
            ICommandHandler<OperatorCreateUserRequestCommand> operatorCreateUserRequestCommandHandler,
            IRepository<RequestTheme> themeRepository, IRepository<Executor> executorRepository,
            IQueryHandler<GetUserRequestInfoQuery, UserRequestInfoDto> getUserRequestInfoQueryHandler)
        {
            _executorChangeUserRequestCommandHandler = executorChangeUserRequestCommandHandler;
            _getuserRequestsQueryHandler = getuserRequestsQueryHandler;
            _operatorCreateUserRequestCommandHandler = operatorCreateUserRequestCommandHandler;
            _themeRepository = themeRepository;
            _executorRepository = executorRepository;
            _getUserRequestInfoQueryHandler = getUserRequestInfoQueryHandler;
        }

        [Route("")]
        public ActionResult Index(int page = 1, int take = 25)
        {
            var opId = User.IsOperator() ? User.Identity.GetUserId<long>() : (long?) null;
            var execId = User.IsExecutor() ? User.Identity.GetUserId<long>() : (long?) null;

            var query = new GetUserRequestsQuery(page, take, 1, opId, execId);

            var model = new IndexViewModel
            {
                Items = _getuserRequestsQueryHandler.Handle(query),
                PageInfo = new PageInfo
                {
                    Page = page,
                    Take = take,
                    TotalItems = query.AllCount
                }
            };

            return View(model);
        }

        [Route("create")]
        public ActionResult Create()
        {
            var items = _themeRepository.Get().ToList();
            var exec = _executorRepository.Get().ToList();
            var model = new CreateUserRequestViewModel
            {
                Themes = items.Select(x => new SelectListItem {Text = x.Title, Value = x.Id.ToString()}),
                Excecutors = exec.Select(x => new SelectListItem {Text = x.Name, Value = x.Id.ToString()})
            };

            return View(model);
        }

        [Route("create")]
        [HttpPost]
        public ActionResult Create(CreateUserRequestViewModel model)
        {
            if (User.IsOperator())
                _operatorCreateUserRequestCommandHandler.Handle(
                    new OperatorCreateUserRequestCommand
                    {
                        OperatorId = User.Identity.GetUserId<long>(),
                        ExcecutorId = model.ExcecutorId,
                        ThemeId = model.ThemeId,
                        ComplaintMessage = model.ComplaintMessage,
                        Phone = model.Phone,
                        UserName = model.UserName
                    });

            return RedirectToAction("Index");
        }

        [Route("info")]
        [HttpGet]
        public ActionResult Info(long id)
        {
            var request = _getUserRequestInfoQueryHandler.Handle(new GetUserRequestInfoQuery(id));

            if (request == null)
                return RedirectToAction("Index");

            return View(request);
        }

        [Route("edit")]
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var request = _getUserRequestInfoQueryHandler.Handle(new GetUserRequestInfoQuery(id));

            if (request == null)
                return RedirectToAction("Index");

            return View(request);
        }

        [Route("edit")]
        [HttpPost]
        public ActionResult Edit(ChangeRequestStatusViewModel model)
        {
            if (User.IsExecutor() && model != null)
                _executorChangeUserRequestCommandHandler.Handle(
                    new ExecutorChangeUserRequestStatusCommand
                    {
                        ExecutorId = User.Identity.GetUserId<long>(),
                        RequestId = model.Id,
                        Status = model.Status,
                        Comment = model.Comment
                    });

            return RedirectToAction("Index");
        }
    }
}