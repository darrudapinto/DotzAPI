using DotzAPI.Enums;

namespace DotzAPI.Modelos
{
    public class PontoDotz
    {
        public int PontoDotzId { get; set; }
        public int Quantidade { get; set; }
        public string EmpresaGeradora { get; set; }
        public TipoOperacao TipoOperacao { get; set; }
                
        public Usuario Usuario { get; set; }
    }
}
