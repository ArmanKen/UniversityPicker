using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
	public class List
	{
		public class Query : IRequest<Result<List<Model>>> { }

		public class Handler : IRequestHandler<Query, Result<List<Model>>>
		{
			private readonly DataContext _context;

			public Handler(DataContext context)
			{
				_context = context;
			}

			public async Task<Result<List<Model>>> Handle(Query request, CancellationToken cancellationToken)
			{
				return new Result<List<Model>>();
				// return Result<List<Model>>.Success(await _context.Model.ToListAsync());
			}
		}
	}
}