using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ProyectoFinalA2.Registros
{
    public partial class rOrdenes : System.Web.UI.Page
    {
        RepositorioOrden repositorio = new RepositorioOrden();
        List<OrdenDetalle> Detalle = new List<OrdenDetalle>();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataGridView.Visible = true;
            DataGridView.DataBind();
        }


        void Limpiar()
        {
            ordenIdTextbox.Text = "0";
            fechaTextbox.Text = DateTime.Today.ToString();
            usuarioIdTextbox.Text = "1";
            DatosGridView.Visible = true;
            DatosGridView.DataBind();
        }

        private void LlenaCampos(Orden orden)
        {
            ordenIdTextbox.Text = orden.OrdenId.ToString();
            usuarioIdTextbox.Text = orden.UsuarioId.ToString();
            totalTextbox.Text = orden.Total.ToString();
        }

        private Orden LlenaClase()
        {
            var Entidad = new Orden();

            Entidad.UsuarioId = int.Parse(usuarioIdTextbox.Text);
            Entidad.Detalle = Detalle;

            return Entidad;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ordenIdTextbox.Text))
            {
                int id = Convert.ToInt32(ordenIdTextbox.Text);
                if (id != 0)
                {
                    RepositorioBase<Orden> repositorio = new RepositorioBase<Orden>();
                    Orden orden = repositorio.Buscar(id);

                    if (orden != null)
                    {
                        LlenaCampos(orden);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "toastr_message", script: "toastr['error']('No existe');", addScriptTags: true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "toastr_message", script: "toastr['warning']('Seleccione un ID');", addScriptTags: true);
                }
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ordenIdTextbox.Text == "0")
            {
                repositorio.Guardar(LlenaClase());
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Guardado con exito.')", true);
            }
            else
            {
                Orden orden = repositorio.Buscar(int.Parse(ordenIdTextbox.Text));

                orden = LlenaClase();

                repositorio.Modificar(orden);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Modificado con Exito.')", true);
            }
            Limpiar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ordenIdTextbox.Text);
            if (id != 0)
            {
                RepositorioBase<Orden> repositorio = new RepositorioBase<Orden>();
                if (repositorio.Buscar(id) != null)
                {
                    if (repositorio.Eliminar(id))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "toastr_message", script: "toastr['success']('Eliminado con Exito');", addScriptTags: true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "toastr_message", script: "toastr['error']('No se pudo eliminar');", addScriptTags: true);
                    }
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "toastr_message", script: "toastr['error']('No existe');", addScriptTags: true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "toastr_message", script: "toastr['warning']('Seleccione un ID');", addScriptTags: true);
            }
        }
    }
}