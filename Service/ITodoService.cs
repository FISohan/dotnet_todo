using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_todo.Dtos;
using dotnet_todo.Model;

namespace dotnet_todo.Service
{
    public interface ITodoService
    {
        Task<ServiceResponse<List<Todo>>> GetAllTodo();
        Task<ServiceResponse<Todo>> GetTodoById(int id);
        Task<ServiceResponse<List<Todo>>> AddTodo(AddTodoDto newTodo);
        Task<ServiceResponse<List<Todo>>> DeleteTodo(int id);
        Task<ServiceResponse<List<Todo>>> UpdateTodo(Todo newTodo);
    }
}