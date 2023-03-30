using Application.Core;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.DropdownLists
{
	public class List
	{
		public class Query : IRequest<Result<DropdownValues>>
		{

		}

		public class Handler : IRequestHandler<Query, Result<DropdownValues>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<DropdownValues>> Handle(Query request, CancellationToken cancellationToken)
			{
				var dropdownValues = new DropdownValues
				{
					Degrees = await _context.Degrees.ToListAsync(),
					Regions = await _context.Regions.ToListAsync(),
					CurrentStatuses = await _context.CurrentStatuses.ToListAsync(),
					KnowledgeBranches = await _context.KnowledgeBranches.ProjectTo<KnowledgeBranchDto>(_mapper.ConfigurationProvider).ToListAsync(),
					Languages = await _context.Languages.ToListAsync(),
					StudyForms = await _context.StudyForms.ToListAsync(),
					Accreditations = await _context.Accreditations.ToListAsync()
				};
				return Result<DropdownValues>.Success(dropdownValues);
			}
		}
	}
}