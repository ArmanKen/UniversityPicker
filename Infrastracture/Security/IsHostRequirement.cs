using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastracture.Security
{
	public class IsHostRequirement : IAuthorizationRequirement
	{

	}
	public class IsHostReqiurementHandler : AuthorizationHandler<IsHostRequirement>
	{
		private readonly DataContext _dbContext;
		private readonly IHttpContextAccessor _httpContentAccessor;
		public IsHostReqiurementHandler(DataContext dbContext, IHttpContextAccessor httpContentAccessor)
		{
			_httpContentAccessor = httpContentAccessor;
			_dbContext = dbContext;
		}

		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
			IsHostRequirement requirement)
		{
			var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null) return Task.CompletedTask;
			var universityId = Guid.Parse(_httpContentAccessor.HttpContext?.Request.RouteValues
				.SingleOrDefault(x => x.Key == "id").Value?.ToString()!);
			var administrator = _dbContext.UniversityAdministrators.AsNoTracking()
				.SingleOrDefaultAsync(x => x.AppUserId == userId && x.UniversityId == universityId).Result;
			if (administrator == null) return Task.CompletedTask;
			else context.Succeed(requirement);
			return Task.CompletedTask;
		}
	}
}