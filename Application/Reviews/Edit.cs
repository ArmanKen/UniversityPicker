using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Reviews

{
	public class Edit
	{
		public class Command : IRequest<Result<Unit>>
		{
			public ReviewDto Review { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
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

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				var review = await _context.Reviews.FindAsync(request.Review.Id);
				if (review == null) return Result<Unit>.Failure("Failed to update the review");
				_mapper.Map(request.Review, review);
				var success = await _context.SaveChangesAsync() > 0;
				if (success) return Result<Unit>.Success(Unit.Value);
				return Result<Unit>.Failure("Failed to update review");
			}
		}
	}
}