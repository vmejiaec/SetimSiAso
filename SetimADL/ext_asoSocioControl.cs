using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetimBasico
{
    /// <summary>
    /// Completa las funciones de la clase generada automáticamente
    /// </summary>
    public partial class asoSocioControl
    {
        public IList<asoSocio> _0SelByAll(string estado, string campo, object valor, Int32 PageIndex, Int32 PageSize, String SortField, String SortDirection)
        {
            IList<asoSocio> res = new List<asoSocio>();
            switch (campo)
            {
                case "UserID":
                    res = _0SelByAll(
                        UserID: (Int32?)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "CI":
                    res = _0SelByAll(
                        CI: (String)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Descripcion":
                    res = _0SelByAll(
                        Descripcion: "%"+ (String)valor + "%",
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Fecha_Nacimiento":
                    res = _0SelByAll(
                        Fecha_Nacimiento: (DateTime?)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Users_EMail":
                    res = _0SelByAll(
                        Users_EMail: (String)valor,
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                case "Users_Nombre":
                    res = _0SelByAll(
                        Users_Nombre: "%"+ (String)valor + "%",
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
                default:
                    res = _0SelByAll(
                        Estado: estado,
                        PageIndex: PageIndex, PageSize: PageSize, SortField: SortField, SortDirection: SortDirection);
                    break;
            }
            return res;
        }
    }
}
