using Application.Core;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.DropdownLists
{
	public class DegreeList
	{
		public class Query : IRequest<Result<List<Degree>>>
		{
			public int RegionId { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<List<Degree>>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<List<Degree>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var degrees = _context.Degrees
					.ProjectTo<Degree>(_mapper.ConfigurationProvider);
				return Result<List<Degree>>.Success(await degrees.ToListAsync());
			}
		}
	}
}