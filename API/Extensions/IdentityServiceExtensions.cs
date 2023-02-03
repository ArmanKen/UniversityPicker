using System.Text;
using API.Services;
using Domain;
using Infrastracture.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Persistence;

namespace API.Extensions
{
	public static class IdentityServiceExtensions
	{
		public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
		{
			services.AddIdentityCore<AppUser>(opt =>
			{
				opt.Password.RequireNonAlphanumeric = false;
			})
			.AddEntityFrameworkStores<DataContext>()
			.AddSignInManager<SignInManager<AppUser>>();

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
			{
				opt.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = key,
					ValidateIssuer = false,
					ValidateAudience = false
				};
				opt.Events = new JwtBearerEvents
				{
					OnMessageReceived = context =>
					{
						var accessToken = context.Request.Query["access_token"];
						var path = context.HttpContext.Request.Path;
						if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/chat")))
						{
							context.Token = accessToken;
						}
						return Task.CompletedTask;
					}
				};
			});
			services.AddAuthorization(opt =>
			{
				opt.AddPolicy("IsGlobalAdmin", policy =>
				{
					policy.Requirements.Add(new IsGlobalAdminRequirement());
				});
				opt.AddPolicy("IsLocalAdmin", policy =>
				{
					policy.Requirements.Add(new IsLocalAdminRequirement());
				});
			});
			services.AddTransient<IAuthorizationHandler, IsGlobalAdminRequirementHandler>();
			services.AddTransient<IAuthorizationHandler, IsLocalAdminRequirementHandler>();
			services.AddScoped<TokenService>();
			return services;
		}
	}
}