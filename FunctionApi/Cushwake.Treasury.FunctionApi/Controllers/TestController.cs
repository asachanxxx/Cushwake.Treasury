using System;
using System.Net;
using System.Threading.Tasks;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Cushwake.Treasury.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Cushwake.Treasury.Infrastructure.Extensions;
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
    [FunctionName("GetTodoItemsWithPagination")]
    [QueryStringParameter("ListId", "", DataType = typeof(int), Required = false)]
    [QueryStringParameter("PageNumber", "", DataType = typeof(int), Required = false)]
    [QueryStringParameter("PageSize", "", DataType = typeof(int), Required = false)]
    [FixedDelayRetry(2, "00:00:10")]
    public async Task<IActionResult> GetTodoItemsWithPagination(
     [HttpTrigger(AuthorizationLevel.Function, "GET", Route = "GetTodoItemsWithPagination")]
          HttpRequest request,
     ILogger logger)
    {
        try
        {
            //Log the calling status to log
            logger.LogInformation("GetAtachmentServices called");
            var type = "API Call";

            //Accuaring the URL parameters
            string listId = request.Query["ListId"];
            string pageNumber = request.Query["PageNumber"];
            string pageSize = request.Query["PageSize"];

            //Create the CQRS Query to send
            var query = new GetTodoItemsWithPaginationQuery()
            {
                ListId = listId.ToInteger(),
                PageNumber = pageNumber.ToInteger(),
                PageSize = pageSize.ToInteger(),
            };

            //Inject the Query to Mediator to send 
            var result = await Mediator.Send(query);
            //Handling output values and send IActionResult based on what we have
            return result != null ? SendSuccessfulGetResult(type, result) : SendNotFoundResult($"Table '{type}' not found", type, logger);
        }
        catch (Exception ex)
        {
            //in case of an error we will send Error decorated IActionResult result
            return SendFailedResult(ex, "API", logger);
        }

    }

}
