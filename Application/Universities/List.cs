using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Universities
{
	public class List
	{
		public class Query : IRequest<Result<PagedList<UniversityDto>>>
		{
			public UniversityParams Params { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<PagedList<UniversityDto>>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<PagedList<UniversityDto>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var query = _context.Universities
					.Include(x => x.Specialties)
					.ThenInclude(x => x.SpecialtyBase)
					.Include(x => x.City)
					.ThenInclude(x => x.Region)
					.AsQueryable();
				if (!string.IsNullOrEmpty(request.Params.UkraineTop))
					query = query.Where(x => x.UkraineTop != 0);
				if (!string.IsNullOrEmpty(request.Params.Degree))
					query = query.Where(x => x.Specialties.Any(x => x.Degree == request.Params.Degree));
				if (!string.IsNullOrEmpty(request.Params.BranchBaseId))
					query = query.Where(x => x.Specialties.Any(x => x.SpecialtyBase.Id.Substring(0, 2) == request.Params.BranchBaseId));
				if (!string.IsNullOrEmpty(request.Params.SpecialtyBaseId))
					query = query.Where(x => x.Specialties.Any(x => x.SpecialtyBase.Id == request.Params.SpecialtyBaseId));
				if (!string.IsNullOrEmpty(request.Params.Region))
					query = query.Where(x => x.City.Region.Name == request.Params.Region);
				if (!string.IsNullOrEmpty(request.Params.City))
					query = query.Where(x => x.City.Name == request.Params.City);
				if (!string.IsNullOrEmpty(request.Params.SpecialtyBaseId) && !string.IsNullOrEmpty(request.Params.MinPrice) 
					&& int.TryParse(request.Params.MinPrice, out int min))
					query = query.Where(x => x.Specialties
						.FirstOrDefault(x => x.SpecialtyBase.Id == request.Params.SpecialtyBaseId)
						.PriceUAH >= min);
				if (!string.IsNullOrEmpty(request.Params.SpecialtyBaseId) && !string.IsNullOrEmpty(request.Params.MaxPrice) 
					&& int.TryParse(request.Params.MaxPrice, out int max))
					query = query.Where(x => x.Specialties
						.FirstOrDefault(x => x.SpecialtyBase.Id == request.Params.SpecialtyBaseId)
						.PriceUAH <= max);
				if (!string.IsNullOrEmpty(request.Params.SpecialtyBaseId) && !string.IsNullOrEmpty(request.Params.BudgetAllowed))
					query = query.Where(x => x.Specialties
						.FirstOrDefault(x => x.SpecialtyBase.Id == request.Params.SpecialtyBaseId)
						.BudgetAllowed == bool.Parse(request.Params.BudgetAllowed));
				return Result<PagedList<UniversityDto>>.Success(
					await PagedList<UniversityDto>.CreateAsync(
						query
							.ProjectTo<UniversityDto>(_mapper.ConfigurationProvider,
								new { SpecialtyBaseId = request.Params.SpecialtyBaseId })
							.OrderByDescending(x => x.Rating),
					request.Params.PageNumber, request.Params.PageSize)
				);
			}
		}
	}
}