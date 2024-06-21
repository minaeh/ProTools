using Newtonsoft.Json;
using System;
using System.IO;

namespace ProTools.Cipher
{
    public static class ReadCipher
    {
        public static string ReadEnecryptFile(string fullPath, string cipherKey,out string encryptContent)
        {
            if (fullPath == null)
            {
                throw new ArgumentNullException(nameof(fullPath), "File path is null");
            }
            if (File.Exists(fullPath))
            {
                encryptContent = File.ReadAllText(fullPath);
                return SymmetricKey.DecryptString(cipherKey, encryptContent);
            }
            else
            {
                throw new FileNotFoundException($"Cannot find file at '{fullPath}'");
            }
        }

        public static T ReadEnecryptFile<T>(string fullPath, string cipherKey) where T : class, new()
        {
            string decryptcontetn = ReadEnecryptFile(fullPath, cipherKey, out string encryptContent);
            return JsonConvert.DeserializeObject<T>(decryptcontetn);
        }
    }
}
