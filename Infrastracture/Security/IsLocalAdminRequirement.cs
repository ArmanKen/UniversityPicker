using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastracture.Security
{
	public class IsLocalAdminRequirement : IAuthorizationRequirement
	{

	}
	public class IsLocalAdminRequirementHandler : AuthorizationHandler<IsGlobalAdminRequirement>
	{
		private readonly DataContext _dbContext;
		private readonly IHttpContextAccessor _httpContentAccessor;
		
		public IsLocalAdminRequirementHandler(DataContext dbContext, IHttpContextAccessor httpContentAccessor)
		{
			_httpContentAccessor = httpContentAccessor;
			_dbContext = dbContext;
		}

		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
			IsGlobalAdminRequirement requirement)
		{
			var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null) return Task.CompletedTask;
			var globalAdministrator = _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId).Result;
			var universityId = Guid.Parse(_httpContentAccessor.HttpContext?.Request.RouteValues
				.SingleOrDefault(x => x.Key == "id").Value?.ToString()!);
			var localAdministrator = _dbContext.UniversityAdministrators.AsNoTracking()
				.SingleOrDefaultAsync(x => x.AppUserId == userId && x.UniversityId == universityId).Result;
			if (localAdministrator != null || globalAdministrator.IsGlobalAdmin) context.Succeed(requirement); 
			return Task.CompletedTask;
		}
	}
}