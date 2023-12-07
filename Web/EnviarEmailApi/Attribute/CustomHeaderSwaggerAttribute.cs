using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EnviarEmailApi.Attribute
{
    /// <summary>
    ///
    /// </summary>
    public class CustomHeaderSwaggerAttribute : IOperationFilter
    {
        private const string HTTP_DELETE = "DELETE";

        /// <summary>
        ///
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            if (context.ApiDescription.HttpMethod == HTTP_DELETE)
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "ByPassConfirmation",
                    In = ParameterLocation.Header,
                    Required = false,
                    Schema = new OpenApiSchema
                    {
                        Type = "Boolean"
                    }
                });
            }
        }
    }
}