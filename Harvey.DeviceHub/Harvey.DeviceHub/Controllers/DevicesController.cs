using Harvey.DeviceHub.Factories;
using Harvey.DeviceHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Harvey.DeviceHub.Controllers
{
    [RoutePrefix("api/devices")]
    public class DevicesController : ApiController
    {
        [Route("receipt-printer")]
        [HttpPost]
        public async Task<bool> PostReceiptPrinter([FromBody] DeviceRequest request)
        {
            var deviceExecutor = new DeviceExecutor();
            return await deviceExecutor.ExecuteAsync(request);
        }

        //[Route("{id:int}")]
        //[HttpPost]
        //public async Task Test(int id)
        //{

        //}
    }
}