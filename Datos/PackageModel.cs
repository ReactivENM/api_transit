using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class PackageModel
    {
        public string IdExterno;
        public string Estado;

        public int Id;

        public PackageModel GetPackageStatus(String idExterno)
        {
            using (Model model = new Model())
            {
                model.Command.CommandText = $"SELECT estado " + $"FROM paquete WHERE id_externo = '{idExterno}'";
                model.Reader = model.Command.ExecuteReader();

                PackageModel p = new PackageModel();

                if (model.Reader.HasRows)
                {
                    model.Reader.Read();
                    p.IdExterno = idExterno;
                    p.Estado = model.Reader["estado"].ToString();
                    return p;
                }

                return null;
            }

        }

        public string UpdatePackageStatus(string IdExterno, string newStatus)
        {
            using (Model model = new Model())
            {
                model.Command.CommandText = $"SELECT * FROM paquete WHERE id_externo = '{IdExterno}'";
                model.Reader = model.Command.ExecuteReader();
                if (model.Reader.HasRows)
                {
                    model.Reader.Close();

                    model.Command.CommandText = $"UPDATE paquete SET " +
                        $"estado = '{newStatus}' " +
                        $"WHERE id_externo = '{IdExterno}'";

                    model.Command.ExecuteNonQuery();

                    return "Estado del paquete actualizado!";
                }
                return "El paquete no existe!";
            }
        }
    }
}
