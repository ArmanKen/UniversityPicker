using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Disciplines
{
	public class Create
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Guid SpecialtyId { get; set; }
			public Discipline Discipline { get; set; }
			public bool IsOptional { get; set; }
		}

		public class CommandValidator : AbstractValidator<Command>
		{
			public CommandValidator()
			{
				RuleFor(x => x.Discipline).SetValidator(new DisciplineValidator());
			}
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly DataContext _context;

			public Handler(DataContext context)
			{
				_context = context;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				var specialty = _context.Specialties.FindAsync(request.SpecialtyId).Result;
				if (specialty == null) return Result<Unit>.Failure("Failed to create university");
				var discipline = new SpecialtyDiscipline { Specialty = specialty, Discipline = request.Discipline, IsOptional = request.IsOptional };
				specialty.Disciplines.Add(discipline);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to create university");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}