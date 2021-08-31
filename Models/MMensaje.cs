namespace Sigame.Models
{
    public class MMensaje : MDireccionDestinatario
    {
        private long mensajeId = 0;
        private string folio = "";
        private string descripcion = "";
        private string observacion = "";
        private string fecha = "";
        private string hora = "";
        private bool estadoMensaje = false;
        private string direccionDestinatario = "";
        private string direccionSalida = "";
        private int usuarioId = 0;
        private int prioridadId = 0;
        private string nombre = "";
        private string foto = "";
        private string destinatario = "";
        private string color = "";
        private string estadoPaquete = "";
        private string acuse = "";

        public long MensajeId
        {
            get { return mensajeId; }
            set { mensajeId = value; }
        }
        public string Folio
        {
            get { return folio; }
            set { folio = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }
        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public string Hora
        {
            get { return hora; }
            set { hora = value; }
        }
        public bool EstadoMensaje
        {
            get { return estadoMensaje; }
            set { estadoMensaje = value; }
        }
        public string DireccionDestinatario
        {
            get { return direccionDestinatario; }
            set { direccionDestinatario = value; }
        }
        public string DireccionSalida
        {
            get { return direccionSalida; }
            set { direccionSalida = value; }
        }
        public int UsuarioId
        {
            get { return usuarioId; }
            set { usuarioId = value; }
        }
        public int PrioridadId
        {
            get { return prioridadId; }
            set { prioridadId = value; }
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
        public string Destinatario
        {
            get { return destinatario; }
            set { destinatario = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public string EstadoPaquete
        {
            get { return estadoPaquete; }
            set { estadoPaquete = value; }
        }
        public string Acuse
        {
            get { return acuse; }
            set { acuse = value; }
        }
    }
}