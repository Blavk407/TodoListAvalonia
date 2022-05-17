using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TodoList.Shared;

namespace TodoList.App.Models;

public class Database
{
    private readonly HttpClient _client;

    public Database(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<Todo>> GetItems()
    {
        var response = await _client.GetAsync("http://localhost:5028/api/Todo");
        var items = await response.Content.ReadFromJsonAsync<List<Todo>>();
        return items!;
    }

    public async Task<Todo> CreateTodo(Todo todo)
    {
        var response = await _client.PostAsync("http://localhost:5028/api/Todo", JsonContent.Create(todo));
        var item = await response.Content.ReadFromJsonAsync<Todo>();
        return item!;
    }

    public async Task EditTodo(Todo todo)
    {
        var newTodoUpdateForm = new TodoUpdateForm
        {
            Description = todo.Description,
            Completed = todo.Completed
        };
        await _client.PutAsync($"http://localhost:5028/api/Todo/{todo.Id}", JsonContent.Create(newTodoUpdateForm));
        await _client.PutAsync($"http://localhost:5028/api/Todo/{todo.Id}", JsonContent.Create(todo));
    }

    public async Task DeleteTodo(Todo todo)
    {
        await _client.DeleteAsync($"http://localhost:5028/api/Todo/{todo.Id}");
    }
}