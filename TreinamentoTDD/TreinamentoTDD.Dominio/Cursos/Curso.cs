using System;
using TreinamentoTDD.Dominio.Base;
using static TreinamentoTDD.Dominio.Enums.Enums;

namespace TreinamentoTDD.Dominio.Cursos
{
    public class Curso : Entidade
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

            if (publicoAlvo == PublicoAlvo.Professor)
                throw new ArgumentException("Publico Alvo Inválido");

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
