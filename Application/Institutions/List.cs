using Application.Core;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Institutions
{
	public class List
	{
		public class Query : IRequest<Result<PagedList<InstitutionDto>>>
		{
			public InstitutionParams Params { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<PagedList<InstitutionDto>>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<PagedList<InstitutionDto>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var query = _context.Institutions
					// .Include(x => x.Specialties)
					// .ThenInclude(x => x.SpecialtyBase)
					// .Include(x => x.City)
					// .ThenInclude(x => x.Region)
					.AsQueryable();
				// if (!string.IsNullOrEmpty(request.Params.Name))
				// 	query = query.Where(x => x.Name.ToLower().Contains(request.Params.Name.ToLower()));
				// if (!string.IsNullOrEmpty(request.Params.UkraineTop))
				// 	query = query.Where(x => x.UkraineTop != 0);
				// if (!string.IsNullOrEmpty(request.Params.Region))
				// {
				// 	var queryParams = request.Params.Region.Split('_', StringSplitOptions.RemoveEmptyEntries);
				// 	query = query.Where(
				// 		x => queryParams.Any(
				// 			a => a == x.City.Region.Id.ToString()));
				// }
				// if (!string.IsNullOrEmpty(request.Params.City))
				// {
				// 	var queryParams = request.Params.City.Split('_', StringSplitOptions.RemoveEmptyEntries);
				// 	query = query.Where(
				// 		x => queryParams.Any(
				// 			a => a == x.City.Id.ToString()));
				// }
				// if (!string.IsNullOrEmpty(request.Params.BranchBaseId))
				// {
				// 	var queryParams = request.Params.BranchBaseId.Split('_', StringSplitOptions.RemoveEmptyEntries);
				// 	if (!string.IsNullOrEmpty(request.Params.Degree) && int.TryParse(request.Params.Degree, out int degree))
				// 		query = query.Where(
				// 			x => x.Specialties.Any(
				// 				x => queryParams.Any(
				// 					a => a == x.SpecialtyBase.Id.Substring(0, 2)) && x.Degree.Id == degree));
				// 	if (!string.IsNullOrEmpty(request.Params.BudgetAllowed) && bool.TryParse(request.Params.BudgetAllowed, out bool budget))
				// 		query = query.Where(
				// 			x => x.Specialties.Any(
				// 				x => queryParams.Any(
				// 					a => a == x.SpecialtyBase.Id.Substring(0, 2)) && x.BudgetAllowed == budget));
				// 	if (string.IsNullOrEmpty(request.Params.Degree) && string.IsNullOrEmpty(request.Params.BudgetAllowed))
				// 		query = query.Where(
				// 			   x => x.Specialties.Any(
				// 				   x => queryParams.Any(
				// 					   a => a == x.SpecialtyBase.Id.Substring(0, 2))));
				// }
				// if (!string.IsNullOrEmpty(request.Params.SpecialtyBaseId))
				// {
				// 	var queryParams = request.Params.SpecialtyBaseId.Split('_', StringSplitOptions.RemoveEmptyEntries);
				// 	if (!string.IsNullOrEmpty(request.Params.Degree) && int.TryParse(request.Params.Degree, out int degree))
				// 		query = query.Where(
				// 			x => x.Specialties.Any(
				// 				x => queryParams.Any(
				// 					a => a == x.SpecialtyBase.Id) && x.Degree.Id == degree));
				// 	if (!string.IsNullOrEmpty(request.Params.BudgetAllowed) && bool.TryParse(request.Params.BudgetAllowed, out bool budget))
				// 		query = query.Where(
				// 			x => x.Specialties.Any(
				// 				x => queryParams.Any(
				// 					a => a == x.SpecialtyBase.Id) && x.BudgetAllowed == budget));
				// 	if (!string.IsNullOrEmpty(request.Params.MinPrice) && int.TryParse(request.Params.MinPrice, out int min))
				// 		query = query.Where(
				// 			x => x.Specialties.Any(
				// 				y => y.SpecialtyBase != null && queryParams.Any(a => a == y.SpecialtyBase.Id) && y.PriceUAH >= min));
				// 	if (!string.IsNullOrEmpty(request.Params.MaxPrice) && int.TryParse(request.Params.MaxPrice, out int max))
				// 		query = query.Where(
				// 			x => x.Specialties.Any(
				// 				y => y.SpecialtyBase != null && queryParams.Any(a => a == y.SpecialtyBase.Id) && y.PriceUAH <= max));
				// 	if (string.IsNullOrEmpty(request.Params.MinPrice) && string.IsNullOrEmpty(request.Params.BudgetAllowed) &&
				// 	string.IsNullOrEmpty(request.Params.MaxPrice) && string.IsNullOrEmpty(request.Params.Degree))
				// 		query = query.Where(
				// 			x => x.Specialties.Any(
				// 				y => y.SpecialtyBase != null && queryParams.Any(a => a == y.SpecialtyBase.Id)));
				// }
				return Result<PagedList<InstitutionDto>>.Success(
				await PagedList<InstitutionDto>.CreateAsync(
					query
						.ProjectTo<InstitutionDto>(_mapper.ConfigurationProvider)
						.OrderByDescending(x => x.Rating),
				request.Params.PageNumber, request.Params.PageSize)
			);
			}
		}
	}
}