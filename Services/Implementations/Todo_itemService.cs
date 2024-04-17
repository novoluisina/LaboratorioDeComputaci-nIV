using Microsoft.EntityFrameworkCore;
using todo_item.DBContext;
using todo_item.Entities;
using todo_item.Services.Interfaces;

namespace todo_item.Services.Implementations
{
    public class Todo_itemService:ITodo_itemService
    {
        private readonly Context _context;

        public Todo_itemService(Context context)
        {
            _context = context;
        }

        public List<Todo_item> GetAllTodo_item()
        {
            return _context.Todo_items.ToList();
        }

        public Todo_item? GetTodo_itemById(int id)
        {
            return _context.Todo_items.FirstOrDefault(p => p.Id_item == id);
        }

        public Todo_item? GetItemByTitle(string title)
        {
            return _context.Todo_items.FirstOrDefault(p => p.Title == title);
        }

        public List<Todo_item> GetAllItemsByUser(int id_user) 
        {
            return _context.Todo_items
                .Include(so => so.User)
                .Where(r => r.UserId == id_user)
                .ToList();
        }

        public int CreateTodo_item(Todo_item todo_Item)
        {
            _context.Todo_items.Add(todo_Item);
            _context.SaveChanges();

            return (todo_Item.Id_item);
        }

        public void DeleteTodo_item(int id)
        {
            var itemToDelete = _context.Todo_items.SingleOrDefault(p => p.Id_item == id);

            if (itemToDelete != null)
            {
                _context.Todo_items.Remove(itemToDelete);
                _context.SaveChanges();
            }
        }

    }
}
