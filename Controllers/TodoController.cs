using System.Threading.Tasks;
using dotnet_todo.Service;
using Microsoft.AspNetCore.Mvc;
using dotnet_todo.Model;
using dotnet_todo.Dtos;
using System.Collections.Generic;

namespace dotnet_todo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            ServiceResponse<List<Todo>> response = await _todoService.GetAllTodo();
            if (!response.Success)
            {
                return Ok(response.Message);
            }
            return Ok(response.Data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            ServiceResponse<Todo> response = await _todoService.GetTodoById(id);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> AddTodoAsync(AddTodoDto newTodo)
        {
            ServiceResponse<List<Todo>> response = await _todoService.AddTodo(newTodo);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoAsync(int id)
        {
            ServiceResponse<List<Todo>> response = await _todoService.DeleteTodo(id);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }
        [HttpPut]
        public async Task<IActionResult> updateTodo(Todo updatedTodo)
        {
            ServiceResponse<List<Todo>> response = await _todoService.UpdateTodo(updatedTodo);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }
    }
}