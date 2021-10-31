using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using TsBizcase.Api.Filters.Helpers;
using TsBizcase.Application.Model;

namespace TsBizcase.Api.Filters
{
    public class ValidateInputOnPostAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            var input = RequestBodyReader.GetBody<TenderRecordInput>(request).Result;

            var model = new Dictionary<string, string>
                {
                    { "Name", string.IsNullOrWhiteSpace(input.Name) ? "Should not be empty" : string.Empty },
                    { "ReferenceNumber", string.IsNullOrWhiteSpace(input.ReferenceNumber) ? "Should not be empty" : string.Empty },
                    { "Description", string.IsNullOrWhiteSpace(input.Description) ? "Should not be empty" : string.Empty },
                    { "CreatorId", input.CreatorId == 0 ? "Invalid or should not be 0" : string.Empty },
                    { "ReleaseDate", input.ReleaseDate <= DateTime.Now.Date ? "Should be a valid date or must be later than current date" : string.Empty },
                    { "ClosingDate", input.ClosingDate <= input.ReleaseDate ? "Should be a valid date or must be later than Release Date" : string.Empty }
                };

            model = model.Where((p) => p.Value.Length > 0).ToDictionary(p => p.Key, p => p.Value);
            if (model.Any())
            {
                context.Result = new BadRequestObjectResult(new { ParsedRequestBodyError = model });
            };
        }
    }

    public class ValidateInputOnPutAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            var input = RequestBodyReader.GetBody<TenderRecord>(request).Result;

            var model = new Dictionary<string, string>
                {
                    { "Id", input.Id <= 0 ? "Invalid Id" : string.Empty },
                    { "Name", string.IsNullOrWhiteSpace(input.Name) ? "Should not be empty" : string.Empty },
                    { "ReferenceNumber", string.IsNullOrWhiteSpace(input.ReferenceNumber) ? "Should not be empty" : string.Empty },
                    { "Description", string.IsNullOrWhiteSpace(input.Description) ? "Should not be empty" : string.Empty },
                    { "CreatorId", input.CreatorId == 0 ? "Invalid or should not be 0" : string.Empty },
                    { "ReleaseDate", input.ReleaseDate <= DateTime.Now.Date ? "Should be a valid date or must be later than current date" : string.Empty },
                    { "ClosingDate", input.ClosingDate <= input.ReleaseDate ? "Should be a valid date or must be later than Release Date" : string.Empty }
                };

            model = model.Where((p) => p.Value.Length > 0).ToDictionary(p => p.Key, p => p.Value);
            if (model.Any())
            {
                context.Result = new BadRequestObjectResult(new { ParsedRequestBodyError = model });
            };
        }
    }
} 
