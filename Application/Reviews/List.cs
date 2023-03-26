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
			public Guid UniversityId { get; set; }
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
				var university = await _context.Universities.FindAsync(request.UniversityId);
				if (university == null) return Result<PagedList<ReviewDto>>.Failure("Failed to load reviews");
				var query = university.Reviews.AsQueryable();
				if (!string.IsNullOrEmpty(request.Params.FacultyId))
					query.Where(x => x.Faculty.Id == Guid.Parse(request.Params.FacultyId));
				if (!string.IsNullOrEmpty(request.Params.GoodRating))
					query.Where(x => x.Rating >= 3);
				else if (!string.IsNullOrEmpty(request.Params.BadRating))
					query.Where(x => x.Rating <= 2);
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