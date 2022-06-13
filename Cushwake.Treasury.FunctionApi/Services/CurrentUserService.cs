
using System.Security.Claims;
using Cushwake.Treasury.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;


namespace Cushwake.Treasury.FunctionApi.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
}
