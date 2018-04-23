using BussinessContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BussinessContracts
{
    public static class PasswordHasher
    {
        public static string HashString(string s)
        {
            var v = new SHA256Cng();
            return v.ComputeHash(s.Select(x => (byte)x).ToArray()).Aggregate("", (accum, x) => x.ToString("X2") + accum);
        }
    }
}
