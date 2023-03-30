using Application.Core;
using Application.DTOs;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;
namespace Application.Specialties

{
	public class Edit
	{
		public class Command : IRequest<Result<Unit>>
		{
			public SpecialtyDto Specialty { get; set; }
		}

		public class CommandValidator : AbstractValidator<Command>
		{
			public CommandValidator()
			{
				RuleFor(x => x.Specialty).SetValidator(new SpecialtyValidator());
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
				var specialty = await _context.Specialties.FindAsync(request.Specialty.Id);
				if (specialty == null) return Result<Unit>.Failure("Failed to update the specialty");
				_mapper.Map(request.Specialty, specialty);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to update the specialty");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}