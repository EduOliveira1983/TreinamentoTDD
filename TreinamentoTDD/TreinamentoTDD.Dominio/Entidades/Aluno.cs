using TreinamentoTDD.Dominio.Base;
using TreinamentoTDD.Dominio.Util;
using TreinamentoTDD.Util.CPF;
using TreinamentoTDD.Util.Email;
using static TreinamentoTDD.Dominio.Enums.Enums;

namespace TreinamentoTDD.Dominio.Entidades
{
    public class Aluno : Entidade
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }

        public Aluno(string nome, string cpf, string email, PublicoAlvo publicoAlvo)
        {

            ValidacaoDominio.Validar()
                    .Quando(string.IsNullOrEmpty(nome), MensagensValidacao.NomeInvalido)
                    .Quando(string.IsNullOrEmpty(cpf), MensagensValidacao.CPFInvalido)
                    .Quando(!CPFUtil.ValidarCPF(cpf), MensagensValidacao.CPFInvalido)
                    .Quando(string.IsNullOrEmpty(email), MensagensValidacao.EmailInvalido)
                    .Quando(!EmailUtil.ValidarFormatoEmail(email), MensagensValidacao.EmailInvalido)
                    .Quando(publicoAlvo == PublicoAlvo.Professor, MensagensValidacao.PublicoAlvoInvalido)
                    .ProcessarValidacao();

            Nome = nome;
            CPF = cpf;
            Email = email;
            PublicoAlvo = publicoAlvo;
        }

        public void AlterarNome(string nomeAlterado)
        {
            ValidacaoDominio.Validar()
                .Quando(string.IsNullOrEmpty(nomeAlterado), MensagensValidacao.NomeInvalido)
                .ProcessarValidacao();

            Nome = nomeAlterado;
        }


    }
}
