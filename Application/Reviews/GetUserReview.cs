using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Reviews
{
	public class GetUserReview
	{
		public class Query : IRequest<Result<ReviewDto>>
		{
			public Guid UniversityId { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<ReviewDto>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;
			private readonly IUserAccessor _userAccessor;

			public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
			{
				_mapper = mapper;
				_context = context;
				_userAccessor = userAccessor;
			}

			public async Task<Result<ReviewDto>> Handle(Query request, CancellationToken cancellationToken)
			{
				var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
				if (user == null) return null;
				var review = user.Reviews.FirstOrDefault(x => x.University.Id == request.UniversityId);
				if (review == null) return null;
				return Result<ReviewDto>.Success(_mapper.Map<ReviewDto>(review));
			}
		}
	}
}