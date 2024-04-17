using todo_item.Entities;

namespace todo_item.Services.Interfaces
{
    public interface IUserService
    {
        public User? GetUserById(int id);
        void DeleteUser(int userId);
        int CreateUser(User user);
    }
}
