namespace Sigame.Models
{
    public class MArea
    {
        private int areaId = 0;
        private string area = "";
        private bool estadoArea = false;
        private int empresaId = 0;

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
        public bool EstadoArea
        {
            get { return estadoArea; }
            set { estadoArea = value; }
        }
        public int EmpresaId
        {
            get { return empresaId; }
            set { empresaId = value; }
        }
    }
}