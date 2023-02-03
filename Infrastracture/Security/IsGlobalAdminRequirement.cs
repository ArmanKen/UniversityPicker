using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastracture.Security
{
	public class IsGlobalAdminRequirement : IAuthorizationRequirement
	{

	}
	public class IsGlobalAdminRequirementHandler : AuthorizationHandler<IsGlobalAdminRequirement>
	{
		private readonly DataContext _dbContext;
		private readonly IHttpContextAccessor _httpContentAccessor;

		public IsGlobalAdminRequirementHandler(DataContext dbContext, IHttpContextAccessor httpContentAccessor)
		{
			_httpContentAccessor = httpContentAccessor;
			_dbContext = dbContext;
		}

		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
			IsGlobalAdminRequirement requirement)
		{
			var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null) return Task.CompletedTask;
			var administrator = _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId).Result;
			if (administrator != null && administrator.IsGlobalAdmin) context.Succeed(requirement);
			return Task.CompletedTask;
		}
	}
}