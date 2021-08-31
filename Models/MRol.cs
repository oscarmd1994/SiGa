namespace Sigame.Models
{
    public class MRol
    {
        private int rolId = 0;
        private string rol = "";
        private bool estadoRol = false;

        public int RolId
        {
            get { return rolId; }
            set { rolId = value; }
        }
        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }
        public bool EstadoRol
        {
            get { return estadoRol; }
            set { estadoRol = value; }
        }
    }
}