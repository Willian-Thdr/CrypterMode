using System.Security.Cryptography;
using System.Text;

namespace CrypterMode.Source;

class Encrypt
{
    public static string Connect(string txtSimple, string[] txtArray, string secret)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        byte[] key = Decrypt.DeriveKey(secret, salt);
        byte[] nonce = RandomNumberGenerator.GetBytes(12);
        string txt = null;

        if (txtArray == null)
        {
            txt = txtSimple;
        } 
        else if (txtSimple == null)
        {
            txt = string.Join(Environment.NewLine, txtArray);
        } 
        else if (txt == null)
        {
            throw new Exception("Erro");
        }

        byte[] plainTextBytes = Encoding.UTF8.GetBytes(txt);
        byte[] cipherText = new byte[plainTextBytes.Length];
        byte[] tag = new byte[16];

        using (AesGcm aes = new AesGcm(key, 16))
        {
            aes.Encrypt(
                nonce,
                plainTextBytes,
                cipherText,
                tag
            );
        }

        byte[] result = new byte[16 + 12 + 16 + cipherText.Length];

        Buffer.BlockCopy(salt, 0, result, 0, 16);
        Buffer.BlockCopy(nonce, 0, result, 16, 12);
        Buffer.BlockCopy(tag, 0, result, 16 + 12, 16);
        Buffer.BlockCopy(cipherText, 0, result, 16 + 12 + 16, cipherText.Length);

        return Convert.ToBase64String(result);
    }
}