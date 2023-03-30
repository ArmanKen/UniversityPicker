using Application.Core;
using MediatR;
using Persistence;

namespace Application.Universities
{
	public class Delete
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Guid UniversityId { get; set; }
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
				if (university == null) return null;
				_context.Universities.Remove(university);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to delete the university");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}