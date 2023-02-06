using Application.Core;
using MediatR;
using Persistence;

namespace Application.Disciplines
{
	public class Delete
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Guid Id { get; set; }
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
				var discipline = await _context.Disciplines.FindAsync(request.Id);
				if (discipline == null) return null;
				_context.Disciplines.Remove(discipline);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to delete the discipline");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}