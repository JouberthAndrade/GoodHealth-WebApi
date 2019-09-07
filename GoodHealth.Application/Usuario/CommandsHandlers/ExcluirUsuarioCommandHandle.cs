using AutoMapper;
using GoodHealth.Application.Usuario.Commands;
using GoodHealth.Domain.Usuario.Repositories;
using GoodHealth.Shared.CommandHandle;
using GoodHealth.Shared.Commands;
using GoodHealth.Shared.Handles.Interface;
using GoodHealth.Shared.Interfaces;
using GoodHealth.Shared.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Application.Usuario.CommandsHandlers
{
    public class ExcluirUsuarioCommandHandle : CommandHandler<ExcluirUsuarioCommand, CommandResult>
    {
        private readonly IUsuarioWriteRepository usuarioWriteRepository;
        private readonly IUsuarioReadRepository usuarioReadRepository;

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ExcluirUsuarioCommandHandle(IHandler handler,
                                                IDomainNotificationService notificationService,
                                                IUsuarioWriteRepository usuarioWriteRepository,
                                                IUsuarioReadRepository usuarioReadRepository,
                                                IUnitOfWork unitOfWork,
                                                IMapper mapper) : base(handler, notificationService)
        {
            this.usuarioWriteRepository = usuarioWriteRepository;
            this.usuarioReadRepository = usuarioReadRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public override async Task<CommandResult> HandleCommand(ExcluirUsuarioCommand command)
        {
            var usuario = await this.usuarioReadRepository.FindByIdAsync(command.Id);
            if (usuario == null) { 
                AddNotification("Usuario", "Usuário não encontrado");
                return new CommandResult(false, null, "Usuário não encontrado.");
            }

            usuario.Delete();
            await this.unitOfWork.CommitAsync();
            return new CommandResult(true, true, "Usuário excluído com sucesso.");
        }
    }
}
