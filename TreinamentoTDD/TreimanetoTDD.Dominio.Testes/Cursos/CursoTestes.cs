using ExpectedObjects;
using System;
using TreimanetoTDD.Dominio.Testes._Util;
using TreimanetoTDD.Dominio.Testes.Builders;
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
                Valor = (decimal)4000,
                Descricao = "Descricao Teste"
            };

            var curso = new Curso(cursoEsperado.Nome,
                                  cursoEsperado.CargaHoraria,
                                  cursoEsperado.PublicoAlvo,
                                  cursoEsperado.Valor,
                                  cursoEsperado.Descricao );

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

        [Fact]
        public void NaoDeveCursoTerDescricaoInvalida()
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComDescricao(null).Build())
               .ComMensagem("Descrição Inválida");
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
        public Curso(string nome, int cargaHoraria, PublicoAlvo publicoAlvo, decimal valor, string descricao)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome Inválido");

            if (string.IsNullOrEmpty(descricao))
                throw new ArgumentException("Descrição Inválida");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga Horária Inválida");

            if (valor < 0)
                throw new ArgumentException("Valor Inválido");

            

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
