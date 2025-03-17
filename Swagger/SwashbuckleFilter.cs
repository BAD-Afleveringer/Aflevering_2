using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Aflevering_2.Models;

namespace Aflevering_2.Swagger
{
    public class AboveZeroFilter : ISchemaFilter
    {
        private readonly ILogger<AboveZeroFilter> _logger;

        public AboveZeroFilter(ILogger<AboveZeroFilter> logger) // Inject logger
        {
            _logger = logger;
        }

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            _logger.LogInformation($"Applying AboveZeroFilter for type: {context.Type.Name}");

            if (context.Type == typeof(Experience) || context.Type == typeof(CreateExperienceDTO))
            {
                foreach (var property in context.Type.GetProperties())
                {
                    _logger.LogInformation($"Checking property: {property.Name}");

                    var attribute = property.GetCustomAttributes(typeof(AboveZeroAttribute), false)
                                            .FirstOrDefault() as AboveZeroAttribute;

                    if (attribute != null && schema.Properties.ContainsKey(property.Name))
                    {
                        _logger.LogInformation($"Applying validation for {property.Name}");
                        schema.Properties[property.Name].Description += $" (Validation: {attribute.ErrorMessage})";
                    }
                }
            }
        }
    }
}


/*using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using System.Linq;
using Aflevering_2.Models;
using System.Reflection;

namespace Aflevering_2.swagger
{
    public class AboveZeroFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(Experience))
            {
                foreach (var property in context.Type.GetProperties())
                {
                    var attribute = property.GetCustomAttributes(typeof(AboveZeroAttribute), false)
                        .FirstOrDefault() as AboveZeroAttribute;

                    if (attribute != null && schema.Properties.ContainsKey(property.Name.ToLower()))
                    {
                        schema.Properties[property.Name].Description =
                            $"{schema.Properties[property.Name].Description ?? ""} (Validation: {attribute.ErrorMessage})";
                    }
                }
            }
        }
    }
}

*/
// public class AboveZeroFilter : IOperationFilter
// {
//     // This method is used to apply the custom validation attribute to the swagger documentation,
//     // meaning that the custom validation attribute will be shown on the swagger page, under the
//     // parameter which the attribute is applied to. It is part the IOperationFilter interface.

//     // The method takes two parameters, the first one is an OpenApiOperation object, which is the
//     // operation that is being filtered. The operation is the HTTP method that is being used.
//     // The second parameter is an OperationFilterContext object, which is the context of the operation
//     // that is being filtered. The context contains information about the method that is being filtered, such as
//     // the method's parameters. The parameters are those which the action method takes in as arguments.
//     public void Apply(OpenApiOperation operation, OperationFilterContext context)
//     {
//         // This foreach loop iterates through all the parameters of the operation.
//         foreach (var parameter in operation.Parameters)
//         {
//             // customValidator would contain the custom attribute that is applied to the parameter.
//             // context.MethodInfo is the current method associated with the operation.
//             var customValidator = context.MethodInfo
//                 // Gets the parameters of the method.
//                 .GetParameters()
//                 // Finds the parameter of the method that has the same name as the parameter of the operation.
//                 .FirstOrDefault(p => p.Name == parameter.Name)?
//                 // Gets the custom attribute of the parameter, specifically the aboveZeroAttribute, specified by typeof(aboveZeroAttribute).
//                 // false means that it will not search for inherited attributes.
//                 .GetCustomAttributes(typeof(AboveZeroAttribute), false)
//                 // Takes the first attribute that is found, and casts it to an aboveZeroAttribute. If none is found, it will return null.
//                 .FirstOrDefault() as AboveZeroAttribute;


//             if (customValidator != null)
//             {
//                 // The description of the operation parameter is set here. The description is the text that is shown on the swagger page.
//                 parameter.Description = $"{parameter.Description ?? ""} (Validation: {customValidator.ErrorMessage})";
//             }
//         }
//     }
// }
/*
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Logging;
*/
/*
public class AboveZeroFilter : ISchemaFilter
{
    private readonly ILogger<AboveZeroFilter> _logger;

    public AboveZeroFilter(ILogger<AboveZeroFilter> logger)
    {
        _logger = logger;
    }

    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        _logger.LogInformation($"Applying AboveZeroFilter to {context.Type.Name}");

        if (context.Type == typeof(Experience)) // Check if the model is Experience
        {
            foreach (var property in context.Type.GetProperties())
            {
                _logger.LogInformation($"Checking property: {property.Name}");

                var attribute = property.GetCustomAttribute<AboveZeroAttribute>();
                if (attribute != null && schema.Properties.ContainsKey(property.Name.ToLower()))
                {
                    _logger.LogInformation($"Applying validation message to {property.Name}");
                    schema.Properties[property.Name.ToLower()].Description =
                        $"{schema.Properties[property.Name.ToLower()].Description ?? ""} (Validation: {attribute.ErrorMessage})";
                }
            }
        }
    }
}
*/
