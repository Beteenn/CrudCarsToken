using CrudCarsTokens.Entities;

namespace CrudCarsTokens.Cryptography
{
    public class TokenService : ITokenService
    {
        private readonly ICryptography _cripto;

        public TokenService(ICryptography cripto)
        {
            _cripto = cripto;
        }

        public string GerarTokenLeitura()
        {
            var tipoToken = TipoTokenEnum.Leitura;
            var dataExpiracao = DateTime.Now.AddMinutes(15);

            string textoToken = $"{tipoToken};{dataExpiracao}";

            var token = _cripto.Encrypt(textoToken);
            return token;
        }

        public string GerarTokenEscrita()
        {
            var tipoToken = TipoTokenEnum.Escrita;
            var dataExpiracao = DateTime.Now.AddSeconds(5);

            string textoToken = $"{tipoToken};{dataExpiracao}";

            var token = _cripto.Encrypt(textoToken);
            return token;
        }

        public bool ValidarTokenEscrita(string token)
        {
            var dados = _cripto.Decrypt(token);

            var tipoToken = dados.Split(";")[0];
            var dataExpiracao = dados.Split(";")[1];

            if (DateTime.Now > Convert.ToDateTime(dataExpiracao)) return false;

            if (!Enum.TryParse(tipoToken, out TipoTokenEnum resultado) ||
                resultado != TipoTokenEnum.Escrita)
                return false;

            return true;
        }

        public bool ValidarTokenLeitura(string token)
        {
            var dados = _cripto.Decrypt(token);

            var tipoToken = dados.Split(";")[0];
            var dataExpiracao = dados.Split(";")[1];

            if (DateTime.Now > Convert.ToDateTime(dataExpiracao)) return false;

            if (!Enum.TryParse(tipoToken, out TipoTokenEnum resultado) ||
                resultado != TipoTokenEnum.Leitura)
                return false;

            return true;
        }
    }
}
