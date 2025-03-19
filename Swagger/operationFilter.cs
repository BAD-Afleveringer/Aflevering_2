using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Aflevering_2.Models;

namespace Aflevering_2.Swagger
{
    public class CreateExperienceOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var parameter = context.MethodInfo.GetParameters()
                .FirstOrDefault(p => p.ParameterType == typeof(CreateExperienceDTO));

            if (parameter != null)
            {
                operation.RequestBody = null; // Remove the default body
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "Title",
                    In = ParameterLocation.Query,
                    Required = true,
                    Schema = new OpenApiSchema { Type = "string" }
                });
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "Price",
                    In = ParameterLocation.Query,
                    Required = true,
                    Schema = new OpenApiSchema { Type = "integer" }
                });
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "ProviderId",
                    In = ParameterLocation.Query,
                    Required = false,
                    Schema = new OpenApiSchema { Type = "integer" }
                });
            }
        }
    }
}
