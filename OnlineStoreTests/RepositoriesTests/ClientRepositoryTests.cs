using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Commands.Client.Create;
using OnlineStrore.Logic.Repositories.Interfaces;
using FluentAssertions;

namespace OnlineStoreTests.RepositoriesTests
{
    public class ClientRepositoryTests
    {
        private readonly IContext context;
        private readonly IClientRepository clientRepository;
        public ClientRepositoryTests(IContext context, IClientRepository clientRepository)
        {
            this.context = context;
            this.clientRepository = clientRepository;
        }

        [Fact]
        public async void ClientRepository_CreateClientAsync_ReturnJwtToken()
        {
            var request = new CreateClientCommand()
            {
                Name = "test",
                Email = "test@mail.com",
                Password = "password",
                ConnfigurePasswrod = "password",
                PhoneNubmer = "892200000000"
            };

            var result = await clientRepository.CreateClientAsync(context, request, new CancellationToken());

            result.Should().BeOfType<string>();
            result.Should().NotBeEmpty();
        }
    }
}
