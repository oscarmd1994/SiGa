namespace Sigame.Api_REST.Models
{
    public class MPaqueteRuta
    {
        private long asignacionId = 0;
        private long paqueteId = 0;
        private int mensajeroId = 0;
        private int transporteId = 0;
        private string marca = "";
        private string modelo = "";
        private string placa = "";
        private string descripcion = "";
        private string origen = "";
        private string destino = "";
        private string solicitante = "";
        private string destinatario = "";
        private string observacion = "";
        public int paquetes = 0;

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
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        public string Placa
        {
            get { return placa; }
            set { placa = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string Solicitante
        {
            get { return solicitante; }
            set { solicitante = value; }
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
        public string Destinatario
        {
            get { return destinatario; }
            set { destinatario = value; }
        }
        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }
        public int Paquetes
        {
            get { return paquetes; }
            set { paquetes = value; }
        }
    }
}