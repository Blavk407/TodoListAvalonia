namespace TodoList.Shared;

public class TodoUpdateForm
{
    public string Description { get; set; } = string.Empty;

    public bool Completed { get; set; }
}