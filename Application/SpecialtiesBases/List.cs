using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.SpecialtiesBases
{
	public class List
	{
		public class Query : IRequest<Result<List<SpecialtyBaseDto>>> { }

		public class Handler : IRequestHandler<Query, Result<List<SpecialtyBaseDto>>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<List<SpecialtyBaseDto>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var specialtyBases = _context.SpecialtyBases
					.ProjectTo<SpecialtyBaseDto>(_mapper.ConfigurationProvider);
				return Result<List<SpecialtyBaseDto>>.Success(await specialtyBases.ToListAsync());
			}
		}
	}
}