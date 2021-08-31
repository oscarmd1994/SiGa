namespace Sigame.Models
{
    public class MTipoTransporte
    {
        private int tipoTransporteId = 0;
        private string tipo = "";
        private bool estadoTipoTransporte = false;
        private string imagen = "";

        public int TipoTransporteId
        {
            get { return tipoTransporteId; }
            set { tipoTransporteId = value; }
        }
        public string Tipo {
            get { return tipo; }
            set { tipo = value; }
        }
        public bool EstadoTipoTransporte
        {
            get { return estadoTipoTransporte; }
            set { estadoTipoTransporte = value; }
        }
        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
    }
}