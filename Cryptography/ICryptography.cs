namespace CrudCarsTokens.Cryptography
{
    public interface ICryptography
    {
        string Encrypt(string textToEncrypt);
        string Decrypt(string textToDecrypt);
    }
}
