using TreinamentoTDD.Dominio.Base;
using TreinamentoTDD.Dominio.Util;
using static TreinamentoTDD.Dominio.Enums.Enums;

namespace TreinamentoTDD.Dominio.Cursos
{
    public class Curso : Entidade
    {
        public Curso(string nome, int cargaHoraria, PublicoAlvo publicoAlvo, decimal valor, string descricao)
        {
            ValidacaoDominio.Validar()
                .Quando(string.IsNullOrEmpty(nome), MensagensErro.NomeInvalido)
                .Quando(string.IsNullOrEmpty(descricao), MensagensErro.DescricaoInvalida)
                .Quando(cargaHoraria < 1, MensagensErro.CargaHorariaInvalida)
                .Quando(valor < 0, MensagensErro.ValorInvalido)
                .Quando(publicoAlvo == PublicoAlvo.Professor, MensagensErro.PublicoAlvoInvalido)
                .DispararValidacao();

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
            Descricao = descricao;
        }

        public string Nome { get; private set; }
        public int CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public decimal Valor { get; private set; }
        public string Descricao { get; private set; }

    }
}
