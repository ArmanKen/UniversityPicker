using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Reviews

{
	public class Edit
	{
		public class Command : IRequest<Result<ReviewDto>>
		{
			public string Body { get; set; }
			public int Rating { get; set; }
			public Guid UniversirtyId { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<ReviewDto>>
		{
			private readonly IUserAccessor _userAccessor;
			private readonly IMapper _mapper;
			private readonly DataContext _context;

			public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
			{
				_context = context;
				_mapper = mapper;
				_userAccessor = userAccessor;
			}

			public async Task<Result<ReviewDto>> Handle(Command request, CancellationToken cancellationToken)
			{
				var university = await _context.Universities.FindAsync(request.UniversirtyId);
				if (university == null) return null;
				var user = await _context.Users
					.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
				var previosReview = university.Reviews.FirstOrDefault(x => x.Author == user);
				if (previosReview == null) return null;
				previosReview.Body = request.Body;
				previosReview.Rating = request.Rating;
				previosReview.CreatedAt = DateTime.UtcNow;
				university.Reviews.Add(previosReview);
				var success = await _context.SaveChangesAsync() > 0;
				if (success) return Result<ReviewDto>.Success(_mapper.Map<ReviewDto>(previosReview));
				return Result<ReviewDto>.Failure("Failed to change comment");
			}
		}
	}
}