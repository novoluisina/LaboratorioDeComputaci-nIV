using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using todo_item.Entities;
using todo_item.Models;
using todo_item.Services.Interfaces;

namespace todo_item.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Todo_itemController : ControllerBase
    {
        private readonly ITodo_itemService _itemService;

        public Todo_itemController(ITodo_itemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("GetAllTodo_items")]
        public IActionResult GetAllTodo_item()
        {
            
                var items = _itemService.GetAllTodo_item();
                try
                {
                    return Ok(items);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
           
        }

        [HttpGet("GetAllByUser{userId}")]
        public IActionResult GetAllItemsByUser([FromRoute] int userId)
        {
          
                try
                {
                    var todo_items = _itemService.GetAllItemsByUser(userId);
                    if (todo_items.Count == 0)
                    {
                        return NotFound("Tareas no encontradas");
                    }
                    return Ok(todo_items);

                }
                catch (Exception ex)
                {
                    return BadRequest($"Error: {ex.Message}");
                }
            
        }

       
        [HttpGet("GetItemById/{orderId}")]
        public IActionResult GetTodo_itemById([FromRoute] int itemId)
        {
           
                try
                {
                    var item = _itemService.GetTodo_itemById(itemId);

                    if (item == null)
                    {
                        return NotFound($"Tarea no encontrada");
                    }

                    return Ok(item);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error: {ex.Message}");
                }
            
            
        }

        [HttpPost("CreateItem")]
        public IActionResult CreateTodo_item([FromBody] Itemdto dto)
        {
           
            
                if (dto.Title==null || dto.Description==null)
                {
                    return BadRequest("Por favor complete los campos");
                }
                try
                {
                    var newTodo_item = new Todo_item()
                    {
                        Title = dto.Title,
                        Description = dto.Description
                       
                    };
                    int id  = _itemService.CreateTodo_item(newTodo_item);
                    return Ok($"Tarea creada exitosamente con ID: {newTodo_item.Id_item}");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            
           
        }

        [HttpDelete("DeleteItem{id}")]
        public IActionResult DeleteSaleOrder([FromRoute] int id)
        {
            
                try
                {
                    var existingItem = _itemService.GetTodo_itemById(id);

                    if (existingItem == null)
                    {
                        return NotFound($"No se encontró tarea con el ID: {id}");
                    }

                    _itemService.DeleteTodo_item(id);
                    return Ok($"Tarea con ID: {id} eliminada");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            
            
        }


    }
}
