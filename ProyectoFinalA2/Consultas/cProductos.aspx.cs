﻿using BLL;
using Entidades;
using Microsoft.Reporting.WebForms;
using ProyectoFinalA2.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalA2.Consultas
{
    public partial class cProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MetodoReporte();
            }

        }


        public static List<Productos> MetodoBuscar(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Productos, bool>> filtro = p => true;
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            List<Productos> list = new List<Productos>();

            int id = Utils.ToInt(criterio);
            decimal pre = Utils.ToDecimal(criterio);
            switch (index)
            {
                case 0://Todo
                    repositorio.GetList(c => true);
                    break;
                case 1://Id
                    filtro = p => p.ProductoId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 2://Nombres
                    filtro = p => p.NombreProducto.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 4://Tipo
                    filtro = p => p.TipoProducto.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 5://precio
                    filtro = p => p.Precio == pre && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 6://Descripcion
                    filtro = p => p.Descripcion.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 7://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Utils.ToInt(CriterioTextBox.Text);
            int index = FiltroDropDownList.SelectedIndex;
            DateTime desde = Utils.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Utils.ToDateTime(HastaTextBox.Text);

            DatosGridView.DataSource = MetodoBuscar(index, CriterioTextBox.Text, desde, hasta);
            DatosGridView.DataBind();
        }

        public static List<Productos> Lista(Expression<Func<Productos, bool>> Filtro)
        {
            Filtro = r => true;
            RepositorioBase<Productos> Repositorio = new RepositorioBase<Productos>();
            List<Productos> usuarios = new List<Productos>();
            usuarios = Repositorio.GetList(Filtro);
            return usuarios;
        }

        public void MetodoReporte()
        {
            Expression<Func<Productos, bool>> Filtra = r => true;
            CombosReportViewer.ProcessingMode = ProcessingMode.Local;
            CombosReportViewer.Reset();
            CombosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\Report_Productos.rdlc");
            CombosReportViewer.LocalReport.DataSources.Clear();
            CombosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Productos", Lista(Filtra)));
            CombosReportViewer.LocalReport.Refresh();
        }
    }
}