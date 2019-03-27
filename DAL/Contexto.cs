using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<EntradaProducto> EntradaProducto { get; set; }
        public DbSet<Orden> Orden { get; set; }
        public DbSet<OrdenDetalle> OrdenesDetalle { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
