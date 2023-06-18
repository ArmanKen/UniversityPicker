using Application.Core;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.EduComponents
{
	public class List
	{
		public class Query : IRequest<Result<List<EduComponentDto>>>
		{
			public Guid SpecialtyId { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<List<EduComponentDto>>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<List<EduComponentDto>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var eduComponents = await _context.EduComponents
				.Where(x => x.Specialty.Id == request.SpecialtyId)
				.ProjectTo<EduComponentDto>(_mapper.ConfigurationProvider)
				.ToListAsync();
				if (eduComponents == null) return null;
				return Result<List<EduComponentDto>>.Success(eduComponents);
			}
		}
	}
}