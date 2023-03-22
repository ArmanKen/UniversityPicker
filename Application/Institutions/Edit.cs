using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Institutions
{
	public class Edit
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Institution Institution { get; set; }
			public Guid Id { get; set; }
		}

		public class CommandValidator : AbstractValidator<Command>
		{
			public CommandValidator()
			{
				RuleFor(x => x.Institution).SetValidator(new InstitutionValidator());
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
				var institution = await _context.Institutions.FindAsync(request.Id);
				if (institution == null) return null;
				_mapper.Map(request.Institution, institution);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to update the institution");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}