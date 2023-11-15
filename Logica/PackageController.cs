using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Logica
{
    public class PackageController
    {
        public static PackageModel GetPackageStatus(string idExterno)
        {
            PackageModel p = new PackageModel();
            return p.GetPackageStatus(idExterno);
        }

        public static string UpdatePackageStatus(string IdExterno, string newStatus)
        {
            PackageModel p = new PackageModel();
            return p.UpdatePackageStatus(IdExterno, newStatus);
        }
    }
}
