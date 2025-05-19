namespace MotoFacil.Domain.Entities
{
    public class Moto
    {
        public int Id { get; private set; } 

        public string Modelo { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
        public string Chassi { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

       

        
        public Moto() { }

        
        public Moto(string modelo, string placa, string chassi, string status, int userId)
        {
            Modelo = modelo;
            Placa = placa;
            Chassi = chassi;
            Status = status;
            
        }
    }
}
