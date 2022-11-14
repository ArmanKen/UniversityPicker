using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.BranchesOfKnowledge
{
	public class List
	{
		public class Query : IRequest<Result<List<BranchOfKnowledge>>> { }

		public class Handler : IRequestHandler<Query, Result<List<BranchOfKnowledge>>>
		{
			private readonly DataContext _context;

			public Handler(DataContext context)
			{
				_context = context;
			}

			public async Task<Result<List<BranchOfKnowledge>>> Handle(Query request, CancellationToken cancellationToken)
			{
				return Result<List<BranchOfKnowledge>>.Success(await _context.BranchesOfKnowledge.ToListAsync());
			}
		}
	}
}