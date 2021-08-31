namespace Sigame.Api_REST.Models
{
    public class MPaqueteAsignado
    {
        private long paqueteId = 0;
        private string color = "";
        private string descripcion = "";
        private string origen = "";
        private string destino = "";
        private long asignacionId = 0;
        private int transporteId = 0;
        private int mensajeroId = 0;

        public long PaqueteId
        {
            get { return paqueteId; }
            set { paqueteId = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string Origen
        {
            get { return origen; }
            set { origen = value; }
        }
        public string Destino
        {
            get { return destino; }
            set { destino = value; }
        }
        public long AsignacionId
        {
            get { return asignacionId; }
            set { asignacionId = value; }
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