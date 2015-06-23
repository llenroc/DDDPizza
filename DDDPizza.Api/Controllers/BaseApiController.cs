using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace DDDPizza.Api.Controllers
{
    public abstract class BaseApiController : ApiController
    {

        protected async Task<IHttpActionResult> GetIHttpActionResult(Func<IHttpActionResult> codeToExecute)
        {
            try
            {
                return codeToExecute.Invoke();

            }
            catch (Exception e)
            {
                return InternalServerError(new Exception(string.Format("exception: {0}", e)));
            }
        }
        
    }
}