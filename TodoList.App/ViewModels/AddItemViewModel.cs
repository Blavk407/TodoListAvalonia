using System;
using ReactiveUI;
using TodoList.App.Models;

namespace TodoList.App.ViewModels;

public class AddItemViewModel : ViewModelBase
{

    public AddItemViewModel(MainWindowViewModel mainWindow, Database db)
    {
        _database = db;
        _mainWindow = mainWindow;
        Description = string.Empty;
    }

    private string Description { get; set; }

    private string Error
    {
        get => _error;
        set => this.RaiseAndSetIfChanged(ref _error, value);
    }

    private readonly Database _database;
    private readonly MainWindowViewModel _mainWindow;
    private string _error;

  
    private void NavigateToTodoList()
    {
        _mainWindow.Content = new TodoListViewModel(_database, _mainWindow);
    }

    public async void AddTodoInDatabase()
    {
        if (Description != string.Empty)
        {
            Error = string.Empty;
            var newTodo = new Todo();
            newTodo.Description = Description;
            await _database.CreateTodo(newTodo);
            NavigateToTodoList();
        }
        else
        {
            Error = "Вы не ввели задачу!";
        }
    }

    public void DescriptionInput()
    {
        Error = string.Empty;
    }
}