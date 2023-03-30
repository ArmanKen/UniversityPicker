using Application.Core;
using MediatR;
using Persistence;

namespace Application.Specialties
{
	public class Delete
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Guid SpecialtyId { get; set; }
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
				var specialty = await _context.Specialties.FindAsync(request.SpecialtyId);
				if (specialty == null) return null!;
				_context.Specialties.Remove(specialty);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to delete the specialty");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}