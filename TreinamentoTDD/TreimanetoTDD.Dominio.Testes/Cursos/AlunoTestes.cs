using Bogus;
using ExpectedObjects;
using TreimanetoTDD.Dominio.Testes._Util;
using TreimanetoTDD.Dominio.Testes.Builders;
using TreinamentoTDD.Dominio.Entidades;
using TreinamentoTDD.Dominio.Util;
using Xunit;
using static TreinamentoTDD.Dominio.Enums.Enums;

namespace TreimanetoTDD.Dominio.Testes.Cursos
{
    public class AlunoTestes
    {
        private Faker faker;

        public AlunoTestes()
        {
            faker = new Faker();
        }
        [Fact]
        public void DeveCriarAluno()
        {
            var alunoEsperado = new
            {
                Nome = faker.Person.FullName.ToString(),
                CPF =  "22018291874",
                Email = faker.Person.Email.ToString(),
                PublicoAlvo = faker.PickRandomWithout(PublicoAlvo.Professor)
            };

            var aluno = new Aluno(alunoEsperado.Nome,
                                  alunoEsperado.CPF,
                                  alunoEsperado.Email,
                                  alunoEsperado.PublicoAlvo);

            alunoEsperado.ToExpectedObject().ShouldMatch(aluno);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        private void NaoDeveCriarAlunoNomeInvalido(string nome)
        {
            Assert.Throws<DominioException>(() => AlunoBuilder.Novo().ComNome(nome).Build())
                .ComMensagem(MensagensValidacao.NomeInvalido);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("1234")]
        private void NaoDeveCriarAlunoCPFInvalido(string cpf)
        {
            Assert.Throws<DominioException>(() => AlunoBuilder.Novo().ComCPF(cpf).Build())
                .ComMensagem(MensagensValidacao.CPFInvalido);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("email")]
        [InlineData("email@email")]
        [InlineData("email.com")]
        private void NaoDeveCriarAlunoEmailInvalido(string email)
        {
            Assert.Throws<DominioException>(() => AlunoBuilder.Novo().ComEmail(email).Build())
                .ComMensagem(MensagensValidacao.EmailInvalido);
        }

        [Fact]
        private void NaoDeveCriarAlunoPublicoAlvoInvalido()
        {
            Assert.Throws<DominioException>(() => AlunoBuilder.Novo().ComPublicoAlvo(PublicoAlvo.Professor).Build())
                .ComMensagem(MensagensValidacao.PublicoAlvoInvalido);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        private void NaoDeveAlterarAlunoNomeInvalido(string nome)
        {
            var aluno = AlunoBuilder.Novo().Build();
            Assert.Throws<DominioException>(() => aluno.AlterarNome(nome))
                .ComMensagem(MensagensValidacao.NomeInvalido);
        }



        
    }
}
