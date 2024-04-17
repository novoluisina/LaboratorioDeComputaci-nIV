using todo_item.DBContext;
using todo_item.Entities;
using todo_item.Services.Interfaces;

namespace todo_item.Services.Implementations
{
    public class UserService: IUserService
    {
        private readonly Context _context;

        public UserService(Context context)
        {
            _context = context;
        }

        public User? GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id_user == id);
        }

        public void DeleteUser(int Id)
        {
            User? userToDelete = _context.Users.FirstOrDefault(u => u.Id_user == Id);
            userToDelete.State = false;
            _context.Update(userToDelete);
            _context.SaveChanges();

        }

        public int CreateUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.Id_user;
        }
    }
}
