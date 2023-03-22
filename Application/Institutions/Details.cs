using Application.Core;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Institutions
{
	public class Details
	{
		public class Query : IRequest<Result<InstitutionDto>>
		{
			public Guid Id { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<InstitutionDto>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<InstitutionDto>> Handle(Query request, CancellationToken cancellationToken)
			{
				var institution = await _context.Institutions
					.ProjectTo<InstitutionDto>(_mapper.ConfigurationProvider)
					.FirstOrDefaultAsync(x => x.Id == request.Id);
				if (institution == null) return null;
				return Result<InstitutionDto>.Success(institution);
			}
		}
	}
}