using System;
using TreinamentoTDD.Dominio.Util;
using Xunit;
using static TreinamentoTDD.Dominio.Util.ValidacaoDominio;

namespace TreimanetoTDD.Dominio.Testes._Util
{
    public static class AssertExtension
    {
        public static void ComMensagem(this DominioException exception, string mensagem)
        {
            if (exception.Message.Contains(mensagem))
                Assert.True(true);
            else
                Assert.False(true);
        }
    }
}
