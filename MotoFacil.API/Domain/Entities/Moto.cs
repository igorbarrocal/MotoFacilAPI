namespace MotoFacil.Domain.Entities
{
    public class Moto
    {
        public int Id;


        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Chassi { get; set; }
        public string Status { get; set; }

        public int GetId() => Id;
    }
}
