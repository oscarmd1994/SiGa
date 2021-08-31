namespace Sigame.Models
{
    public class MUsuario : MEmpleado
    {

        private int usuarioId = 0;
        private string fechaNacimiento = "";
        private string usuario = "";
        private string contrasenia = "";
        private string foto = "";
        private bool estadoUsuario = false;
        private int areaId = 0;
        private string respuesta = "";

        private int empresaId = 0;
        private int rolId = 0;
        private string rol = "";
        private string empresa = "";
        public string area = "";

        public int UsuarioId
        {
            get { return usuarioId; }
            set { usuarioId = value; }
        }
        public string FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string Contrasenia
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }
        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }
        public bool EstadoUsuario
        {
            get { return estadoUsuario; }
            set { estadoUsuario = value; }
        }
        public int AreaId
        {
            get { return areaId; }
            set { areaId = value; }
        }
        public string Respuesta
        {
            get { return respuesta; }
            set { respuesta = value; }
        }
        public int EmpresaId
        {
            get { return empresaId; }
            set { empresaId = value; }
        }
        public int RolId
        {
            get { return rolId; }
            set { rolId = value; }
        }
        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }
        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        public string Area
        {
            get { return area; }
            set { area = value; }
        }
    }
}