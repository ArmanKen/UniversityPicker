using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Specialties
{
	public class Create
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Guid UniversityId { get; set; }
			public Specialty Specialty { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly DataContext _context;

			public Handler(DataContext context)
			{
				_context = context;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				var university = await _context.Universities.FindAsync(request.UniversityId);
				if (university == null) return Result<Unit>.Failure("Failed to create specialty");
				university.Specialties.Add(request.Specialty);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to create specialty");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}