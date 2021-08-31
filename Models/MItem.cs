namespace Sigame.Models
{
    public class MItem
    {
        private int itemId = 0;
        private string item = "";
        private string icono = "";
        private string url = "";
        private int nivel = 0;
        private bool estadoItem = false;
        private int parent = 0;
        private int rolId = 0;

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }
        public string Item
        {
            get { return item; }
            set { item = value; }
        }
        public string Icono
        {
            get { return icono; }
            set { icono = value; }
        }
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }
        public bool EstadoItem
        {
            get { return estadoItem; }
            set { estadoItem = value; }
        }
        public int Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        public int RolId
        {
            get { return rolId; }
            set { rolId = value; }
        }
    }
}