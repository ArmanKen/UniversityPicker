using Application.Core;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Universities
{
	public class Create
	{
		public class Command : IRequest<Result<Unit>>
		{
			public University University { get; set; }
		}

		public class CommandValidator : AbstractValidator<Command>
		{
			public CommandValidator()
			{
				RuleFor(x => x.University).SetValidator(new UniversityValidator());
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
				_context.Universities.Add(request.University);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to create university");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}