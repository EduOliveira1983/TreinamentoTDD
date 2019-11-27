using static TreinamentoTDD.Dominio.Enums.Enums;

namespace TreinamentoTDD.Dominio.DTO
{
    public class CursoDTO
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public int cargaHoraria { get; set; }
        public PublicoAlvo publicoAlvo { get; set; }
        public decimal valor { get; set; }

    }
}
