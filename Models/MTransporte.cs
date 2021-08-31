namespace Sigame.Models
{
    public class MTransporte: MTipoTransporte
    {
        private int transporteId = 0;
        private string placa = "";
        private string marca = "";
        private string modelo = "";
        private string anio = "";
        private string fecha = "";
        private bool estadoTransporte = false;
        private string disponibilidad = "";
        private string poliza = "";
        private string vigencia = "";

        public int TransporteId
        {
            get { return transporteId; }
            set { transporteId = value; }
        }
        public string Placa
        {
            get { return placa; }
            set { placa = value; }
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
        public string Anio
        {
            get { return anio; }
            set { anio = value; }
        }
        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public bool EstadoTransporte
        {
            get { return estadoTransporte; }
            set { estadoTransporte = value; }
        }
        public string Disponibilidad
        {
            get { return disponibilidad; }
            set { disponibilidad = value; }
        }
        public string Poliza
        {
            get { return poliza; }
            set { poliza = value; }
        }
        public string Vigencia
        {
            get { return vigencia; }
            set { vigencia = value; }
        }
    }
}