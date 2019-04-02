using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class FacturasDetalle
    {
        [Key]
        public int ID { get; set; }
        public int FacturaID { get; set; }
        public int IDProd { get; set; }
        public int Cantidad { get; set; }
        public string NombreArticulo { get; set; }
        public int Precio { get; set; }
        public int Importe { get; set; }


        public FacturasDetalle(int id, int idFactura, int idProd, int cantidad, string nombreArticulo, int precio, int importe)
        {
            ID = id;
            FacturaID = idFactura;
            IDProd = idProd;
            Cantidad = cantidad;
            NombreArticulo = nombreArticulo;
            Precio = precio;
            Importe = importe;
        }

        public FacturasDetalle()
        {
            ID = 0;
            FacturaID = 0;
            IDProd = 0;
            Cantidad = 0;
            NombreArticulo = string.Empty;
            Precio = 0;
            Importe = 0;
        }
    }
}
