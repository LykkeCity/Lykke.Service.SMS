using System.Threading.Tasks;
using Lykke.Job.SMS.Core.Services;

namespace Lykke.Job.SMS.Services
{
    // NOTE: This is job service class example
    public class MyFooService : IMyFooService
    {
        public Task FooAsync()
        {
            return Task.FromResult(0);
        }
    }
}