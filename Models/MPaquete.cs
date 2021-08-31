namespace Sigame.Models
{
    public class MPaquete : MAsignacion
    {
        private long paqueteId = 0;
        private string mensajesId = "";
        private string estadoPaquete = "";
        private string mensajero = "";
        private string paquetes = "";
        private int transporteId = 0;

        public long PaqueteId
        {
            get { return paqueteId; }
            set { paqueteId = value; }
        }
        public string MensajesId
        {
            get { return mensajesId; }
            set { mensajesId = value; }
        }
        public string EstadoPaquete
        {
            get { return estadoPaquete; }
            set { estadoPaquete = value; }
        }
        public string Mensajero
        {
            get { return mensajero; }
            set { mensajero = value; }
        }
        public string Paquetes
        {
            get { return paquetes; }
            set { paquetes = value; }
        }
        public int TransporteId
        {
            get { return transporteId; }
            set { transporteId = value; }
        }
    }
}