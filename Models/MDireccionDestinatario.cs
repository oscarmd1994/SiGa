namespace Sigame.Models
{
    public class MDireccionDestinatario : MDireccion
    {
        private long direccionDestinatarioId = 0;
        private int destinatarioId = 0;

        public long DireccionDestinatarioId
        {
            get { return direccionDestinatarioId; }
            set { direccionDestinatarioId = value; }
        }
        public int DestinatarioId
        {
            get { return destinatarioId; }
            set { destinatarioId = value; }
        }
    }
}