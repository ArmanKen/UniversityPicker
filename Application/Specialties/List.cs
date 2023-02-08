using Application.Core;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Specialties
{
	public class List
	{
		public class Query : IRequest<Result<PagedList<SpecialtyDto>>>
		{
			public Guid Id { get; set; }
			public SpecialtyParams Params { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<PagedList<SpecialtyDto>>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<PagedList<SpecialtyDto>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var university = await _context.Universities
					.Include(x => x.Specialties)
					.ThenInclude(x => x.SpecialtyBase.Isceds)
					.FirstOrDefaultAsync(x => x.Id == request.Id);
				if (university == null) return null;
				var query = university.Specialties
					.AsQueryable();
				if (!string.IsNullOrEmpty(request.Params.SearchString))
					query = query.Where(x => x.SpecialtyBase.Name.Contains(request.Params.SearchString) ||
						x.SpecialtyBase.Id.Contains(request.Params.SearchString));
				return Result<PagedList<SpecialtyDto>>.Success(
					PagedList<SpecialtyDto>.Create(
						query
							.ProjectTo<SpecialtyDto>(_mapper.ConfigurationProvider)
							.OrderBy(x => x.SpecialtyBaseId),
					request.Params.PageNumber, request.Params.PageSize));
			}
		}
	}
}