namespace Sigame.Api_REST.Models
{
    public class MPaqueteHistorial
    {
        private string descripcion = "";
        private string origen = "";
        private string destino;
        private string color = "";
        
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
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}