namespace MotoFacil.Domain.Entities
{
    public class User
    {
       
        public int Id { get; private set; }

        public string Username { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        
        private User() { }

        
        public User(string username, string senha)
        {
            Username = username;
            Senha = senha;
        }
    }
}
