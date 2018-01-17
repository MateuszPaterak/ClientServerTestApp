namespace PluginInterface
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public User(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public User()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Email = string.Empty;
        }
    }
}