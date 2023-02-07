using Application.Core;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Disciplines
{
	public class List
	{
		public class Query : IRequest<Result<List<DisciplineDto>>>
		{
			public Guid SpecialtyId { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<List<DisciplineDto>>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<List<DisciplineDto>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var specialty = await _context.Specialties.FindAsync(request.SpecialtyId);
				if (specialty == null) return null;
				var disciplines = _mapper.Map<List<DisciplineDto>>(specialty.Disciplines);
				if (disciplines == null) return null;
				return Result<List<DisciplineDto>>.Success(disciplines);
			}
		}
	}
}