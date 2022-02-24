using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Qitar.Utils.Reflection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Qitar.Web.Swagger
{
    public class ConcealedApiFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (ApiDescription apiDescription in context.ApiDescriptions)
            {
                if (apiDescription.TryGetMethodInfo(out MethodInfo method))
                {
                    if (method.ReflectedType.HasAttribute<ConcealedApiAttribute>() || method.HasAttribute<ConcealedApiAttribute>())
                    {
                        string key = $"/{apiDescription.RelativePath}";
                        if (key.Contains('?'))
                        {
                            int index = key.IndexOf("?", StringComparison.Ordinal);
                            key = key.Substring(0, index);
                        }

                        swaggerDoc.Paths.Remove(key);
                    }
                }
            }
        }
    }
}
