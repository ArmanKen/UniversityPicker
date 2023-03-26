using Application.Core;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.DropdownLists
{
	public class RegionsList
	{
		public class Query : IRequest<Result<List<RegionDto>>>
		{
			public int RegionId { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<List<RegionDto>>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<List<RegionDto>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var regions = _context.Regions
					.ProjectTo<RegionDto>(_mapper.ConfigurationProvider);
				return Result<List<RegionDto>>.Success(await regions.ToListAsync());
			}
		}
	}
}