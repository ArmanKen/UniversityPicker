using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;
namespace Application.Specialties

{
	public class Edit
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Specialty Specialty { get; set; }
			public Guid SpecialtyId { get; set; }
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
				var specialty = await _context.Specialties.FindAsync(request.SpecialtyId);
				if (specialty == null) return null;
				_mapper.Map(request.Specialty, specialty);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to update the specialty");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}