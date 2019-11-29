using System.Text.RegularExpressions;

namespace TreinamentoTDD.Util.Email
{
    public static class EmailUtil
    {
        public static bool ValidarFormatoEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
