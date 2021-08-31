namespace Sigame.Models
{
    public class MEnvio : MPrioridad
    {
        private long envioId = 0;
        private string folio = "";
        private string descripcion = "";
        private string fechaSolicitud = "";
        private string horaSolicitud = "";
        private string fechaEntrega = "";
        private string horaEntrega = "";
        private string observacion = "";
        private string estadoEnvio = "";
        private string destinatario = "";
        private int destinatarioId = 0;
        private int usuarioId = 0;
        private string paqueteria = "";
        private int paqueteriaId = 0;

        public long EnvioId{
            get { return envioId; }
            set { envioId = value; }
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
        public string FechaSolicitud
        {
            get { return fechaSolicitud; }
            set { fechaSolicitud = value; }
        }
        public string HoraSolicitud
        {
            get { return horaSolicitud; }
            set { horaSolicitud = value; }
        }
        public string FechaEntrega
        {
            get { return fechaEntrega; }
            set { fechaEntrega = value; }
        }
        public string HoraEntrega
        {
            get { return horaEntrega; }
            set { horaEntrega = value; }
        }
        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }
        public string EstadoEnvio
        {
            get { return estadoEnvio; }
            set { estadoEnvio = value; }
        }
        public int DestinatarioId
        {
            get { return destinatarioId; }
            set { destinatarioId = value; }
        }
        public int UsuarioId
        {
            get { return usuarioId; }
            set { usuarioId = value; }
        }
        public string Destinatario
        {
            get { return destinatario; }
            set { destinatario = value; }
        }
        public string Paqueteria
        {
            get { return paqueteria; }
            set { paqueteria = value; }
        }
        public int PaqueteriaId
        {
            get { return paqueteriaId; }
            set { paqueteriaId = value; }
        }
    }
}