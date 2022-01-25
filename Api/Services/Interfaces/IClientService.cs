using System.Threading.Tasks;
using VettaProject.Api.Models;

namespace VettaProject.Api.Services.Interfaces
{
    public interface IClientService
    {
        Task Save(Client clientRequest);
    }
}