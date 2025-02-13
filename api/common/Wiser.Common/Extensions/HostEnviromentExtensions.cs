using Microsoft.Extensions.Hosting;

namespace Wiser.Common.Extensions
{
    public static class HostEnvironmentExtensions
    {
        private const string NSwag = "NSwag";

        public static bool IsNSwag(this IHostEnvironment hostEnvironment)
        {
            return hostEnvironment.IsEnvironment(NSwag);
        }
    }
}
