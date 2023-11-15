using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class PackageModel : Model
    {
        public string IdExterno;
        public string Estado;

        public int Id;

        public PackageModel GetPackageStatus(String idExterno)
        {
            this.Command.CommandText = $"SELECT estado " + $"FROM paquete WHERE id_externo = '{idExterno}'";
            this.Reader = this.Command.ExecuteReader();

            PackageModel p = new PackageModel();

            if (this.Reader.HasRows)
            {
                this.Reader.Read();
                p.IdExterno = idExterno;
                p.Estado = this.Reader["estado"].ToString();
                return p;
            }

            return null;

        }

        public string UpdatePackageStatus(string IdExterno, string newStatus)
        {
            this.Command.CommandText = $"SELECT * FROM paquete WHERE id_externo = '{IdExterno}'";
            this.Reader = this.Command.ExecuteReader();
            if (this.Reader.HasRows)
            {
                this.Reader.Close();

                this.Command.CommandText = $"UPDATE paquete SET " +
                    $"estado = '{newStatus}' " +
                    $"WHERE id_externo = '{IdExterno}'";

                this.Command.ExecuteNonQuery();

                return "Estado del paquete actualizado!";
            }
            return "El paquete no existe!";
        }
    }
}
