using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
using DotNetNuke.Services.Log.EventLog;
using DotNetNuke.Services.Exceptions;

using SetimBasico;

namespace SetimBasico
{
    ///<summary>
    ///Controladores para los procedimientos de asoAnio
    ///</summary>
    public partial class asoAnioControl
    {
        LogEventos _eventos = new LogEventos();
        public IList<asoAnio> _0Sel()
        {
            return CBO.FillCollection<asoAnio>(DataProvider.Instance().ExecuteReader(
                "sp_asoAnio_0Sel"

            ));
        }

    }
}
