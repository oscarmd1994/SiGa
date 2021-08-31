namespace Sigame.Models
{
    public class MPrioridad
    {
        private int prioridadId = 0;
        private string prioridad = "";
        private string color = "";
        private bool estadoPrioridad = false;

        public int PrioridadId
        {
            get { return prioridadId; }
            set { prioridadId = value; }
        }
        public string Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public bool EstadoPrioridad
        {
            get { return estadoPrioridad; }
            set { estadoPrioridad = value; }
        }
    }
}