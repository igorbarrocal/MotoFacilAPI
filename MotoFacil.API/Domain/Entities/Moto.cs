namespace MotoFacil.Domain.Entities
{
    public class Moto
    {
        public int Id { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Cor { get; set; } = string.Empty;       // Ex: Verde, Azul, Vermelho
        public string Categoria { get; set; } = string.Empty; // Ex: Aquisição ou Aluguel
    }
}
