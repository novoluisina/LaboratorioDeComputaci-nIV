using todo_item.Entities;

namespace todo_item.Services.Interfaces
{
    public interface ITodo_itemService
    {
        List<Todo_item> GetAllTodo_item();
        Todo_item? GetTodo_itemById(int id);
        Todo_item? GetItemByTitle(string title);
        List<Todo_item> GetAllItemsByUser(int id_user);
        int CreateTodo_item(Todo_item todo_Item);
        void DeleteTodo_item(int id);
    }
}
