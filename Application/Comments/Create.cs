using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Comments
{
	public class Create
	{
		public class Command : IRequest<Result<CommentDto>>
		{
			public string Body { get; set; }
			public int Rating { get; set; }
			public Guid UniversirtyId { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<CommentDto>>
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

			public async Task<Result<CommentDto>> Handle(Command request, CancellationToken cancellationToken)
			{
				var university = await _context.Universities.FindAsync(request.UniversirtyId);
				if (university == null) return null!;
				var user = await _context.Users
					.Include(p => p.Photo)
					.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
				var comment = new Comment
				{
					Author = user,
					University = university,
					Body = request.Body
				};
				university.Comments.Add(comment);
				var success = await _context.SaveChangesAsync() > 0;
				if (success) return Result<CommentDto>.Success(_mapper.Map<CommentDto>(comment));
				return Result<CommentDto>.Failure("Failed to add comment");
			}
		}
	}
}