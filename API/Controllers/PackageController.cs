using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class PackageController : ApiController
    {
        [Route("api/transit/status/{IdExterno}")]
        public IHttpActionResult GetPackageStatus([FromUri] string IdExterno)
        {
            var result = Logica.PackageController.GetPackageStatus(IdExterno);
            if (result != null) return Ok(result);
            return NotFound();
        }
    }
}
