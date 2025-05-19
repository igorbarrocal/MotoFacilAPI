namespace MotoFacil.DTOs
{
    public class UserCreateDto
    {
        public string Username { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public int Id { get; internal set; }
    }
}
