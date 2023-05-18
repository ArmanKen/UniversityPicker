using Application.Core;
using Application.DTOs;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.HigherEducationFacilities
{
	public class Create
	{
		public class Command : IRequest<Result<Unit>>
		{
			public HigherEducationFacilityDto HigherEducationFacility { get; set; }
		}

		public class CommandValidator : AbstractValidator<Command>
		{
			public CommandValidator()
			{
				RuleFor(x => x.HigherEducationFacility).SetValidator(new HigherEducationFacilityValidator());
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
				_context.HigherEducationFacilities.Add(_mapper.Map<HigherEducationFacility>(request.HigherEducationFacility));
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to create higherEducationFacility");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}