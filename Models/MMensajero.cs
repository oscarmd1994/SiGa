namespace Sigame.Models
{
    public class MMensajero
    {
        private int mensajeroId = 0;
        private string estadoMensajero = "";
        private int usuarioId = 0;
        private string nombre = "";
        private string foto = "";

        public int MensajeroId
        {
            get { return mensajeroId; }
            set { mensajeroId = value; }
        }
        public string EstadoMensajero
        {
            get { return estadoMensajero; }
            set { estadoMensajero = value; }
        }
        public int UsuarioId
        {
            get { return usuarioId; }
            set { usuarioId = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }
    }
}