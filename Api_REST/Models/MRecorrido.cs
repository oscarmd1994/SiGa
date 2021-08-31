namespace Sigame.Api_REST.Models
{
    public class MRecorrido
    {
        private string fecha = "";
        private string hora = "";
        private string latitud = "";
        private string longitud = "";
        private long asignacionId = 0;
        private long paqueteId = 0;
        private int mensajeroId = 0;
        private int transporteId = 0;

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
        public string Latitud
        {
            get { return latitud; }
            set { latitud = value; }
        }
        public string Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }
        public long AsignacionId
        {
            get { return asignacionId; }
            set { asignacionId = value; }
        }
        public long PaqueteId
        {
            get { return paqueteId; }
            set { paqueteId = value; }
        }
        public int MensajeroId
        {
            get { return mensajeroId; }
            set { mensajeroId = value; }
        }
        public int TransporteId
        {
            get { return transporteId; }
            set { transporteId = value; }
        }
    }
}