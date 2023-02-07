using Application.Core;
using Application.DTOs;
using AutoMapper;
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
			public DisciplineDto Discipline { get; set; }
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
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				var specialty = _context.Specialties.FindAsync(request.SpecialtyId).Result;
				if (specialty == null) return Result<Unit>.Failure("Failed to create discipline");
				var discipline = new SpecialtyDiscipline
				{
					Specialty = specialty,
					Discipline = _mapper.Map<Discipline>(request.Discipline),
					IsOptional = request.Discipline.IsOptional
				};
				specialty.Disciplines.Add(discipline);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to create discipline");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}