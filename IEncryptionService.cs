using System.Security.Cryptography;
using System.Text;

namespace EncryptionHandler;
    public interface IEncryptionService 
    {
        string EncryptString (string value);
        string DecryptString (string value);
    }