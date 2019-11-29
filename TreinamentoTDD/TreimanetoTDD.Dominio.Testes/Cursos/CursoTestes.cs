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
    public class CursoTestes
    {
        Faker faker;

        public CursoTestes()
        {
            faker = new Faker();
        }
        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = faker.Name.ToString(),
                CargaHoraria = faker.Random.Int(5,100),
                PublicoAlvo = faker.PickRandomWithout(PublicoAlvo.Professor),
                Valor = faker.Random.Decimal(10,1000),
                Descricao = faker.Lorem.Paragraph()
            };

            var curso = new Curso(cursoEsperado.Nome,
                                  cursoEsperado.CargaHoraria,
                                  cursoEsperado.PublicoAlvo,
                                  cursoEsperado.Valor,
                                  cursoEsperado.Descricao);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeInvalido(string nome)
        {
            Assert.Throws<DominioException>(() => CursoBuilder.Novo().ComNome(nome).Build())
                .ComMensagem(MensagensValidacao.NomeInvalido);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveCurtoTerCargaHorariaMenorqueHum(int cargaHoraria)
        {
            Assert.Throws<DominioException>(() => CursoBuilder.Novo().ComCargaHoraria(cargaHoraria).Build())
                .ComMensagem(MensagensValidacao.CargaHorariaInvalida);
        }

        [Theory]
        [InlineData(-1)]
        public void NaoDeveCurtoTerValorMenorQueZero(decimal valor)
        {
            Assert.Throws<DominioException>(() => CursoBuilder.Novo().ComValor(valor).Build())
                .ComMensagem(MensagensValidacao.ValorInvalido);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerDescricaoInvalida(string descricao)
        {
            Assert.Throws<DominioException>(() => CursoBuilder.Novo().ComDescricao(descricao).Build())
               .ComMensagem(MensagensValidacao.DescricaoInvalida);
        }

        [Fact]
        public void NaoDeveCursoTerPublicoAlvoInvalido()
        {
            Assert.Throws<DominioException>(() => CursoBuilder.Novo().ComPublicoAlvo(PublicoAlvo.Professor).Build())
                .ComMensagem(MensagensValidacao.PublicoAlvoInvalido);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveAlterarCursoComNomeInvalido(string nomeInvalido)
        {
            var curso = CursoBuilder.Novo().Build();

            Assert.Throws<DominioException>(() => curso.AlterarNome(nomeInvalido))
                .ComMensagem(MensagensValidacao.NomeInvalido);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveAlterarCursoComDescricaoInvalida(string descricaoInvalida)
        {
            var curso = CursoBuilder.Novo().Build();

            Assert.Throws<DominioException>(() => curso.AlterarDescricao(descricaoInvalida))
                .ComMensagem(MensagensValidacao.DescricaoInvalida);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveAlterarCursoCargaHorariaInvalida(int cargaHorariaInvalida)
        {
            var curso = CursoBuilder.Novo().Build();

            Assert.Throws<DominioException>(() => curso.AlterarCargaHoraria(cargaHorariaInvalida))
                .ComMensagem(MensagensValidacao.CargaHorariaInvalida);
        }

        [Theory]        
        [InlineData(-1)]
        public void NaoDeveAlterarCursoValorInvalido(decimal valorInvalido)
        {
            var curso = CursoBuilder.Novo().Build();

            Assert.Throws<DominioException>(() => curso.AlterarValor(valorInvalido))
                .ComMensagem(MensagensValidacao.ValorInvalido);
        }

        [Theory]
        [InlineData(PublicoAlvo.Professor)]
        
        public void NaoDeveAlterarCursoPublicoAlvoInvalido(PublicoAlvo publicoAlvoInvalido)
        {
            var curso = CursoBuilder.Novo().Build();

            Assert.Throws<DominioException>(() => curso.AlterarPublicoAlvo(publicoAlvoInvalido))
                .ComMensagem(MensagensValidacao.PublicoAlvoInvalido);
        }

    }
}
