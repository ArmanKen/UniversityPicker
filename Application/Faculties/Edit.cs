using Application.Core;
using Application.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Faculties
{
	public class Edit
	{
		public class Command : IRequest<Result<Unit>>
		{
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
				var faculty = await _context.Faculties.FindAsync(request.Faculty.Id);
				if (faculty == null) return Result<Unit>.Failure("Failed to update the faculty");
				_mapper.Map(request.Faculty, faculty);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to update the faculty");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}