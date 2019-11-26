using TreimanetoTDD.Dominio.Testes.Cursos;

namespace TreimanetoTDD.Dominio.Testes.Builders
{
    /// <summary>
    /// Builder nada mais é do que um construtor do objeto, dessa forma, concentro toda a construção em um unico lugar    /// 
    /// </summary>
    public class CursoBuilder
    {
        #region Variaveis Internas
        private  string _nome = "Curso Teste";
        private  int _cargaHoraria = 40;
        private  PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;
        private  decimal _valor = 4000;
        private  string _descricao = "Descrição";
        #endregion

        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }

        public Curso Build()
        {
            return new Curso(_nome, _cargaHoraria, _publicoAlvo, _valor, _descricao);
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








    }
}
