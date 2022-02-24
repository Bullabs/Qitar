using Swashbuckle.AspNetCore.SwaggerUI;
using System.IO;
using System.Reflection;

namespace Qitar.Web.Swagger
{
    public class SwaggerHtmlResolver : ISwaggerHtmlResolver
    {
        public Stream Resolver()
        {
            var stream = typeof(SwaggerUIOptions).GetTypeInfo().Assembly.GetManifestResourceStream("Qitar.Swagger.index.html");

            return stream;
        }
    }
}
