using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Repositories.Interfaces;

namespace OnlineStrore.Commands.Product.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private IContext context;
        private IProductRepository productRepository;

        public CreateProductCommandHandler(IContext _context, IProductRepository _productRepository)
            => (context, productRepository) = (_context, _productRepository);

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Guid id = await productRepository.CreateProductAsync(context, request, cancellationToken);
            return id;
        }
    }
}
