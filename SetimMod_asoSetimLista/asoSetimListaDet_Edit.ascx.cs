﻿using System;
using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;
using SetimBasico;

namespace SetimMod_asoSetimListaDet
{
    public partial class asoSetimListaDet_Edit : ModuleUserControlBase
    {
        private int _UserID;
        private int _EntidadId;
        private int _EntidadPadreId;
        private readonly asoSetimListaDetControl _EntidadControl = new asoSetimListaDetControl();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _UserID = ModuleContext.PortalSettings.UserId;
            //Obtiene el identificador de la llamada
            _EntidadId = Request.QueryString.GetValueOrDefault("EntidadId", -1);
            _EntidadPadreId = Request.QueryString.GetValueOrDefault("EntidadPadreId", -1);
            //Verifica si debe cargar datos en el formulario
            if (!IsPostBack)
            {
                ColocarDatosEnFormulario();
            }
        }
        // Guardar o actualizar dependiendo del parámetro de llamada a la pantalla
        protected void Guardar(object sender, EventArgs e)
        {
            var o = ColocarDatosEnObjeto();

            if (_EntidadId == -1)
                _EntidadControl._2Ins(o);
            else
                _EntidadControl._3Upd(o);

            var url = Globals.NavigateURL("DetView", "EntidadId", _EntidadPadreId.ToString());
            url = string.Format("{0}/mid/{1}?popUp=true", url, ModuleContext.ModuleId);
            Response.Redirect(url);
        }
        // Cancela y regresa a la pantalla base
        protected void Cancelar(object sender, EventArgs e)
        {
            var url = Globals.NavigateURL("DetView","EntidadId",_EntidadPadreId.ToString());
            url = string.Format("{0}/mid/{1}?popUp=true", url, ModuleContext.ModuleId);
            Response.Redirect(url);
        }
        // Carga el formulario con los datos de un objeto
        protected void ColocarDatosEnFormulario()
        {
            if (_EntidadId == -1)
            {
                // Valores por defecto para el INSERT
                tbId.Text = "0";
                tbasoSetimLista_Id.Text = _EntidadPadreId.ToString();
                tbOrden.Text = "";
                tbTexto.Text = "Texto";
                tbValor.Text = "Valor";
            }
            else
            { 
                // Consulta los datos de la entidad para UPDATE
                var o = _EntidadControl._1SelById(_EntidadId);
                tbId.Text = o.Id.ToString();
                tbasoSetimLista_Id.Text = o.asoSetimLista_Id.ToString();
                tbOrden.Text = o.Orden.ToString();
                tbTexto.Text = o.Texto;
                tbValor.Text = o.Valor;
            }            
        }
        // Carga un objeto con los datos del formulario
        protected asoSetimListaDet ColocarDatosEnObjeto()
        {
            var o = new asoSetimListaDet();
            o.Id = _EntidadId;
            o.asoSetimLista_Id = Int32.Parse(tbasoSetimLista_Id.Text);
            o.Orden = Int32.Parse(tbOrden.Text);
            o.Texto = tbTexto.Text;
            o.Valor = tbValor.Text;

            return o;
        }

    }
}
