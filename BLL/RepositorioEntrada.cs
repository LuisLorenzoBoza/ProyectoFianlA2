using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioEntrada : RepositorioBase<Entrada>
    {
        public RepositorioEntrada() : base()
        {

        }

        public override bool Guardar(Entrada entity)
        {
            var producto = contexto.Producto.Find(entity.ProductoId);
            producto.Inventario += entity.Cantidad;
            contexto.Entry(producto).State = EntityState.Modified;
            contexto.SaveChanges();

            return base.Guardar(entity);
        }

        public override bool Modificar(Entrada entity)
        {
            var entradaAnterior = contexto.EntradaProducto.Include(x => x.Producto).Where(z => z.EntradaId == entity.EntradaId).AsNoTracking().FirstOrDefault();

            Producto producto = entradaAnterior.Producto;
            producto.Inventario -= entradaAnterior.Cantidad;
            producto.Inventario += entity.Cantidad;
            contexto.Entry(producto).State = EntityState.Modified;
            contexto.SaveChanges();

            return base.Modificar(entity);
        }

        public override bool Eliminar(int id)
        {
            var entrada = Buscar(id);
            Producto producto = entrada.Producto;

            producto.Inventario -= entrada.Cantidad;
            contexto.Entry(producto).State = EntityState.Modified;
            contexto.SaveChanges();

            return base.Eliminar(id);
        }
    }
}
