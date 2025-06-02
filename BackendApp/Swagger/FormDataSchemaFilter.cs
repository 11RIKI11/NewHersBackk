using Core.Model.DTO.Event;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BackendApp.Swagger;
public class FormDataSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(EventUpdateRequest))
        {
            schema.Properties.Add("image[]", new OpenApiSchema
            {
                Type = "array",
                Format = "binary",
                Description = "Файлы изображений"
            });

            schema.Properties.Add("imageId[]", new OpenApiSchema
            {
                Type = "array",
                Items = new OpenApiSchema { Type = "string", Format = "uuid" },
                Description = "ID существующих изображений"
            });

            schema.Properties.Add("localOrderRank[]", new OpenApiSchema
            {
                Type = "array",
                Items = new OpenApiSchema { Type = "integer", Format = "int16" },
                Description = "Порядковые номера изображений"
            });
        }
    }
}
