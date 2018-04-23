using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helpers
{
    public static class TokenGenerator
    {
        public static string GenerateToken()
        {
            char[] ret = new char[128];
            Random r = new Random();
            for(int i = 0; i < 128; i++)
            {
                ret[i] = (char)(r.Next(26) + 'a');
            }
            return new string(ret);
        }
    }
}
