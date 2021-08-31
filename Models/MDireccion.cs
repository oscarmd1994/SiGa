namespace Sigame.Models
{
    public class MDireccion
    {
        private long direccionId = 0;
        private string direccion = "";

        public long DireccionId
        {
            get { return direccionId; }
            set { direccionId = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
    }
}