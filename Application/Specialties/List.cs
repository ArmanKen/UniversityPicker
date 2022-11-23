using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Specialties
{
	public class List
	{
		public class Query : IRequest<Result<List<Specialtie>>> { }

		public class Handler : IRequestHandler<Query, Result<List<Specialtie>>>
		{
			private readonly DataContext _context;

			public Handler(DataContext context)
			{
				_context = context;
			}

			public async Task<Result<List<Specialtie>>> Handle(Query request, CancellationToken cancellationToken)
			{
				return Result<List<Specialtie>>.Success(await _context.Specialties.ToListAsync());
			}
		}
	}
}