using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
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
					.AsQueryable();
				if (!string.IsNullOrEmpty(request.Params.SpecialtyBaseId))
				{
					query = query.Where(x => x.Specialties.Any(x => x.SpecialtyBase.Id == request.Params.SpecialtyBaseId));
					foreach (var university in query)
						university.Specialties = new List<Specialty>
						{ university.Specialties.FirstOrDefault(x => x.SpecialtyBase.Id == request.Params.SpecialtyBaseId) };
				}
				if (!string.IsNullOrEmpty(request.Params.Degree))
					query = query.Where(x => x.Specialties.Any(x => x.Degree == request.Params.Degree));
				if (!string.IsNullOrEmpty(request.Params.Region))
					query = query.Where(x => x.City.Region.Name == request.Params.Region);
				if (!string.IsNullOrEmpty(request.Params.City))
					query = query.Where(x => x.City.Name == request.Params.City);
				if (!string.IsNullOrEmpty(request.Params.SpecialtyBaseId) && !string.IsNullOrEmpty(request.Params.MinPrice))
					query = query.Where(x => x.Specialties.Any(x => x.PriceUAH >= int.Parse(request.Params.MinPrice)));
				if (!string.IsNullOrEmpty(request.Params.SpecialtyBaseId) && !string.IsNullOrEmpty(request.Params.MaxPrice))
					query = query.Where(x => x.Specialties.Any(x => x.PriceUAH <= int.Parse(request.Params.MaxPrice)));
				if (!string.IsNullOrEmpty(request.Params.SpecialtyBaseId) && !string.IsNullOrEmpty(request.Params.BudgetAllowed))
					query = query.Where(x => x.Specialties.Any(x => x.BudgetAllowed == bool.Parse(request.Params.BudgetAllowed)));
				return Result<PagedList<UniversityDto>>.Success(
					await PagedList<UniversityDto>.CreateAsync(
						query.OrderBy(u => u.Rating)
						.ProjectTo<UniversityDto>(_mapper.ConfigurationProvider),
					request.Params.PageNumber, request.Params.PageSize)
				);
			}
		}
	}
}