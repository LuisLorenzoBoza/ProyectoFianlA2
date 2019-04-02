using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Articulos
    {
        [Key]
        public int IdArticulos { get; set; }
        public String NombreArticulo { get; set; }
        public int Existencia { get; set; }
        public Double Precio { get; set; }

        public Articulos(int idArticulos, int idCategorias, string nombre, double precio, int existencia)
        {
            IdArticulos = idArticulos;
            NombreArticulo = nombre;
            Precio = precio;
            Existencia = existencia;
        }

        public Articulos()
        {
            IdArticulos = 0;
            NombreArticulo = String.Empty;
            Precio = 0;
            Existencia = 0;
            
        }
    }
}
