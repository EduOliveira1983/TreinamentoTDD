namespace TreinamentoTDD.Util.CPF
{
    public static class CPFUtil
    {
        public static bool ValidarCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            return CpfLibrary.Cpf.Check(cpf);            
        }
    }
}
