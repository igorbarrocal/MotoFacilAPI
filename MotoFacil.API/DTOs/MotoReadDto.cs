namespace MotoFacil.DTOs
{
    public class MotoReadDto
    {
        public int Id { get; set; }            // Deve ser público
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Chassi { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }        // Também deve ser público
    }
}
