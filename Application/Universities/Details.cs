using Application.Core;
using Application.DTOs;
using Application.Interfaces;
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
			public Guid UniversityId { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<UniversityDto>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;
			private readonly IUserAccessor _userAccessor;

			public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
			{
				_userAccessor = userAccessor;
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<UniversityDto>> Handle(Query request, CancellationToken cancellationToken)
			{
				var university = await _context.Universities
					.ProjectTo<UniversityDto>(_mapper.ConfigurationProvider, new { username = _userAccessor.GetUsername() })
					.FirstOrDefaultAsync(x => x.Id == request.UniversityId);
				if (university == null) return null;
				return Result<UniversityDto>.Success(university);
			}
		}
	}
}