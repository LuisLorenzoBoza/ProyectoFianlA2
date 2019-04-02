using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Productos
    {
        [Key]
        public int IdProductos { get; set; }
        public String Nombre { get; set; }
        public int Existencia { get; set; }
        public Double Precio { get; set; }

        public Productos(int idArticulos, int idCategorias, string nombre, double precio, int existencia)
        {
            IdProductos = idArticulos;
            Nombre = nombre;
            Precio = precio;
            Existencia = existencia;
        }

        public Productos()
        {
            IdProductos = 0;
            Nombre = String.Empty;
            Precio = 0;
            Existencia = 0;
            
        }
    }
}
