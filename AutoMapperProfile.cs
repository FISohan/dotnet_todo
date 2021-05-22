using AutoMapper;
using dotnet_todo.Dtos;
using dotnet_todo.Model;
namespace dotnet_todo
{
    public class AutoMapperProfile : Profile
    {   
        public AutoMapperProfile()
        {
            CreateMap<AddTodoDto,Todo>();
        }
    }
}