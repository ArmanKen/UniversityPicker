using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Disciplines
{
	public class Edit
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Discipline Discipline { get; set; }
			public int Id { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				var discipline = await _context.Disciplines.FindAsync(request.Id);
				if (discipline == null) return null;
				_mapper.Map(request.Discipline, discipline);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to update the specialty");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}