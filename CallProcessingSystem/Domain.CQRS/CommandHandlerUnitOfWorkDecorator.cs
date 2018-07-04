using System;
using CQRS;
using Domain.Entities.UnitOfWork;

namespace Domain.CQRS
{
    public class CommandHandlerUnitOfWorkDecorator<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _decorated;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public CommandHandlerUnitOfWorkDecorator(IUnitOfWorkFactory unitOfWorkFactory,
            ICommandHandler<TCommand> decorated)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _decorated = decorated;
        }

        public void Handle(TCommand message)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                try
                {
                    _decorated.Handle(message);
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                }

                uow.Commit();
            }
        }
    }
}