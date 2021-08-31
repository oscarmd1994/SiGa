namespace Sigame.Api_REST.Models
{
    public class MMensajero
    {
        private int mensajeroId = 0;
        private string area = "";
        private string empresa = "";
        private string rol = "";
        private string mensajero = "";
        private string fechaNacimiento = "";
        private string respuesta = "";
        private string usuario = "";
        private string foto = "";
        private string nombre = "";
        private string apellidoPaterno = "";
        private string apellidoMaterno = "";

        public int MensajeroId
        {
            get { return mensajeroId; }
            set { mensajeroId = value; }
        }
        public string Area
        {
            get { return area; }
            set { area = value; }
        }
        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }
        public string Respuesta
        {
            get { return respuesta; }
            set { respuesta = value; }
        }
        public string FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
        public string Mensajero
        {
            get { return mensajero; }
            set { mensajero = value; }
        }
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string ApellidoPaterno
        {
            get { return apellidoPaterno; }
            set { apellidoPaterno = value; }
        }
        public string ApellidoMaterno
        {
            get { return apellidoMaterno; }
            set { apellidoMaterno = value; }
        }
    }
}