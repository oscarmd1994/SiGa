namespace Sigame.Models
{
    public class MPaqueteria
    {
        private int paqueteriaId = 0;
        private string paqueteria = "";
        private bool estadoPaqueteria = false;

        public int PaqueteriaId
        {
            get { return paqueteriaId; }
            set { paqueteriaId = value; }
        }
        public string Paqueteria
        {
            get { return paqueteria; }
            set { paqueteria = value; }
        }
        public bool EstadoPaqueteria
        {
            get { return estadoPaqueteria; }
            set { estadoPaqueteria = value; }
        }
    }
}