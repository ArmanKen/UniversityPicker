using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Reviews
{
	public class Create
	{
		public class Command : IRequest<Result<Unit>>
		{
			public ReviewDto ReviewDto { get; set; }
			public Guid UniversirtyId { get; set; }
		}

		public class CommandValidator : AbstractValidator<Command>
		{
			public CommandValidator()
			{
				RuleFor(x => x.ReviewDto).SetValidator(new ReviewValidator());
			}
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
				var university = await _context.Universities.FindAsync(request.UniversirtyId);
				if (university == null) return Result<Unit>.Failure("Failed to create rewiev");
				var user = await _context.Users
					.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
				if (user == null || university.Reviews.Any(x => x.Author == user))
					return Result<Unit>.Failure("Failed to create rewiev");
				university.Reviews.Add(new Review { Author = user, Body = request.ReviewDto.Body });
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to create rewiev");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}