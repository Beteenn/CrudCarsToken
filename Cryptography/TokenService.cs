using CrudCarsTokens.Entities;

namespace CrudCarsTokens.Cryptography
{
    public class TokenService : ITokenService
    {
        private readonly ICryptography _cripto;
        private readonly string _chave = "ChaveSecreta";

        public TokenService(ICryptography cripto)
        {
            _cripto = cripto;
        }

        public string GerarTokenLeitura()
        {
            var tipoToken = TipoTokenEnum.Leitura;
            var dataExpiracao = DateTime.Now.AddMinutes(15);

            string textoToken = $"{tipoToken};{dataExpiracao};{_chave}";

            var token = _cripto.Encrypt(textoToken);
            return token;
        }

        public string GerarTokenEscrita()
        {
            var tipoToken = TipoTokenEnum.Escrita;
            var dataExpiracao = DateTime.Now.AddSeconds(5);

            string textoToken = $"{tipoToken};{dataExpiracao};{_chave}";

            var token = _cripto.Encrypt(textoToken);
            return token;
        }

        public bool ValidarTokenEscrita(string token)
        {
            var dados = _cripto.Decrypt(token);

            var valido = ValidarAutenticidadeToken(dados);

            if (!valido) return false;

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

            var valido = ValidarAutenticidadeToken(dados);

            if (!valido) return false;

            var tipoToken = dados.Split(";")[0];
            var dataExpiracao = dados.Split(";")[1];

            if (DateTime.Now > Convert.ToDateTime(dataExpiracao)) return false;

            if (!Enum.TryParse(tipoToken, out TipoTokenEnum resultado) ||
                resultado != TipoTokenEnum.Leitura)
                return false;

            return true;
        }

        public bool ValidarAutenticidadeToken(string dados)
        {
            var tipoToken = dados.Split(";")[0];
            var chave = dados.Split(";")[2];

            if (chave != _chave) return false;

            if (!Enum.TryParse(tipoToken, out TipoTokenEnum resultado) ||
                resultado != TipoTokenEnum.Leitura &&
                resultado != TipoTokenEnum.Escrita)
                return false;

            return true;
        }

        public string GerarHashSenha(string senha)
        {
            return _cripto.Encrypt(senha);
        }

        public string DecriptarHashSenha(string hash)
        {
            return _cripto.Decrypt(hash);
        }
    }
}
