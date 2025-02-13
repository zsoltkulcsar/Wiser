namespace Wiser.Common.Security
{
    public interface IIdentityContext
    {
        Guid UserId { get; }
        Guid CompanyId { get; }
    }
}
