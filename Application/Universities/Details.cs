using Application.Core;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Universities
{
	public class Details
	{
		public class Query : IRequest<Result<UniversityDto>>
		{
			public Guid Id { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<UniversityDto>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<UniversityDto>> Handle(Query request, CancellationToken cancellationToken)
			{
				var university = await _context.Universities
					.ProjectTo<UniversityDto>(_mapper.ConfigurationProvider)
					.FirstOrDefaultAsync(x => x.Id == request.Id);
				if (university == null) return null;
				return Result<UniversityDto>.Success(university);
			}
		}
	}
}