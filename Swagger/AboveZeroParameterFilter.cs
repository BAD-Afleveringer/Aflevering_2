using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using Aflevering_2.Models;
using Microsoft.OpenApi.Any;

namespace Aflevering_2.Swagger
{
    public class AboveZeroParameterFilter : IParameterFilter
    {
        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
            // Retrieve property info from the ModelMetadata
            var metadata = context.ApiParameterDescription.ModelMetadata;
            if (metadata != null && metadata.ContainerType != null && !string.IsNullOrEmpty(metadata.PropertyName))
            {
                var propertyInfo = metadata.ContainerType.GetProperty(metadata.PropertyName);
                if (propertyInfo != null)
                {
                    var attribute = propertyInfo.GetCustomAttribute<AboveZeroAttribute>();
                    if (attribute != null)
                    {
                        // Set minimum value to 1
                        parameter.Schema.Minimum = 1;
                        // Append warning to the description
                        parameter.Description = (parameter.Description ?? "") + " (Must be greater than zero)";
                    }
                }
            }
        }
    }
}