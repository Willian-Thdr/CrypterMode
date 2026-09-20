class Decrypt
{
    static string Connect(string cipherText, string secret)
    {
        byte[] data = Convert.FromBase64String(cipherText);

        int minimumSize = 16 + 12 + 16;

        if (data.Length < minimumSize)
            throw new CryptographicException("Invalid data.");

            byte[] salt = new byte[16];
            Buffer.BlockCopy(data, 0, salt, 0, 16);

            byte[] nonce = new byte[12];
            Buffer.BlockCopy(
                data,
                16,
                nonce,
                0,
                12
            );

            byte[] tag = new byte[16];
            Buffer.BlockCopy(
                data,
                16 + 12,
                tag,
                0,
                16
            );

            int cipherTextLenght = data.Length - 16 - 12 - 16;

            byte[] ciphertext = new byte[cipherTextLenght];

            Buffer.BlockCopy(
                data,
                16 + 12 + 16,
                ciphertext,
                0,
                cipherTextLenght
            );

            byte[] key = DeriveKey(secret, salt);
            byte[] text = new byte[ciphertext.Length];

            try {
                using (AesGcm aes = new AesGcm(key, 16)){
                    aes.Decrypt(
                        nonce,
                        ciphertext,
                        tag,
                        text
                    );
                }
            } catch (CryptographicException) {
                throw new CryptographicException("It's not possible dencrypt this file.\n" + "The key will be incorrect or corrupted.");
            }

            string textDecrypt = Encoding.UTF8.GetString(text);
            return textDecrypt;
    }

    public static byte[] DeriveKey(string secret, byte[] salt){
        using (Rfc2898DeriveBytes kdf = new Rfc2898DeriveBytes
        (
            secret,
            salt,
            600_000,
            HashAlgorithmName.SHA256
        )) {
            return kdf.GetBytes(32);
        }
    }
}
