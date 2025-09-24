namespace SocialNetworkApp.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        public User(string name) 
        { 
            Name = name;
        }
    }
}
