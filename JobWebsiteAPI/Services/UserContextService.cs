using System.Security.Claims;

namespace JobWebsiteAPI.Services
{
    public interface IUserContextService
    {
        ClaimsPrincipal User { get; }
    }
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClaimsPrincipal User => _httpContextAccessor.HttpContext.User;
        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

    }
}
