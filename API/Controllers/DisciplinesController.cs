using Application.Disciplines;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class DisciplinesController : BaseApiController
	{
		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> GetDisciplines()
		{
			return HandleResult(await Mediator.Send(new List.Query()));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPost]
		public async Task<IActionResult> CreateDiscipline(Discipline discipline)
		{
			return HandleResult(await Mediator.Send(new Create.Command { Discipline = discipline }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpPut("{id}")]
		public async Task<IActionResult> ChangeUniversity(int id, Discipline discipline)
		{
			discipline.Id = id;
			return HandleResult(await Mediator.Send(new Edit.Command { Id = id, Discipline = discipline }));
		}

		[Authorize(Policy = "IsLocalAdmin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUniversity(Guid id)
		{
			return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
		}
	}
}