﻿using System;
using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;
using SetimBasico;
using DotNetNuke.UI.WebControls;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Web.Services;
using System.Reflection;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using System.Web.Script.Services;

namespace SetimMod_asoSocioInversion
{
    public partial class asoSocioInversion_Edit : SetimModulo
    {
        private readonly asoSocioInversionControl _EntidadControl = new asoSocioInversionControl();

        protected override void OnLoad(EventArgs e)
        {
            if (Request.Headers["X-SETIM-REQUEST"] == "TRUE") AjaxWrapper();

            base.OnLoad(e);
            this._Nivel = 1;
            this._UserID = ModuleContext.PortalSettings.UserId;
            this._EntidadId = Request.QueryString.GetValueOrDefault("EntidadId", -1);
            if (!IsPostBack)
            {
                //CargarDdl_Estados();
                ColocarDatosEnFormulario();
            }

            //
            
        }
        // Guardar o actualizar dependiendo del parámetro de llamada a la pantalla
        protected void Guardar(object sender, EventArgs e)
        {
            var o = ColocarDatosEnObjeto();

            if (_EntidadId == -1)
                _EntidadControl._2Ins(o);
            else
                _EntidadControl._3Upd(o);

            string url = Globals.NavigateURL();
            if (this._Nivel != 0)
                url = string.Format("{0}/mid/{1}?popUp=true", Globals.NavigateURL("DetView"), ModuleContext.ModuleId);
            Response.Redirect(url);
        }
        // Cancela y regresa a la pantalla base
        protected void Cancelar(object sender, EventArgs e)
        {
            string url = Globals.NavigateURL();
            if (this._Nivel != 0)
                url = string.Format("{0}/mid/{1}?popUp=true", Globals.NavigateURL("DetView"), ModuleContext.ModuleId);
            Response.Redirect(url);
        }
        // Carga el formulario con los datos de un objeto
        protected void ColocarDatosEnFormulario()
        {
            if (_EntidadId == -1)
            {
                // Valores por defecto para el INSERT
                // Usar this.paginaEstadoMaster.Master_Id.ToString() para la clave foranea
                tbId.Text = "0";
                tbasoSocio_Id.Text = "0";
                tbasoInversion_Id.Text = this.paginaEstadoMaster.Master_Id.ToString();
                tbasoSocio_Nombre.Text = "";
            }
            else
            {
                // Consulta los datos de la entidad
                var o = _EntidadControl._1SelById(this._EntidadId);
                // Pone en los campos los valores del objeto
                tbId.Text = o.Id.ToString();
                tbasoSocio_Id.Text = o.asoSocio_Id.ToString();
                tbasoInversion_Id.Text = o.asoInversion_Id.ToString();
                tbasoSocio_Nombre.Text = o.asoSocio_Nombre;
            }
        }
        // Carga un objeto con los datos del formulario
        protected asoSocioInversion ColocarDatosEnObjeto()
        {
            var o = new asoSocioInversion();
            o.Id = _EntidadId;
            o.asoSocio_Id = Int32.Parse(tbasoSocio_Id.Text);
            o.asoInversion_Id = Int32.Parse(tbasoInversion_Id.Text);
            o.asoSocio_Nombre = tbasoSocio_Nombre.Text;

            return o;
        }
        //// Carga los estados desde una lista 
        //private void CargarDdl_Estados()
        //{
        //    asoSetimListaDetControl SetimLista = new asoSetimListaDetControl();
        //    var lista = SetimLista._0SelBy_asoSetimLista_Nombre("asoSocioInversion_Estado");
        //    lista.RemoveAt(0);
        //    ddlEstado.DataSource = lista;
        //    ddlEstado.DataTextField = "Texto";
        //    ddlEstado.DataValueField = "Valor";
        //    ddlEstado.DataBind();
        //}
        
        // Para el texto sugerido
        //protected void dnntsNombre_NodeClick(object sender, DNNTextSuggestEventArgs e)
        //{
        //    tbasoSocio_Nombre.Text = e.Text;
        //    tbasoSocio_Id.Text = e.Nodes.Count.ToString();
        //}
        // Para el texto sugerido
        //protected void dnntsNombre_PopulateOnDemand(object sender, DNNTextSuggestEventArgs e)
        //{
        //    DNNNode o;

        //    DataTable dt = new DataTable();
        //    //dt.Columns = new DataColumnCollection();
        //    dt.Columns.Add("id", typeof(Int32));
        //    dt.Columns.Add("name", typeof(String));
        //    //dt.Rows = new DataRowCollection();
        //    DataRow fila = dt.NewRow();
        //    fila["id"] = 1; fila["name"] = "A1";
        //    dt.Rows.Add(fila);
        //    fila = dt.NewRow();
        //    fila["id"] = 2; fila["name"] = "A2";
        //    dt.Rows.Add(fila);
        //    fila = dt.NewRow();
        //    fila["id"] = 3; fila["name"] = "A3";
        //    dt.Rows.Add(fila);

        //    string strText = e.Text.Replace("[", "").Replace("]", "").Replace("'", "''");

        //    dt.CaseSensitive = dnntsNombre.CaseSensitive;

        //    var res = dt.Select("name like '" + strText + "%'");

        //    foreach (var r in res)
        //    {
        //        if (dnntsNombre.MaxSuggestRows == 0 || e.Nodes.Count < dnntsNombre.MaxSuggestRows + 1)
        //        {
        //            o = new DNNNode((string)r["name"]);
        //            o.ID = r["id"].ToString();
        //            e.Nodes.Add(o);
        //        }
        //    }
        //}

        public string GetSociosActivosByPrefijo(string Prefijo)
        {
            asoSocioControl ctlSocio = new asoSocioControl();
            var lstSocios = ctlSocio._0SelByAll("ACT", "Users_Nombre", Prefijo, 0, 10, "Users_Nombre", "ASC");
            List<dato> lista = new List<dato>();
            foreach (var socio in lstSocios)
                lista.Add(new dato { valor = socio.Id.ToString(), etiqueta = socio.Users_Nombre, desc = socio.Estado });
            var json = JsonConvert.SerializeObject(lista);
            return json;
        }

        public void AjaxWrapper()
        {
            Response.Clear();
            string strData = "";
            try
            {
                MethodInfo mi = GetType().GetMethod(Request.Params["FUNCTION"]);
                object[] objs = new object[mi.GetParameters().Length];
                for (int i = 0; i < objs.Length; i++)
                {
                    objs[i] = (new PortalSecurity()).InputFilter(Request.Params["param" + i], PortalSecurity.FilterFlag.NoMarkup);
                }
                strData = mi.Invoke(this, objs).ToString();
            }
            catch (Exception ex)
            {
                strData = "{Error : Caught}";
                Exceptions.ProcessModuleLoadException(this, ex);
            }
            //
            Response.ContentType = "json";
            Response.Write(strData);
            Response.Flush();
            try { Response.End(); }
            catch { }
            return;
        }
    }

    [Serializable]
    public class dato 
    { 
        public string valor {get;set;}
        public string etiqueta {get;set;}
        public string desc {get;set;}
    }
}
