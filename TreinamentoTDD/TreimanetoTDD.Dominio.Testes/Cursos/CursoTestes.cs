using ExpectedObjects;
using System;
using TreimanetoTDD.Dominio.Testes._Util;
using TreimanetoTDD.Dominio.Testes.Builders;
using TreinamentoTDD.Dominio.Cursos;
using Xunit;
using static TreinamentoTDD.Dominio.Enums.Enums;

namespace TreimanetoTDD.Dominio.Testes.Cursos
{
    public class CursoTestes
    {
        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = "Curso Teste",
                CargaHoraria = (int)40,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (decimal)4000,
                Descricao = "Descricao Teste"
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
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComNome(nome).Build())
                .ComMensagem("Nome Inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveCurtoTerCargaHorariaMenorqueHum(int cargaHoraria)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComCargaHoraria(cargaHoraria).Build())
                .ComMensagem("Carga Horária Inválida");
        }

        [Theory]
        [InlineData(-1)]
        public void NaoDeveCurtoTerValorMenorQueZero(decimal valor)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComValor(valor).Build())
                .ComMensagem("Valor Inválido");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerDescricaoInvalida(string descricao)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComDescricao(descricao).Build())
               .ComMensagem("Descrição Inválida");
        }

        [Fact]
        public void NaoDeveCursoTerPublicoAlvoInvalido()
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComPublicoAlvo(PublicoAlvo.Professor).Build())
                .ComMensagem("Publico Alvo Inválido");
        }


    }
}
