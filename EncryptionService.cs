using System.Security.Cryptography;
using System.Text;

namespace EncryptionHandler;
public class EncryptionService : IEncryptionService
{
    private readonly string _key;
    public EncryptionService (string? encryptionKey)
    {
        _key = encryptionKey ?? throw new Exception("Please provide an encryption key to be used.");
    }

    public string DecryptString(string value)
    {  
        byte[] buffer = Convert.FromBase64String(value);  

        using (Aes aes = Aes.Create())  
        {  
            aes.Key = Encoding.UTF8.GetBytes(_key);  
            aes.IV = new byte[16];  
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);  

            using (MemoryStream memoryStream = new MemoryStream(buffer))   
            using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))   
            using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))   
                return streamReader.ReadToEnd();   
        }  
    }

    public string EncryptString(string value)
    {
        byte[] array;  

        using (Aes aes = Aes.Create())  
        {  
            aes.Key = Encoding.UTF8.GetBytes(_key);  
            aes.IV = new byte[16];  

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);  

            using (MemoryStream memoryStream = new MemoryStream())  
            {  
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))  
                {  
                    using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))  
                    {  
                        streamWriter.Write(value);  
                    }   
                    array = memoryStream.ToArray();  
                }  
            }  
        }    
        return Convert.ToBase64String(array); 
    }
}