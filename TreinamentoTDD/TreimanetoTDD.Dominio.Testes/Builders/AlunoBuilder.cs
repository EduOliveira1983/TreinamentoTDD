using System;
using TreinamentoTDD.Dominio.Entidades;
using static TreinamentoTDD.Dominio.Enums.Enums;

namespace TreimanetoTDD.Dominio.Testes.Builders
{
    public class AlunoBuilder
    {
        private string _nome = "Eduardo Oliveira";
        private string _cpf = "22018291874";
        private string _email = "eduardooliveira_jr@hotmail.com";
        private PublicoAlvo _publicoAlvo = PublicoAlvo.Universitario;
        private int _id;

        public static AlunoBuilder Novo()
        {
            return new AlunoBuilder();
        }

        public Aluno Build()
        {
            var aluno = new Aluno(_nome, _cpf, _email, _publicoAlvo);

            if (_id > 0)
            {
                var propertyinfo = aluno.GetType().GetProperty("Id");
                propertyinfo.SetValue(aluno, Convert.ChangeType(_id,propertyinfo.PropertyType),null);
            }

            return aluno;
        }

        public AlunoBuilder ComId(int id)
        {
            _id = id;
            return this;
        }

        public AlunoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public AlunoBuilder ComCPF(string cpf)
        {
            _cpf = cpf;
            return this;
        }

        public AlunoBuilder ComEmail(string email)
        {
            _email = email;
            return this;
        }

        public AlunoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }
    }
}
