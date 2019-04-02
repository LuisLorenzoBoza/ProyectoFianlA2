using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Clientes
    {
        [Key]
        public int IdCliente { get; set; }
        public String Nombre { get; set; }
        public String Telefono { get; set; }
        public String Email { get; set; }

        public Clientes(int idCliente, string nombre,  string telefono,  string email)
        {
            IdCliente = idCliente;
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
        }

        public Clientes()
        {
            IdCliente = 0;
            Nombre = String.Empty;
            Telefono = String.Empty;
            Email = String.Empty;
        }
    }
}
