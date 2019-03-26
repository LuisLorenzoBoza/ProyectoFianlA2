using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ProyectoFinalA2.Consultas
{
    public partial class cOrdenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(FiltroTextBox.Text) && BuscarPorDropDownList.SelectedIndex != 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Debe escribir el criterio')", true);
            }
            else
            {
                Expression<Func<Orden, bool>> filtro = x => true;
                BLL.RepositorioOrden repositorio = new BLL.RepositorioOrden();

                int id;
                switch (BuscarPorDropDownList.SelectedIndex)
                {
                    case 0:
                        filtro = c => true;
                        break;
                    case 1://ID
                        id = Convert.ToInt32(FiltroTextBox.Text);
                        filtro = c => c.OrdenId == id;
                        break;
                    case 2://FechaOrden
                        id = Convert.ToInt32(FiltroTextBox.Text);
                        filtro = c => c.FechaOrden == id;
                        break;
                    case 3://Total
                        id = Convert.ToInt32(FiltroTextBox.Text);
                        filtro = c => c.Total == id;
                        break;
                }

                DatosGridView.DataSource = repositorio.GetList(filtro);
                DatosGridView.DataBind();
            }
        }
    }
}