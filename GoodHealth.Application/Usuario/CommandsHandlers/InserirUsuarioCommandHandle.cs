using AutoMapper;
using GoodHealth.Application.Usuario.Commands;
using GoodHealth.Domain.Usuario.Repositories;
using GoodHealth.Shared.CommandHandle;
using GoodHealth.Shared.Commands;
using GoodHealth.Shared.Handles.Interface;
using GoodHealth.Shared.Interfaces;
using GoodHealth.Shared.Notifications;
using System;
using Model = GoodHealth.Domain.Usuario.Entities;
using System.Threading.Tasks;
using GoodHealth.Shared.Usuario;

namespace GoodHealth.Application.Usuario.CommandsHandlers
{
    public class InserirUsuarioCommandHandle : CommandHandler<InserirEditarUsuarioCommand, CommandResult>
    {
        private readonly IUsuarioWriteRepository usuarioWriteRepository;
        private readonly IUsuarioReadRepository usuarioReadRepository;

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public InserirUsuarioCommandHandle( IHandler handler, 
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

        public async override Task<CommandResult> HandleCommand(InserirEditarUsuarioCommand command)
        {
            command.Telefone = command.Telefone ?? "";
            var usuario = new Model.Usuario(command.Nome, command.Email, command.Telefone);
            if (!command.Id.HasValue)
            {
                usuario.SetId(new Guid());
                await this.usuarioWriteRepository.InsertAsync(usuario);
            }
            else
            {
                var usuarioEdit = await this.usuarioReadRepository.FindByIdAsync(command.Id.Value);
                usuarioEdit.Atualizar(usuario.Nome, usuario.Email, usuario.Telefone);

                await this.usuarioWriteRepository.UpdateAsync(usuarioEdit);
                usuario = usuarioEdit;
            }

            var dto = mapper.Map<UsuarioDto>(usuario);

            HandleEntity(usuario);

            return new CommandResult(true, dto, "Usuário cadastrado com sucesso.");
        }
        public async override Task PostHandle()
        {
            await unitOfWork.CommitAsync();
        }
    }
    
}
