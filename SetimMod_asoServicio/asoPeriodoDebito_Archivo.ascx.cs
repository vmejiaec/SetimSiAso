using System;
using DotNetNuke.Common;
using DotNetNuke.UI.Modules;
using DotNetNuke.Collections;
using SetimBasico;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Reflection;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.UI.Skins;
using DotNetNuke.Services.FileSystem;
using System.Data;

namespace SetimMod_asoServicio
{
    public partial class asoPeriodoDebito_Archivo : SetimModulo
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this._Nivel = 1;
            if (!IsPostBack)
            {
                // Obtiene el nombre del servicio
                asoServicioControl ctrServicio = new asoServicioControl();
                var oServicio = ctrServicio._1SelById((int)paginaEstadoMaster.Master_Id); 
                lbTitulo.Text = oServicio.Nombre;
            }
        }

        // Boton para leer el archivo que está seleccionado
        protected void btProcesarArchivo_OnClick(object sender, EventArgs e)
        {
            try
            {
                var x = fpArchivo.FilePath;
                var y = fpArchivo.FileID;                
                var z = FileManager.Instance.GetFile(y);

                string archivoExcel = z.PhysicalPath;

                string ConnectionString =string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=0\";", archivoExcel);
                System.Data.OleDb.OleDbConnection objConnection =
                    new System.Data.OleDb.OleDbConnection(ConnectionString);

                objConnection.Open();

                System.Data.OleDb.OleDbCommand objCommand = new System.Data.OleDb.OleDbCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandType = System.Data.CommandType.Text;
                objCommand.CommandText = "SELECT [CI], [Valor], [Descripcion] FROM [Debitos$];";

                DataTable dt = DotNetNuke.Common.Globals.ConvertDataReaderToDataTable(objCommand.ExecuteReader());
                objConnection.Close();

                int noDebitosProcesados = 0;
                int noDebitosError = 0;
                string infoError = "";

                // Parámetros para la carga
                //  Período actual
                asoParametroControl ctlParam = new asoParametroControl();
                var oParam = ctlParam._1SelById(1);
                int periodoActual_Id = oParam.asoPeriodo_Id_Actual;
                //  Servicio Id
                int servicio_Id = (int) paginaEstadoMaster.Master_Id;
                //  Porcentaje de la comisión para el servicio 
                asoServicioControl ctlServicio = new asoServicioControl();
                var oServicio = ctlServicio._1SelById(servicio_Id);
                decimal porcentajeComision = oServicio.Porcentaje_Comision;
                // Control para grabar los debitos
                asoPeriodoDebitoControl ctlPeriodoDebito = new asoPeriodoDebitoControl();
                // Control para consulta de usuarios
                asoSocioControl ctlSocio = new asoSocioControl();
                List<asoSocio> lstSocios = (List<asoSocio>) ctlSocio._0SelBy_asoServicio_Id_By_Prefijo(servicio_Id, "");
                // Si para el período actual existen débitos cargados, primero los borra.
                var lstDebitosActuales = ctlPeriodoDebito._0SelByasoServicio_Id(servicio_Id);
                foreach (var oDebActual in lstDebitosActuales)
                {
                    int resDel = ctlPeriodoDebito._4Del(oDebActual);
                }
                // Empieza el proceso del archivo
                foreach (DataRow dr in dt.Rows)
                {
                    asoPeriodoDebito oDebito = new asoPeriodoDebito();
                    // Obtiene los datos del registro
                    string sCI = dr["CI"].ToString();
                    decimal dValor = decimal.Parse(dr["Valor"].ToString());
                    string sDesc = dr["Descripcion"].ToString();
                    // Consulta el Id del usuario con el CI del archivo excel
                    var oSocio = lstSocios.Find(s => s.CI == sCI);
                    if (oSocio == null)
                    {
                        noDebitosError ++; //pasa la mano con 10, jeje
                        infoError += string.Format(" (*) El socio con CI: {0} no existe o no asignado. ",sCI);
                        continue;
                    }                    
                    // Carga los datos en el objeto debito
                    oDebito.asoPeriodo_Id = periodoActual_Id; //Período actual
                    oDebito.asoServicio_Id = servicio_Id;
                    oDebito.asoSocio_Id = oSocio.Id;
                    oDebito.Valor = dValor;
                    oDebito.Valor_Comision = Math.Round( dValor * porcentajeComision / 100, 2);
                    oDebito.Estado = "PEN";
                    oDebito.Descripcion = sDesc;
                    // Inserta en la tabla el débito
                    ctlPeriodoDebito._2Ins(oDebito);
                    noDebitosProcesados++;
                }

                paginaEstado.Avisos = string.Format("Debitos Procesados: {0}. Errores encontrados {1}. {2}", 
                    noDebitosProcesados, noDebitosError, infoError);
                Response.Redirect(Request.RawUrl, false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                const string headerText = "Error.";
                string messageText = string.Format("Hay error al generar los débitos de este servicio: {0} <br/> {1}", 
                    exc.Message, 
                    exc.InnerException ==null? "": exc.InnerException.Message);
                Skin.AddModuleMessage(this,
                    headerText,
                    messageText,
                    DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning);
            }
        }
        // Cierra la pantalla
        protected void Salir(object sender, EventArgs e)
        {
            string url = Globals.NavigateURL();
            if (this._Nivel != 0)
                url = string.Format("{0}/mid/{1}?popUp=true", Globals.NavigateURL("Det_ViewDebito"), ModuleContext.ModuleId);
            Response.Redirect(url);
        }
    }
}