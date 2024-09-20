using PruebaCRUD.Data;
using PruebaCRUD.Interfaces;
using PruebaCRUD.Models;

namespace PruebaCRUD.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) { 
            this._context = context;
        }

        public bool CreateUser(User user)
        {
            _context.Users.Add(user);
            return Save();

        }

        public bool DeleteUser(User user)
        {
            _context.Users.Remove(user);
            return Save();
        }

        public User? GetUser(int Id)
        {
            return _context.Users.Where( it => it.Id == Id ).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(x => x.Id).ToList();
        }

        public bool UpdateUser(User user)
        {
            _context.Users.Update(user);
            return Save();
        }

        public bool UserExists(string dni)
        {
            return _context.Users.Where(u => u.Dni.Trim() == dni.Trim()).Any();
        }

        public bool UserExistsById(int id)
        {
            return _context.Users.Where(u => u.Id == id).Any();
        }

        private bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
