using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace TreinamentoTDD.Dominio.Util
{
    public class ValidacaoDominio
    {
        private readonly List<string> _mensagensValidacao;

        private ValidacaoDominio()
        {
            _mensagensValidacao = new List<string>();
        }

        public static ValidacaoDominio Validar()
        {
            return new ValidacaoDominio();
        }

        public ValidacaoDominio Quando(bool condicao, string mensagem)
        {
            if (condicao)
                _mensagensValidacao.Add(mensagem);

            return this;
        }

        public void ProcessarValidacao()
        {
            string retorno = string.Empty;

            foreach (string mensagem in _mensagensValidacao)
            {
                retorno += $"{mensagem};";
            }
            if (!string.IsNullOrEmpty(retorno))
                throw new DominioException(retorno);
        }       

    }
}
