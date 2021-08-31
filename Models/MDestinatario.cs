namespace Sigame.Models
{
    public class MDestinatario : MDireccion
    {
        private int destinatarioId = 0;
        private bool estadoDestinatario = false;
        private int empleadoId = 0;
        private int areaId = 0;
        private string area = "";

        private string nombre = "";
        private string empresa = "";
        private int empresaId = 0;

        public int DestinatarioId
        {
            get { return destinatarioId; }
            set { destinatarioId = value; }
        }
        public bool EstadoDestinatario
        {
            get { return estadoDestinatario; }
            set { estadoDestinatario = value; }
        }
        public int EmpleadoId
        {
            get { return empleadoId; }
            set { empleadoId = value; }
        }
        public int AreaId
        {
            get { return areaId; }
            set { areaId = value; }
        }
        public string Area
        {
            get { return area; }
            set { area = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        public int EmpresaId
        {
            get { return empresaId; }
            set { empresaId = value; }
        }
    }
}