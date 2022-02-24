using System;

namespace Qitar.Web.Swagger
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ConcealedApiAttribute : Attribute
    {
    }
}
