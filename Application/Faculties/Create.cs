using Application.Core;
using Application.DTOs;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Faculties
{
	public class Create
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Guid UniversityId { get; set; }
			public FacultyDto Faculty { get; set; }
		}

		public class CommandValidator : AbstractValidator<Command>
		{
			public CommandValidator()
			{
				RuleFor(x => x.Faculty).SetValidator(new FacultyValidator());
			}
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				var university = await _context.Universities.FindAsync(request.UniversityId);
				if (university == default) return Result<Unit>.Failure("Failed to create faculty");
				university.Faculties.Add(_mapper.Map<Faculty>(request.Faculty));
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to create faculty");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}