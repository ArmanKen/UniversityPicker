using Application.Core;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Reviews
{
	public class Delete
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Guid UniversirtyId { get; set; }
			public Guid ReviewId { get; set; }
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
				var higherEducationFacility = await _context.HigherEducationFacilities.FindAsync(request.UniversirtyId);
				if (higherEducationFacility == null) return null;
				var review = higherEducationFacility.Reviews.FirstOrDefault(x => x.Id == request.ReviewId);
				if (review == null) return null;
				var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
				if (user != null || user.UserName != review.Author.UserName || user.IsGlobalAdmin) return null;
				higherEducationFacility.Reviews.Remove(review);
				var success = await _context.SaveChangesAsync() > 0;
				if (success) return Result<Unit>.Success(Unit.Value);
				return Result<Unit>.Failure("Failed to delete comment");
			}
		}
	}
}