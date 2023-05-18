using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.HigherEducationFacilities
{
	public class Details
	{
		public class Query : IRequest<Result<HigherEducationFacilityDto>>
		{
			public Guid HigherEducationFacilityId { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<HigherEducationFacilityDto>>
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

			public async Task<Result<HigherEducationFacilityDto>> Handle(Query request, CancellationToken cancellationToken)
			{
				var higherEducationFacility = await _context.HigherEducationFacilities
					.ProjectTo<HigherEducationFacilityDto>(_mapper.ConfigurationProvider, new { username = _userAccessor.GetUsername() })
					.FirstOrDefaultAsync(x => x.Id == request.HigherEducationFacilityId);
				if (higherEducationFacility == null) return null;
				return Result<HigherEducationFacilityDto>.Success(higherEducationFacility);
			}
		}
	}
}