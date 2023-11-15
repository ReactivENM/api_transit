using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using API.Models;

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

        [Route("api/transit/status/{IdExterno}")]
        public IHttpActionResult Put([FromUri] string IdExterno, [FromBody] StatusModel estado)
        {
            string[] validStatus =
            {
                "en_espera",
                "en_viaje",
                "entregado"
            };
            if (validStatus.Contains(estado.Estado)) return Ok(Logica.PackageController.UpdatePackageStatus(IdExterno, estado.Estado));
            else return BadRequest("El estado no es válido!");
        }
    }
}
