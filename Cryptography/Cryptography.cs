using System.Security.Cryptography;
using System.Text;

namespace CrudCarsTokens.Cryptography
{
    public class Cryptography : ICryptography
    {
        private readonly string _publickey = "SegredoS";
        private readonly string _secretkey = "AindaMai";

        public Cryptography() { }

        public string Encrypt(string textToEncrypt)
        {
            try
            {
                string ToReturn = "";

                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(_publickey);

                byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(_secretkey);

                MemoryStream ms;
                CryptoStream cs;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                using (var des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public string Decrypt(string textToDecrypt)
        {
            try
            {
                string ToReturn = "";

                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(_publickey);

                byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(_secretkey);


                MemoryStream ms;
                CryptoStream cs;
                byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
                using (var des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }
    }
}
