namespace Sigame.Models
{
    public class MEmpleado
    {
        private int empleadoId = 0;
        private string nombre = "";
        private string apellidoPaterno = "";
        private string apellidoMaterno = "";
        private bool estadoEmpleado = false;

        public int EmpleadoId
        {
            get { return empleadoId; }
            set { empleadoId = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string ApellidoPaterno
        {
            get { return apellidoPaterno; }
            set { apellidoPaterno = value; }
        }
        public string ApellidoMaterno
        {
            get { return apellidoMaterno; }
            set { apellidoMaterno = value; }
        }
        public bool EstadoEmpleado
        {
            get { return estadoEmpleado; }
            set { estadoEmpleado = value; }
        }
    }
}