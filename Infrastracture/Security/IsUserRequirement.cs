using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastracture.Security
{
	public class IsUserRequirement : IAuthorizationRequirement
	{

	}
	public class IsUserRequirementHandler : AuthorizationHandler<IsGlobalAdminRequirement>
	{
		private readonly DataContext _dbContext;
		private readonly IHttpContextAccessor _httpContentAccessor;
		
		public IsUserRequirementHandler(DataContext dbContext, IHttpContextAccessor httpContentAccessor)
		{
			_httpContentAccessor = httpContentAccessor;
			_dbContext = dbContext;
		}

		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
			IsGlobalAdminRequirement requirement)
		{
			var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null) return Task.CompletedTask;
			context.Succeed(requirement);
			return Task.CompletedTask;
		}
	}
}