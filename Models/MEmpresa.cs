namespace Sigame.Models
{
    public class MEmpresa
    {
        private int empresaId = 0;
        private string empresa = "";
        private bool estadoEmpresa = false;

        public int EmpresaId
        {
            get { return empresaId; }
            set { empresaId = value; }
        }
        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        public bool EstadoEmpresa
        {
            get { return estadoEmpresa; }
            set { estadoEmpresa = value; }
        }
    }
}