using ExpectedObjects;
using System;
using TreimanetoTDD.Dominio.Testes._Util;
using Xunit;

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
                Valor = (decimal)4000
            };

            var curso = new Curso(cursoEsperado.Nome,
                                  cursoEsperado.CargaHoraria,
                                  cursoEsperado.PublicoAlvo,
                                  cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeInvalido(string nome)
        {
            var cursoEsperado = new
            {
                Nome = nome,
                CargaHoraria = (int)40,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (decimal)4000
            };

            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome,
                                                             cursoEsperado.CargaHoraria,
                                                             cursoEsperado.PublicoAlvo,
                                                             cursoEsperado.Valor)).ComMensagem("Nome Inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveCurtoTerCargaHorariaMenorqueHum(int cargaHoraria)
        {
            var cursoEsperado = new
            {
                Nome = "Curso Teste",
                CargaHoraria = cargaHoraria,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (decimal)4000
            };

            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome,
                                                             cursoEsperado.CargaHoraria,
                                                             cursoEsperado.PublicoAlvo,
                                                             cursoEsperado.Valor)).ComMensagem("Carga Horária Inválida");

        }

        [Theory]
        [InlineData(-1)]
        public void NaoDeveCurtoTerValorMenorQueZero(decimal Valor)
        {
            var cursoEsperado = new
            {
                Nome = "Curso Teste",
                CargaHoraria = (int)40,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = Valor
            };

            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome,
                                                             cursoEsperado.CargaHoraria,
                                                             cursoEsperado.PublicoAlvo,
                                                             cursoEsperado.Valor)).ComMensagem("Valor Inválido");
        }
    }

    public enum PublicoAlvo
    {
        Estudante,
        Universitario,
        Empregado,
        Empreendedor
    }

    public class Curso
    {
        public Curso(string nome, int cargaHoraria, PublicoAlvo publicoAlvo, decimal valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome Inválido");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga Horária Inválida");

            if (valor < 0)
                throw new ArgumentException("Valor Inválido");

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public int CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public decimal Valor { get; private set; }
    }
}
