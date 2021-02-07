using System.Threading.Tasks;

namespace SeoulAir.Analytics.Domain.Interfaces.Services
{
    public interface ICommandService
    {
        Task<string> ExecuteCommandAsync(string commandName, params string[] parameters);
    }
}
