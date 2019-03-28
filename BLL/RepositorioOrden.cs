using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioOrden : RepositorioBase<Orden>
    {
        public RepositorioOrden() : base()
        {

        }

        public override Orden Buscar(int id)
        {
            Orden orden = contexto.Orden.Find(id);
            if (orden != null)
            {
                orden.Detalle.Count();

                foreach (var item in orden.Detalle)
                {
                    string s = item.Producto.Descripcion;
                }

            }

            return base.Buscar(id);
        }

        public override bool Guardar(Orden entity)
        {

            foreach (var item in entity.Detalle)
            {
                contexto.Producto.Find(item.ProductoId).Inventario -= item.Cantidad;
            }

            var usuario = contexto.Usuario.Find(entity.UsuarioId);
            usuario.Ordenes += 1;
            contexto.SaveChanges();

            return base.Guardar(entity);
        }

        public override bool Modificar(Orden entity)
        {
            
            var ordenAnterior = contexto.Orden.Include(x => x.Detalle).Where(z => z.OrdenId == entity.OrdenId).AsNoTracking().FirstOrDefault();

            foreach (var item in ordenAnterior.Detalle)
            {
                contexto.Entry(item).State = EntityState.Deleted;
            }

            foreach (var item in entity.Detalle)
            {
                contexto.Entry(item).State = (item.OrdenDetalleId == 0) ? EntityState.Added : EntityState.Modified;
            }

            return base.Modificar(entity);
        }

        public override bool Eliminar(int id)
        {
            Orden orden = contexto.Orden.Find(id);

            foreach (var item in orden.Detalle)
            {
                contexto.Producto.Find(item.ProductoId).Inventario += item.Cantidad;

            }

            contexto.Usuario.Find(orden.UsuarioId).Ordenes -= 1;
            orden.Detalle.Count();
            contexto.Orden.Remove(orden);
            contexto.SaveChanges();

            return base.Eliminar(id);
        }
    }
}
