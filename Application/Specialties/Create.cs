using Application.Core;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Specialties
{
	public class Create
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Guid InstitutionId { get; set; }
			public SpecialtyDto Specialty { get; set; }
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
				// var institution = await _context.Institutions.FindAsync(request.InstitutionId);
				// if (institution == null) return Result<Unit>.Failure("Failed to create specialty");
				// var specialty = _mapper.Map<Specialty>(request.Specialty);
				// specialty.SpecialtyBase = await _context.SpecialtyBases.FindAsync(request.Specialty.SpecialtyBaseId);
				// if (specialty.SpecialtyBase == null) return Result<Unit>.Failure("Failed to create specialty");
				// institution.Specialties.Add(specialty);
				// var result = await _context.SaveChangesAsync() > 0;
				// if (!result) return Result<Unit>.Failure("Failed to create specialty");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}