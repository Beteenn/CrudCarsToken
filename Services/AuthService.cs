using CrudCarsTokens.Dtos;
using CrudCarsTokens.Entities;
using CrudCarsTokens.Services.Interfaces;
using CrudCarsTokens.ViewModels;
using System.Security.Cryptography;
using System.Text;

namespace CrudCarsTokens.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _publickey = "SegredoS";
        private readonly string _secretkey = "AindaMai";

        public AuthService() { }

        public TokenViewModel CriarTokenEscrita()
        {
            string token = GerarTokenEscrita();

            return new TokenViewModel { Token = token };
        }

        public TokenValidoViewModel ValidarTokenEscrita(string token)
        {
            var dados = Decrypt(token);

            var tipoToken = dados.Split(";")[0];
            var dataExpiracao = dados.Split(";")[1];

            if (DateTime.Now > Convert.ToDateTime(dataExpiracao)) return new TokenValidoViewModel { Valido = false };

            if (!Enum.TryParse(tipoToken, out TipoTokenEnum resultado) ||
                resultado != TipoTokenEnum.Escrita)
                return new TokenValidoViewModel { Valido = false };

            return new TokenValidoViewModel { Valido = true };
        }

        public TokenViewModel CriarTokenLeitura()
        {
            string token = GerarTokenLeitura();

            return new TokenViewModel { Token = token };
        }

        public TokenValidoViewModel ValidarTokenLeitura(string token)
        {
            var dados = Decrypt(token);

            var tipoToken = dados.Split(";")[0];
            var dataExpiracao = dados.Split(";")[1];

            if (DateTime.Now > Convert.ToDateTime(dataExpiracao)) return new TokenValidoViewModel { Valido = false };

            if (!Enum.TryParse(tipoToken, out TipoTokenEnum resultado) ||
                resultado != TipoTokenEnum.Leitura)
                return new TokenValidoViewModel { Valido = false };

            return new TokenValidoViewModel { Valido = true };
        }

        public LoginViewModel Login(LoginDto loginDto)
        {
            var tokenLeitura = GerarTokenLeitura();

            var tokenEscrita = GerarTokenEscrita();

            return new LoginViewModel { TokenEscrita = tokenEscrita, TokenLeitura = tokenLeitura };
        }

        private string GerarTokenLeitura()
        {
            var tipoToken = TipoTokenEnum.Leitura;
            var dataExpiracao = DateTime.Now.AddMinutes(15);

            string textoToken = $"{tipoToken};{dataExpiracao}";

            var token = Encrypt(textoToken);
            return token;
        }

        private string GerarTokenEscrita()
        {
            var tipoToken = TipoTokenEnum.Escrita;
            var dataExpiracao = DateTime.Now.AddSeconds(5);

            string textoToken = $"{tipoToken};{dataExpiracao}";

            var token = Encrypt(textoToken);
            return token;
        }

        private string Encrypt(string textToEncrypt)
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

        private string Decrypt(string textToDecrypt)
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
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
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
