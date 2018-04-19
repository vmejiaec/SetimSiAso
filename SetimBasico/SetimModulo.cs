using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetNuke.Entities.Users;
using DotNetNuke.UI.Modules;

namespace SetimBasico
{
    public class SetimModulo : ModuleUserControlBase
    {
        public int _UserID;
        public int _EntidadId;
        public int _ModuleId;
        // Nivel de la relación 0-Master0 1-Master1 2-Master2
        public int _Nivel = 0;
        // Campo por defecto para ordenar la lista
        public string _Ordenar_Campo_Defaul = "Id";
        // Obtiene el nombre del usuario
        public string _Usuario_Nombre {
            get
            {
                    UserInfo _currentUser = UserController.Instance.GetCurrentUserInfo();
                    string Usuario_Nombre = string.Format("{0} {1}", _currentUser.FirstName, _currentUser.LastName);
                    return Usuario_Nombre;
            }
        }
        // Verifica si tiene permiso de edición por medio del rol RolSetimEditar
        public bool _Usuario_RolSetimEditar
        {
            get {
                UserInfo _currentUser = UserController.Instance.GetCurrentUserInfo();
                return _currentUser.IsInRole("RolSetimEditar");
            }
        }
        // Estado de la páginas
        public ListaPaginaEstado listaPaginaEstado
        {
            get
            {
                if (Session["paginaEstado"] == null) Session["paginaEstado"] = new ListaPaginaEstado();
                return (ListaPaginaEstado)Session["paginaEstado"];
            }
            set
            {
                Session["paginaEstado"] = value;
            }
        }
        // Es la página actual
        public PaginaEstado paginaEstado
        {
            get
            {
                return listaPaginaEstado.p[_Nivel];
            }
            set
            {
                listaPaginaEstado.p[_Nivel] = value;
            }
        }
        // Es la página anterior
        public PaginaEstado paginaEstadoMaster
        {
            get
            {
                return listaPaginaEstado.p[_Nivel - 1];
            }
            set
            {
                listaPaginaEstado.p[_Nivel - 1] = value;
            }
        }
    }
}
