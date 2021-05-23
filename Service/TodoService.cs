using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_todo.Data;
using dotnet_todo.Dtos;
using dotnet_todo.Model;
using Microsoft.EntityFrameworkCore;

namespace dotnet_todo.Service
{
    public class TodoService : ITodoService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public TodoService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<ServiceResponse<List<Todo>>> AddTodo(AddTodoDto newTodo)
        {
            ServiceResponse<List<Todo>> respone = new ServiceResponse<List<Todo>>();
            Todo todo = _mapper.Map<Todo>(newTodo);
            if (todo == null)
            {
                respone.Success = false;
                respone.Message = "Add todo";
            }
            else
            {
                _context.Todos.Add(todo);
                await _context.SaveChangesAsync();
                respone.Message = "Add todo successfully";
            }
            return respone;
        }

        public async Task<ServiceResponse<List<Todo>>> DeleteTodo(int id)
        {
            ServiceResponse<List<Todo>> respone = new ServiceResponse<List<Todo>>();
            try
            {
                Todo todo = _context.Todos.First(c => c.Id == id);

                if (todo == null)
                {
                    respone.Success = false;
                    respone.Message = "Id not found";
                }
                else
                {
                    _context.Todos.Remove(todo);
                    await _context.SaveChangesAsync();
                    respone.Message = "Delete successfully";
                }
            }
            catch (System.Exception ex)
            {

                respone.Message = ex.Message.ToString();
                respone.Success = false;
            }

            return respone;
        }

        public async Task<ServiceResponse<List<Todo>>> GetAllTodo()
        {
            ServiceResponse<List<Todo>> respone = new ServiceResponse<List<Todo>>();
            respone.Data = await _context.Todos.ToListAsync();
            if (respone.Data == null)
            {
                respone.Success = false;
                respone.Message = "No todo";
            }
            return respone;
        }

        public async Task<ServiceResponse<Todo>> GetTodoById(int id)
        {
            ServiceResponse<Todo> respone = new ServiceResponse<Todo>();
            Todo todo = await _context.Todos.FirstOrDefaultAsync(c => c.Id == id);
            if (todo == null)
            {
                respone.Success = false;
                respone.Message = "Id not found";
            }
            else
            {
                respone.Data = todo;

            }
            return respone;
        }

        public async Task<ServiceResponse<List<Todo>>> UpdateTodo(Todo newTodo)
        {
            ServiceResponse<List<Todo>> respone = new ServiceResponse<List<Todo>>();
            Todo todo = await _context.Todos.FirstOrDefaultAsync(c => c.Id == newTodo.Id);
            if (todo == null)
            {
                respone.Message = "Enter valid id";
                respone.Success = false;
            }
            else
            {
                todo.Description = newTodo.Description;
                todo.IsCompleted = newTodo.IsCompleted;
                todo.Title = newTodo.Title;
                _context.Todos.Update(todo);
                await _context.SaveChangesAsync();
                respone.Message = "Updated successfully";
            }

            return respone;
        }
    }

}