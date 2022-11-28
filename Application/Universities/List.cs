using Application.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Universities
{
	public class List
	{
		public class Query : IRequest<Result<List<UniversityDto>>> { }

		public class Handler : IRequestHandler<Query, Result<List<UniversityDto>>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<List<UniversityDto>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var universities = await _context.Universities
				.Include(u => u.Specialties)
				.ThenInclude(s => s.Specialty)
				.ToListAsync();
				var universitiesToReturn = _mapper.Map<List<UniversityDto>>(universities);
				return Result<List<UniversityDto>>.Success(universitiesToReturn);
			}
		}
	}
}