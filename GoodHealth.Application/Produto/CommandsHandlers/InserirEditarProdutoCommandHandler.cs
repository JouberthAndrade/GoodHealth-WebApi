using AutoMapper;
using GoodHealth.Shared.CommandHandle;
using GoodHealth.Shared.Commands;
using GoodHealth.Shared.Handles.Interface;
using GoodHealth.Shared.Interfaces;
using GoodHealth.Shared.Notifications;
using System;
using Model = GoodHealth.Domain.Produto.Entities;
using System.Threading.Tasks;
using GoodHealth.Application.Produto.Commands;
using GoodHealth.Domain.Produto.Repositories;
using GoodHealth.Shared.Produto;

namespace GoodHealth.Application.Produto.CommandsHandlers
{
    public class InserirEditarProdutoCommandHandler : CommandHandler<InserirEditarProdutoCommand, CommandResult>
    {

        private readonly IProdutoWriteRepository produtoWriteRepository;
        private readonly IProdutoReadRepository produtoReadRepository;

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public InserirEditarProdutoCommandHandler(IHandler handler,
            IDomainNotificationService notificationService,
            IProdutoWriteRepository produtoWriteRepository, 
            IProdutoReadRepository produtoReadRepository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper) : base(handler, notificationService)
        {
            this.produtoWriteRepository = produtoWriteRepository;
            this.produtoReadRepository = produtoReadRepository ;
            this.unitOfWork = unitOfWork ;
            this.mapper = mapper;
        }

        public async override Task<CommandResult> HandleCommand(InserirEditarProdutoCommand command)
        {
            var produto = new Model.Produto(command.Descricao, command.Valor);
            if (!command.Id.HasValue)
            {
                produto.SetId(new Guid());
                await this.produtoWriteRepository.InsertAsync(produto);
            }
            else
            {
                /*
                var produtoEdit = await this.produtoWriteRepository.FindByIdAsync(command.Id.Value);
                produtoEdit.Atualizar(produto.Nome);

                await this.produtoWriteRepository.UpdateAsync(produtoEdit);
                produto = produtoEdit;*/
            }

            var dto = mapper.Map<ProdutoDto>(produto);

            HandleEntity(produto);

            return new CommandResult(true, dto, "Produto cadastrada com sucesso.");
        }
        public async override Task PostHandle()
        {
            await unitOfWork.CommitAsync();
        }
    }
}
