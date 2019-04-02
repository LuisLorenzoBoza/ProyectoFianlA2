using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Facturas
    {
        [Key]
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public Double Monto { get; set; }
        public Double Devuelta { get; set; }
        public Double EfectivoRecibido { get; set; }
        public String Observacion { get; set; }
        public int Cantidad { get; set; }

        public virtual List<FacturasDetalle> Lista { get; set; }

        public Facturas(int idFactura, int idCliente, DateTime fecha, double monto, double devuelta, double efectivoRecibido, string observacion, List<FacturasDetalle> lista)
        {
            IdFactura = idFactura;
            IdCliente = idCliente;
            IdUsuario = IdUsuario;
            Fecha = fecha;
            Monto = monto;
            Devuelta = devuelta;
            EfectivoRecibido = efectivoRecibido;
            Observacion = observacion;
            Lista = lista;
            Cantidad = Cantidad;
        }

       // public Facturas()
       //{
       //     IdFactura = 0;
       //     IdCliente = 0;
       //     Fecha = DateTime.Now;
       //     Monto = 0;
       //     Observacion = String.Empty;
       //     Lista = new List<FacturasDetalle>();
       //     Cantidad = 0;
       // }

        public Facturas()
        {
            this.Lista = new List<FacturasDetalle>();
        }

    }
}
