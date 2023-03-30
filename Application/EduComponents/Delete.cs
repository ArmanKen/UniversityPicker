using Application.Core;
using MediatR;
using Persistence;

namespace Application.EduComponents
{
	public class Delete
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Guid EduComponentId { get; set; }
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
				var educationComponent = await _context.EduComponents.FindAsync(request.EduComponentId);
				if (educationComponent == null) return null;
				_context.EduComponents.Remove(educationComponent);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to delete the Education Component");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}