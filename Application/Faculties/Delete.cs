using Application.Core;
using MediatR;
using Persistence;

namespace Application.Faculties
{
	public class Delete
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Guid FacultyId { get; set; }
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
				var faculty = await _context.Faculties.FindAsync(request.FacultyId);
				if (faculty == null) return null;
				_context.Faculties.Remove(faculty);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to delete the faculty");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}