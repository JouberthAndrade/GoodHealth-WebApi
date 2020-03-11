using AutoMapper;
using GoodHealth.Application.Produto.Commands;
using GoodHealth.Domain.Produto.Repositories;
using GoodHealth.Shared.CommandHandle;
using GoodHealth.Shared.Commands;
using GoodHealth.Shared.Handles.Interface;
using GoodHealth.Shared.Interfaces;
using GoodHealth.Shared.Notifications;
using System.Threading.Tasks;

namespace GoodHealth.Application.Produto.CommandsHandlers
{
    public class ExcluirProdutoCommandHandler : CommandHandler<ExcluirProdutoCommand, CommandResult>
    {

        private readonly IProdutoReadRepository produtoReadRepository;

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ExcluirProdutoCommandHandler(
            IHandler handler, 
            IDomainNotificationService notificationService,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IProdutoReadRepository produtoReadRepository) : base(handler, notificationService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.produtoReadRepository = produtoReadRepository;
        }

        public async override Task<CommandResult> HandleCommand(ExcluirProdutoCommand command)
        {
            var produto = await this.produtoReadRepository.FindByIdAsync(command.Id);
            if (produto == null)
            {
                AddNotification("Produto", "Produto não encontrado");
                return new CommandResult(false, null, "Produto não encontrado.");
            }

            produto.Delete();
            await this.unitOfWork.CommitAsync();
            return new CommandResult(true, true, "Produto excluído com sucesso.");
        }
    }
}
