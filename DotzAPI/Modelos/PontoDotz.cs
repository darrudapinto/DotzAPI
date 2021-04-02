using DotzAPI.Enums;

namespace DotzAPI.Modelos
{
    public class PontoDotz
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public string EmpresaGeradora { get; set; }
        public TipoOperacao TipoOperacao { get; set; }
    }
}
