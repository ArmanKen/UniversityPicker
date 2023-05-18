using Application.Core;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Reviews
{
	public class List
	{

		public class Query : IRequest<Result<PagedList<ReviewDto>>>
		{
			public Guid HigherEducationFacilityId { get; set; }
			public ReviewParams Params { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<PagedList<ReviewDto>>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<PagedList<ReviewDto>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var higherEducationFacility = await _context.HigherEducationFacilities.FindAsync(request.HigherEducationFacilityId);
				if (higherEducationFacility == null) return null;
				var query = higherEducationFacility.Reviews.AsQueryable();
				return Result<PagedList<ReviewDto>>.Success(
					PagedList<ReviewDto>.Create(
						query
							.ProjectTo<ReviewDto>(_mapper.ConfigurationProvider)
							.OrderBy(x => x.CreatedAt),
					request.Params.PageNumber, request.Params.PageSize));
			}
		}
	}
}