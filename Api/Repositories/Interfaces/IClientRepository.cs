using System.Threading.Tasks;
using VettaProject.Api.Models;

namespace Api.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task Save(Client clientPerson);
    }
}