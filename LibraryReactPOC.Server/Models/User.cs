namespace LibraryReactPOC.Server.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        private int _id;
        private string _password;
        private List<Library> _libraries;

        public User(string firstname, string lastname, string email, string password) 
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            CreatedAt = DateTime.Now;
            _id = 0;
            _password = password;
            _libraries = new List<Library>();
        }

        public int Id { get { return _id; } }

        public string Password { get { return _password; } } //Solely for initial testing

        public List<Library> Libraries { get { return _libraries; } }



    }
}
