using AutoMapper;
using GoodHealth.Application.Empresa.Commands;
using GoodHealth.Domain.Empresa.Repositories;
using GoodHealth.Shared.CommandHandle;
using GoodHealth.Shared.Commands;
using GoodHealth.Shared.Handles.Interface;
using GoodHealth.Shared.Interfaces;
using GoodHealth.Shared.Notifications;
using System.Threading.Tasks;

namespace GoodHealth.Application.Empresa.CommandsHandlers
{
    public class ExcluirEmpresaCommandHandle : CommandHandler<ExcluirEmpresaCommand, CommandResult>
    {
        private readonly IEmpresaReadRepository empresaReadRepository;

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ExcluirEmpresaCommandHandle(IHandler handler, 
                                            IDomainNotificationService notificationService, 
                                            IEmpresaReadRepository empresaReadRepository,
                                            IUnitOfWork unitOfWork,
                                            IMapper mapper) : base(handler, notificationService)
        {
            this.empresaReadRepository = empresaReadRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public override async Task<CommandResult> HandleCommand(ExcluirEmpresaCommand command)
        {
            var empresa = await this.empresaReadRepository.FindByIdAsync(command.Id);
            if (empresa == null)
            {
                AddNotification("Usuario", "Usuário não encontrado");
                return new CommandResult(false, null, "Usuário não encontrado.");
            }

            empresa.Delete();
            await this.unitOfWork.CommitAsync();
            return new CommandResult(true, true, "Usuário excluído com sucesso.");
        }
    }
}
