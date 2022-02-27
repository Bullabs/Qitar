namespace Qitar.Web.Controllers
{
    public class BaseControllerResponse : IControllerResponse
    {
        public bool Succeed { get; set; }

        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }
    public class BaseControllerResponse<T> : IControllerResponse
    {

        public T Data { get; set; }
    }
}
