namespace CrudCarsTokens.Cryptography
{
    public interface ITokenService
    {
        string GerarTokenLeitura();
        string GerarTokenEscrita();
        bool ValidarTokenLeitura(string token);
        bool ValidarTokenEscrita(string token);
        bool ValidarAutenticidadeToken(string dados);
        string GerarHashSenha(string senha);
        string DecriptarHashSenha(string hash);
    }
}
