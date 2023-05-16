using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
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
			private readonly IUserAccessor _userAccessor;

			public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
			{
				_userAccessor = userAccessor;
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<PagedList<UniversityDto>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var resultTop = bool.TryParse(request.Params.UkraineTop, out var top);
				var resultBudget = bool.TryParse(request.Params.Budget, out var budget);
				var resultMin = int.TryParse(request.Params.MinPrice, out var min);
				var resultMax = int.TryParse(request.Params.MaxPrice, out var max);

				var query = _context.Universities
					.AsQueryable()
					.Where(x =>
						(string.IsNullOrEmpty(request.Params.Name)
							|| x.Name.ToLower().Contains(request.Params.Name.ToLower()))
						&& (!resultTop && !top || x.UkraineTop != default)
						&& (string.IsNullOrEmpty(request.Params.AccreditationId)
							|| x.Accreditation.Id.ToString() == request.Params.AccreditationId)
						&& (string.IsNullOrEmpty(request.Params.RegionsId)
							|| request.Params.RegionsId.Split('_', StringSplitOptions.RemoveEmptyEntries)
								.Any(a => a == x.Region.Id.ToString()))
						&& (string.IsNullOrEmpty(request.Params.CitiesId)
							|| request.Params.CitiesId.Split('_', StringSplitOptions.RemoveEmptyEntries)
								.Any(a => a == x.City.Id.ToString()))
						&& (string.IsNullOrEmpty(request.Params.KnowledgeBranchesId) || !string.IsNullOrEmpty(request.Params.SpecialtyBasesId)
							|| x.Faculties.FirstOrDefault(x =>
									x.KnowledgeBranches.Any(x =>
										request.Params.KnowledgeBranchesId.Split('_', StringSplitOptions.RemoveEmptyEntries)
											.Any(a => a == x.Id))) != default)
						&& (string.IsNullOrEmpty(request.Params.SpecialtyBasesId)
							|| x.Faculties.FirstOrDefault(x =>
								x.Specialties.Any(x =>
									(string.IsNullOrEmpty(request.Params.DegreeId)
										|| x.Degree.Id.ToString() == request.Params.DegreeId)
									&& (!resultBudget || x.BudgetAllowed == budget)
									&& request.Params.SpecialtyBasesId.Split('_', StringSplitOptions.RemoveEmptyEntries)
										.Any(a => x.SpecialtyBase.Id == a)
									&& (!resultMin || x.PriceUAH >= min)
									&& (!resultMax || x.PriceUAH <= max))) != default));

				return Result<PagedList<UniversityDto>>.Success(
				await PagedList<UniversityDto>.CreateAsync(
					query
						.ProjectTo<UniversityDto>(_mapper.ConfigurationProvider, new { username = _userAccessor.GetUsername() })
						.OrderByDescending(x => x.Rating),
				request.Params.PageNumber, request.Params.PageSize)
			);
			}
		}
	}
}