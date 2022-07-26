namespace CrudCarsTokens.Entities
{
    public class Carro
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Versao { get; private set; }
        public string ImagemUrl { get; private set; }

        public Carro() { }
    }
}
