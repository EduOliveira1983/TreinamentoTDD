using TreinamentoTDD.Dominio.Base;
using TreinamentoTDD.Dominio.Util;
using static TreinamentoTDD.Dominio.Enums.Enums;

namespace TreinamentoTDD.Dominio.Entidades
{
    public class Curso : Entidade
    {
        public string Nome { get; private set; }
        public int CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public decimal Valor { get; private set; }
        public string Descricao { get; private set; }
        
        public Curso(string nome, int cargaHoraria, PublicoAlvo publicoAlvo, decimal valor, string descricao)
        {
            ValidacaoDominio.Validar()
                 .Quando(string.IsNullOrEmpty(nome), MensagensValidacao.NomeInvalido)
                 .Quando(string.IsNullOrEmpty(descricao), MensagensValidacao.DescricaoInvalida)
                 .Quando(cargaHoraria < 1, MensagensValidacao.CargaHorariaInvalida)
                 .Quando(valor < 0, MensagensValidacao.ValorInvalido)
                 .Quando(publicoAlvo == PublicoAlvo.Professor, MensagensValidacao.PublicoAlvoInvalido)
                 .ProcessarValidacao();

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
            Descricao = descricao;            
        }

        public void AlterarNome(string nomeAlterado)
        {
            ValidacaoDominio.Validar()
                .Quando(string.IsNullOrEmpty(nomeAlterado), MensagensValidacao.NomeInvalido)
                .ProcessarValidacao();

            Nome = nomeAlterado;           
        }

        public void AlterarDescricao(string descricaoAlterada)
        {
            ValidacaoDominio.Validar()
                .Quando(string.IsNullOrEmpty(descricaoAlterada), MensagensValidacao.DescricaoInvalida)
                .ProcessarValidacao();

            Descricao = descricaoAlterada;
        }

        public void AlterarCargaHoraria(int cargaHorariaAlterada)
        {
            ValidacaoDominio.Validar()
                .Quando(cargaHorariaAlterada < 1, MensagensValidacao.CargaHorariaInvalida)
                .ProcessarValidacao();

            CargaHoraria = cargaHorariaAlterada;                
        }

        public void AlterarValor(decimal valorAlterado)
        {
            ValidacaoDominio.Validar()
                .Quando(valorAlterado < 0, MensagensValidacao.ValorInvalido)
                .ProcessarValidacao();

            Valor = valorAlterado;           
        }

        public void AlterarPublicoAlvo(PublicoAlvo publicoAlvoAlterado)
        {
            ValidacaoDominio.Validar()
                .Quando(publicoAlvoAlterado == PublicoAlvo.Professor, MensagensValidacao.PublicoAlvoInvalido)
                .ProcessarValidacao();

            PublicoAlvo = publicoAlvoAlterado;
        }
    }
}
