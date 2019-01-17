using Harvey.Device.Connector.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Harvey.Device.Connector.Controllers
{
    [RoutePrefix("api/devices")]
    public class DevicesController : ApiController
    {
        [Route("receipt-printer")]
        [HttpPost]
        public async Task<bool> PostReceiptPrinter([FromBody] DeviceRequest request)
        {
            var device = DeviceFactory.CreateDeviceFromType(request.Type, request.Data);
            return await device.Execute();
        }

        //[Route("{id:int}")]
        //[HttpPost]
        //public async Task Test(int id)
        //{
            
        //}
    }
}