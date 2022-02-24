using System.IO;

namespace Qitar.Web.Swagger
{
    public interface ISwaggerHtmlResolver
    {
        Stream Resolver();
    }
}
