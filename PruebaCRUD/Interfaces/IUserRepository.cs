using PruebaCRUD.Models;

namespace PruebaCRUD.Interfaces
{
    public interface IUserRepository
    {
        public User? GetUser(int Id);
        public ICollection<User> GetUsers();

        public bool CreateUser(User user);

        public bool UpdateUser(User user);

        public bool DeleteUser(User user);

        public bool UserExists(string dni);

        public bool UserExistsById(int id);

    }
}
