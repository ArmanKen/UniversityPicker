using Application.Core;
using Application.Interfaces;
using Application.Universities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
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
					.ProjectTo<UniversityDto>(_mapper.ConfigurationProvider)
					.FirstOrDefaultAsync(x => x.Id == request.Id);
				return Result<UniversityDto>.Success(university!);
			}
		}
	}
}