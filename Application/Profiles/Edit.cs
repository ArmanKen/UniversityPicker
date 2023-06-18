using Application.Core;
using Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Profiles
{
	public class Edit
	{
		public class Command : IRequest<Result<Unit>>
		{
			public ProfileFormValues Profile { get; set; }
		}

		public class CommandValidator : AbstractValidator<Command>
		{
			public CommandValidator()
			{
				RuleFor(x => x.Profile.FullName).NotEmpty();
			}
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly DataContext _context;
			private readonly IUserAccessor _userAccessor;

			public Handler(DataContext context, IUserAccessor userAccessor)
			{
				_userAccessor = userAccessor;
				_context = context;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
				if (user == null) return Result<Unit>.Failure("Failed to update profile");
				user.FullName = request.Profile.FullName;
				user.Bio = request.Profile.Bio;
				user.CurrentStatus = await _context.CurrentStatuses.FindAsync(request.Profile.CurrentStatus);
				user.SpecialtyBase = await _context.SpecialtyBases.FindAsync(request.Profile.SpecialtyBase);
				user.Degree = await _context.Degrees.FindAsync(request.Profile.Degree);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to update profile");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}