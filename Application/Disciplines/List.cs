using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Disciplines
{
	public class List
	{
		public class Query : IRequest<Result<List<Discipline>>> { }

		public class Handler : IRequestHandler<Query, Result<List<Discipline>>>
		{
			private readonly DataContext _context;

			public Handler(DataContext context)
			{
				_context = context;
			}

			public async Task<Result<List<Discipline>>> Handle(Query request, CancellationToken cancellationToken)
			{
				return Result<List<Discipline>>.Success(await _context.Disciplines.ToListAsync());
			}
		}
	}
}