namespace CrudCarsTokens.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string HashSenha { get; private set; }

        public Usuario() { }

        public Usuario(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public Usuario(string nome, string email, string hashSenha)
        {
            Nome = nome;
            Email = email;
            HashSenha = hashSenha;
        }

        public void AdicionarHashSenha(string hash) => HashSenha = hash;
    }
}
