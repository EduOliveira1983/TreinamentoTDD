using static TreinamentoTDD.Dominio.Enums.Enums;

namespace TreinamentoTDD.Dominio.DTO
{
    public class AlunoDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public PublicoAlvo publicoAlvo { get; set; }
    }
}
