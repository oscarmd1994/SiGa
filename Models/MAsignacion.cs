namespace Sigame.Models
{
    public class MAsignacion
    {
        private long asignacionId = 0;
        private int mensajeroId = 0;
        private string fecha = "";
        private string hora = "";
        private int asignadorId = 0;

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
        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public string Hora
        {
            get { return hora; }
            set { hora = value; }
        }
        public int AsignadorId
        {
            get { return asignadorId; }
            set { asignadorId = value; }
        }
    }
}