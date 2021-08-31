namespace Sigame.Api_REST.Models
{
    public class MTransporte
    {
        private string marca = "";
        private string placa = "";
        private string modelo = "";
        private string poliza = "";
        private string vigencia = "";
        private string anio = "";
        private string foto = "";

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public string Placa
        {
            get { return placa; }
            set { placa = value; }
        }
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
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
        public string Anio
        {
            get { return anio; }
            set { anio = value; }
        }
        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }
    }
}