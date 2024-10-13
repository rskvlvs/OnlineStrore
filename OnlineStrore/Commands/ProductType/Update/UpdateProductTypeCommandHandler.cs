using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Repositories.Interfaces;

namespace OnlineStrore.Commands.ProductType.Update
{
    public class UpdateProductTypeCommandHandler : IRequestHandler <UpdateProductTypeCommand, Guid>
    {
        private IProductTypeRepository productTypeRepository;
        private IContext context;

        public UpdateProductTypeCommandHandler(IProductTypeRepository productTypeRepository, IContext context)
        {
            this.productTypeRepository = productTypeRepository;
            this.context = context;
        }

        public async Task<Guid> Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            Guid id = await productTypeRepository.UpdateProductTypeAsync(context, request, cancellationToken);
            return id;
        }
    }
}
