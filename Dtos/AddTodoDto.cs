namespace dotnet_todo.Dtos
{
    public class AddTodoDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}