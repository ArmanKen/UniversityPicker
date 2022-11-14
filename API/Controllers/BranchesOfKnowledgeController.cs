using Application.BranchesOfKnowledge;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BranchesOfKnowledgeController : BaseApiController
    {
		[HttpGet]
		public async Task<IActionResult> GetBranchesOfKnowledge()
		{
			return HandleResult(await Mediator.Send(new List.Query()));
		}
    }
}