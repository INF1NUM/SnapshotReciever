using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class CryptoString
{
    private readonly ICryptoTransform encryptor;
    private readonly ICryptoTransform decryptor;
    public CryptoString(string password)
    {
        int _iterations = 2;
        int _keySize = 256;

        string _hash = "SHA1";
        //string _salt = "aselrias38490a32"; // Random
        //string _vector = "8947az34awl34kjq"; // Random

        //byte[] vectorBytes = Encoding.UTF8.GetBytes(_vector);
        //byte[] saltBytes = Encoding.UTF8.GetBytes(_salt);
        byte[] vectorBytes, saltBytes;

        using (MD5 hash = MD5.Create())
            saltBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            
        using (MD5 hash = MD5.Create())
            vectorBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password));

        RijndaelManaged rijAlg = new RijndaelManaged();
        rijAlg.Mode = CipherMode.CBC;

        PasswordDeriveBytes _passwordBytes = new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
        byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

        encryptor = rijAlg.CreateEncryptor(keyBytes, vectorBytes);
        decryptor = rijAlg.CreateDecryptor(keyBytes, vectorBytes);
    }

    public string Encrypt(string value)
    {
        byte[] valueBytes = Encoding.UTF8.GetBytes(value);
        byte[] encrypted;

        using (MemoryStream to = new MemoryStream())
        {
            using (CryptoStream writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write))
            {
                writer.Write(valueBytes, 0, valueBytes.Length);
                writer.FlushFinalBlock();
                encrypted = to.ToArray();
            }
        }
        return Convert.ToBase64String(encrypted);
    }
    public byte[] EncryptToByte(string value)
    {
        byte[] valueBytes = Encoding.UTF8.GetBytes(value);
        byte[] encrypted;

        using (MemoryStream to = new MemoryStream())
        {
            using (CryptoStream writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write))
            {
                writer.Write(valueBytes, 0, valueBytes.Length);
                writer.FlushFinalBlock();
                encrypted = to.ToArray();
            }
        }
        return encrypted;
    }

    public string Decrypt(string value)
    {
        byte[] valueBytes = Convert.FromBase64String(value);
        byte[] decrypted;
        int decryptedByteCount = 0;

        using (MemoryStream from = new MemoryStream(valueBytes))
        {
            using (CryptoStream reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read))
            {
                decrypted = new byte[valueBytes.Length];
                decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
            }
        }
        return Encoding.UTF8.GetString(decrypted, 0, decryptedByteCount);
    }
    public string DecryptFromByte(byte[] valueBytes)
    {
        byte[] decrypted;
        int decryptedByteCount = 0;

        using (MemoryStream from = new MemoryStream(valueBytes))
        {
            using (CryptoStream reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read))
            {
                decrypted = new byte[valueBytes.Length];
                decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
            }
        }
        return Encoding.UTF8.GetString(decrypted, 0, decryptedByteCount);
    }
}



