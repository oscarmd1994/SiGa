using System.Web;

namespace Sigame.Utilities
{
    public static class Sesion
    {
        private static string vistaAnterior = "";
        public static int UsuarioId
        {
            get
            {
                object usuarioId = HttpContext.Current.Session["UsuarioId"];
                return usuarioId == null ? 0 : (int)usuarioId;
            }
            set
            {
                HttpContext.Current.Session["UsuarioId"] = value;
            }
        }
        public static int AreaId
        {
            get
            {
                object areaId = HttpContext.Current.Session["AreaId"];
                return areaId == null ? 0 : (int)areaId;
            }
            set
            {
                HttpContext.Current.Session["EmpresaId"] = value;
            }
        }
        public static int RolId
        {
            get
            {
                object rolId = HttpContext.Current.Session["RolId"];
                return rolId == null ? 0 : (int)rolId;
            }
            set
            {
                HttpContext.Current.Session["RolId"] = value;
            }
        }
        public static string Rol
        {
            get
            {
                object rol = HttpContext.Current.Session["Rol"];
                return rol == null ? "" : (string)rol;
            }
            set
            {
                HttpContext.Current.Session["Rol"] = value;
            }
        }


        public static string VistaAnterior
        {
            get { return vistaAnterior; }
            set { vistaAnterior = value; }
        }

        public const bool Almacenar = true;
        public const int Duracion = 0;
        public const string VariarPorParametro = "None";
        public const string Permiso = "Estimado usuario usted no tiene persmisos para esta acción";

        public static void Abandonar()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Abandon();
        }
    }
}