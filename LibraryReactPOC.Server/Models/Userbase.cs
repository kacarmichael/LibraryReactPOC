//Likely to be replaced once we introduce a dbcontext

namespace LibraryReactPOC.Server.Models
{
    public static class Userbase
    {

        private static List<User> _users = new List<User> {
            new User(firstname: "Test", lastname: "User", email: "test@user.com")
        };

        public static User GetUser(int id)
        {
            return _users.FindAll(x => x.Id == id).First();
        }

        public static List<User> GetUsers()
        {
            return _users;
        }

        public static void AddUser(User user)
        {
            _users.Add(user);
        }

        public static void RemoveUser(int id)
        {
            _users.Remove(GetUser(id));
        }
    }
}
