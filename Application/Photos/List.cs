using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Photos
{
	public class List
	{
		public class Query : IRequest<Result<PagedList<Photo>>>
		{
			public Guid HigherEducationFacilityId { get; set; }
			public PhotoPagingParams Params { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<PagedList<Photo>>>
		{
			private readonly DataContext _context;

			public Handler(DataContext context)
			{
				_context = context;
			}

			public async Task<Result<PagedList<Photo>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var higherEducationFacility = await _context.HigherEducationFacilities
					.Include(x => x.Photos)
					.FirstOrDefaultAsync(x => x.Id == request.HigherEducationFacilityId);
				if (higherEducationFacility == null) return null;
				return Result<PagedList<Photo>>.Success(
					PagedList<Photo>.Create(higherEducationFacility.Photos.AsQueryable(), request.Params.PageNumber, request.Params.PageSize));
			}
		}
	}
}