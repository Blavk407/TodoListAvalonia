namespace TodoList.Api.Models;

public class Todo
{
	public long Id { get; set; }

	public string Description { get; set; } = string.Empty;

	public bool Completed { get; set; }
}