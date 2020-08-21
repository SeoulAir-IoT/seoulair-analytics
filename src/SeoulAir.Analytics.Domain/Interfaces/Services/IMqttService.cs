using System;
using System.Threading.Tasks;

namespace SeoulAir.Analytics.Domain.Interfaces.Services
{
    public interface IMqttService<in TDto> : IDisposable
        where TDto : class
    {
        Task OpenConnection();

        Task CloseConnection();

        Task SubscribeToTopic();
    }
}
