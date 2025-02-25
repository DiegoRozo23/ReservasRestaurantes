using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class SwaggerFileOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var methodsWithForm = new[] { "POST", "PUT", "PATCH" }; // Métodos permitidos

        if (operation.RequestBody == null || !methodsWithForm.Contains(context.ApiDescription.HttpMethod.ToUpper()))
            return;

        var hasFormFile = context.ApiDescription.ParameterDescriptions
            .Any(p => p.ModelMetadata?.ModelType == typeof(IFormFile) || p.ModelMetadata?.ModelType == typeof(IFormFileCollection));

        if (hasFormFile)
        {
            operation.RequestBody.Content.Clear();
            operation.RequestBody.Content.Add("multipart/form-data", new OpenApiMediaType
            {
                Schema = new OpenApiSchema
                {
                    Type = "object",
                    Properties = new Dictionary<string, OpenApiSchema>
                    {
                        ["file"] = new OpenApiSchema
                        {
                            Type = "string",
                            Format = "binary"
                        }
                    },
                    Required = new HashSet<string> { "file" }
                }
            });
        }
    }
}
