using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helpers
{
    public static class TokenGenerator
    {
        public static string GenerateToken(int length)
        {
            char[] ret = new char[length];
            Random r = new Random();
            for (int i = 0; i < length; i++)
            {
                ret[i] = (char)(r.Next(26) + 'a');
            }
            return new string(ret);
        }
    }
}
