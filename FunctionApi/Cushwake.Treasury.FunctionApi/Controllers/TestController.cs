using System;
using System.Net;
using System.Threading.Tasks;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Cushwake.Treasury.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Cushwake.Treasury.FunctionApi.Controllers;

[ApiExplorerSettings(GroupName = "AttachmentServices")]

internal class TestController : ApiController
{
    public TestController(ILogger<ApiController> logger, IHttpContextAccessor httpContextAccessor) : base(logger, httpContextAccessor)
    {

    }

    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [FunctionName("GetAtachment")]
    [QueryStringParameter("BudgetId", "", DataType = typeof(string), Required = false)]
    [QueryStringParameter("PageNumber", "", DataType = typeof(string), Required = false)]
    [QueryStringParameter("PageSize", "", DataType = typeof(string), Required = false)]
    [FixedDelayRetry(2, "00:00:10")]
    public async Task<IActionResult> GetAtachmentService(
     [HttpTrigger(AuthorizationLevel.Function, "GET", Route = "attachment")]
          HttpRequest request,
     ILogger logger)
    {
        try
        {
            logger.LogInformation("GetAtachmentServices called");
            var type = "API Call";
            var query = new GetTodoItemsWithPaginationQuery()
            {
                ListId = 1,
                PageNumber = 1,
                PageSize = 10,
            };
            var result = await Mediator.Send(query);
            return result != null ? SendSuccessfulGetResult(type, result) : SendNotFoundResult($"Table '{type}' not found", type, logger);
        }
        catch (Exception ex)
        {
            return SendFailedResult(ex, "API", logger);
        }

    }

}
