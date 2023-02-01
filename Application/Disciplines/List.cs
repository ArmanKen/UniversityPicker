using Application.Core;
using Application.Region;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Disciplines
{
	public class List
	{
		public class Query : IRequest<Result<List<DisciplineDto>>> { }

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
				var disciplines = _context.Disciplines
					.ProjectTo<DisciplineDto>(_mapper.ConfigurationProvider);
				return Result<List<DisciplineDto>>.Success(await disciplines.ToListAsync());
			}
		}
	}
}