using Bogus;
using System;
using TreimanetoTDD.Dominio.Testes.Cursos;
using TreinamentoTDD.Dominio.Entidades;
using static TreinamentoTDD.Dominio.Enums.Enums;

namespace TreimanetoTDD.Dominio.Testes.Builders
{
    /// <summary>
    /// Builder nada mais é do que um construtor do objeto, dessa forma, concentro toda a construção em um unico lugar 
    /// </summary>
    public class CursoBuilder
    {
        #region Variaveis Internas


        public int _id;
        public string _nome = "Curso Teste";
        public int _cargaHoraria = (int)40;
        public PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;
        public decimal _valor = 2000;
        public string _descricao = "Descrição Teste";

        #endregion

        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }

        public Curso Build()
        {
            var curso = new Curso(_nome, _cargaHoraria, _publicoAlvo, _valor, _descricao);

            if (_id > 0)
            {
                var propertyInfo = curso.GetType().GetProperty("Id");
                propertyInfo.SetValue(curso, Convert.ChangeType(_id, propertyInfo.PropertyType), null);
            }

            return curso;
        }

        public CursoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }
        public CursoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public CursoBuilder ComCargaHoraria(int cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }

        public CursoBuilder ComValor(decimal valor)
        {
            _valor = valor;
            return this;
        }

        public CursoBuilder ComId(int id)
        {
            _id = id;
            return this;
        }
    }
}
