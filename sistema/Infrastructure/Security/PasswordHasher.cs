using System;
using System.Security.Cryptography;

namespace sistema.Infrastructure.Security
{
    public static class PasswordHasher
    {
        // Formato: PBKDF2$iteraciones$saltBase64$hashBase64
        public static string HashPBKDF2(string password, int iterations = 10000, int saltSize = 16, int hashSize = 32)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var salt = new byte[saltSize];
                rng.GetBytes(salt);

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
                {
                    var hash = pbkdf2.GetBytes(hashSize);
                    return $"PBKDF2${iterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
                }
            }
        }

        public static bool VerifyPBKDF2(string password, string stored)
        {
            if (string.IsNullOrWhiteSpace(stored)) return false;
            var parts = stored.Split('$');
            if (parts.Length != 4 || parts[0] != "PBKDF2") return false;

            int iterations = int.Parse(parts[1]);
            var salt = Convert.FromBase64String(parts[2]);
            var expected = Convert.FromBase64String(parts[3]);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                var actual = pbkdf2.GetBytes(expected.Length);
                return FixedTimeEquals(actual, expected);
            }
        }

        // Comparación en tiempo constante (evita cortocircuitos para mitigar timing attacks)
        private static bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null) return false;
            if (a.Length != b.Length) return false;

            int diff = 0;
            for (int i = 0; i < a.Length; i++)
                diff |= a[i] ^ b[i];
            return diff == 0;
        }
    }
}