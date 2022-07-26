namespace CrudCarsTokens.Entities
{
    public class Carro
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Versao { get; private set; }
        public string ImagemUrl { get; private set; }

        public Carro() { }

        public Carro(int id, string nome, string versao, string imagemUrl)
        {
            Id = id;
            Nome = nome;
            Versao = versao;
            ImagemUrl = imagemUrl;
        }

        public Carro(string nome, string versao, string imagemUrl)
        {
            Nome = nome;
            Versao = versao;
            ImagemUrl = imagemUrl;
        }
    }
}
