using Qitar.Objects.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qitar.Web.Controllers
{
    public interface IControllerResponse : IResult
    {
    }
    public interface IControllerResponse<T> : IResult
    {
        public T Data { get; set; }
    }
}
