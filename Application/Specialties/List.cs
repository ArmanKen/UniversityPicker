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
			public Guid FacultyId { get; set; }
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
				var faculty = await _context.Faculties
					.FindAsync(request.FacultyId);
				if (faculty == null) return null;
				var query = faculty.Specialties
					.AsQueryable()
					.Where(x =>
						(string.IsNullOrEmpty(request.Params.Name)
						|| x.SpecialtyBase.Id.ToLower() == request.Params.Name.ToLower()
						|| x.SpecialtyBase.Name.ToLower() == request.Params.Name.ToLower()));
				return Result<PagedList<SpecialtyDto>>.Success(
					PagedList<SpecialtyDto>.Create(
						query
							.ProjectTo<SpecialtyDto>(_mapper.ConfigurationProvider)
							.OrderBy(x => x.SpecialtyBase.Id),
					request.Params.PageNumber, request.Params.PageSize));
			}
		}
	}
}