using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Reviews
{
	public class Details
	{
		public class Query : IRequest<Result<ReviewDto>>
		{
			public Guid ReviewId { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<ReviewDto>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<ReviewDto>> Handle(Query request, CancellationToken cancellationToken)
			{
				var review = await _context.Reviews
					.ProjectTo<ReviewDto>(_mapper.ConfigurationProvider)
					.FirstOrDefaultAsync(x => x.Id == request.ReviewId);
				if (review == null) return null;
				return Result<ReviewDto>.Success(review);
			}
		}
	}
}