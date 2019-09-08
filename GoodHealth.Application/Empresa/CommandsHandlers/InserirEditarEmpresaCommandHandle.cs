using AutoMapper;
using GoodHealth.Application.Empresa.Commands;
using GoodHealth.Domain.Empresa.Repositories;
using GoodHealth.Shared.CommandHandle;
using GoodHealth.Shared.Commands;
using GoodHealth.Shared.Handles.Interface;
using GoodHealth.Shared.Interfaces;
using GoodHealth.Shared.Notifications;
using System;
using Model = GoodHealth.Domain.Empresa.Entities;
using System.Threading.Tasks;
using GoodHealth.Shared.Empresa;

namespace GoodHealth.Application.Empresa.CommandsHandlers
{
    public class InserirEditarEmpresaCommandHandle : CommandHandler<InserirEditarEmpresaCommand, CommandResult>
    {
        private readonly IEmpresaWriteRepository empresaWriteRepository;
        private readonly IEmpresaReadRepository empresaReadRepository;

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public InserirEditarEmpresaCommandHandle(IHandler handler,
                                                IDomainNotificationService notificationService,
                                                IEmpresaWriteRepository empresaWriteRepository,
                                                IEmpresaReadRepository empresaReadRepository,
                                                IUnitOfWork unitOfWork,
                                                IMapper mapper) : base(handler, notificationService)
        {
            this.empresaWriteRepository = empresaWriteRepository;
            this.empresaReadRepository = empresaReadRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async override Task<CommandResult> HandleCommand(InserirEditarEmpresaCommand command)
        {
            var empresa = new Model.Empresa(command.Nome);
            if (!command.Id.HasValue)
            {
                empresa.SetId(new Guid());
                await this.empresaWriteRepository.InsertAsync(empresa);
            }
            else
            {
                var empresaEdit = await this.empresaReadRepository.FindByIdAsync(command.Id.Value);
                empresaEdit.Atualizar(empresa.Nome);

                await this.empresaWriteRepository.UpdateAsync(empresaEdit);
                empresa = empresaEdit;
            }

            var dto = mapper.Map<EmpresaDto>(empresa);

            HandleEntity(empresa);

            return new CommandResult(true, dto, "Empresa cadastrada com sucesso.");
        }
        public async override Task PostHandle()
        {
            await unitOfWork.CommitAsync();
        }
    }
}
