using Application.Core;
using Application.DTOs;
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
				if (!string.IsNullOrEmpty(request.Params.Name))
					query = query.Where(x => x.Name.Contains(request.Params.Name));
				if (!string.IsNullOrEmpty(request.Params.UkraineTop))
					query = query.Where(x => x.UkraineTop != 0);
				if (!string.IsNullOrEmpty(request.Params.Degree))
					query = query.Where(x => x.Specialties.Any(x => x.Degree == request.Params.Degree));
				if (!string.IsNullOrEmpty(request.Params.BranchBaseId))
				{
					var queryParams = request.Params.BranchBaseId.Split('_', StringSplitOptions.RemoveEmptyEntries);
					query = query.Where(
						x => x.Specialties.Any(
							x => queryParams.Any(
								a => a == x.SpecialtyBase.Id.Substring(0, 2))));
				}
				if (!string.IsNullOrEmpty(request.Params.SpecialtyBaseId))
				{
					var queryParams = request.Params.SpecialtyBaseId.Split('_', StringSplitOptions.RemoveEmptyEntries);
					query = query.Where(
						x => x.Specialties.Any(
							x => queryParams.Any(
								a => a == x.SpecialtyBase.Id)));
				}
				if (!string.IsNullOrEmpty(request.Params.Region))
				{
					var queryParams = request.Params.Region.Split('_', StringSplitOptions.RemoveEmptyEntries);
					query = query.Where(
						x => queryParams.Any(
							a => a == x.City.Region.Id.ToString()));
				}
				if (!string.IsNullOrEmpty(request.Params.City))
				{
					var queryParams = request.Params.City.Split('_', StringSplitOptions.RemoveEmptyEntries);
					query = query.Where(
						x => queryParams.Any(
							a => a == x.City.Id.ToString()));
				}
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
								new { SpecialtyBaseId = !string.IsNullOrEmpty(request.Params.SpecialtyBaseId) ? request.Params.SpecialtyBaseId.Split('_') : new string[0] })
							.OrderByDescending(x => x.Rating),
					request.Params.PageNumber, request.Params.PageSize)
				);
			}
		}
	}
}