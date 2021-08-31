namespace Sigame.Models
{
    public class MRecorrido : MTransporte
    {
        private string mensajero = "";
        private string foto = "";
        private string lugarOrigen = "";
        private string lugarDestino = "";
        private string destinatario = "";
        private string latitud = "";
        private string longitud = "";
        private string imagen = "";

        public string Mensajero
        {
            get { return mensajero; }
            set { mensajero = value; }
        }
        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }
        public string LugarOrigen
        {
            get { return lugarOrigen; }
            set { lugarOrigen = value; }
        }
        public string LugarDestino
        {
            get { return lugarDestino; }
            set { lugarDestino = value; }
        }
        public string Destinatario
        {
            get { return destinatario; }
            set { destinatario = value; }
        }
        public string Latitud
        {
            get { return latitud; }
            set { latitud = value; }
        }
        public string Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }
        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
    }
}