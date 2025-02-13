namespace Wiser.Identity.Api.Controllers
{
    internal static class ApiEndpoints
    {
        public static WebApplication UseApiEndpoints(this WebApplication webApplication)
        {
            webApplication.AddUserEndpoints();

            return webApplication;
        }
    }
}
