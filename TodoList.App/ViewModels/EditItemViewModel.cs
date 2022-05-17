using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using ReactiveUI;
using TodoList.App.Models;

namespace TodoList.App.ViewModels;

public class EditItemViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainWindow;
    private readonly Database _database;
    private List<Todo> _selectedItems;
    private string _description;
    private bool _completed;
    

    public EditItemViewModel(MainWindowViewModel mainWindow, List<Todo> todos, Database db)
    {
        _mainWindow = mainWindow;
        _selectedItems = todos;
        _description = todos[0].Description;
        _completed = todos[0].Completed;
        _database = db;
    }

    public string Description 
    { 
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value); 
    }
    
    public bool Completed 
    { 
        get => _completed;
        set => this.RaiseAndSetIfChanged(ref _completed, value); 
    }

    public async void NavigateToNewEditItemOrTodoList()
    {
        _selectedItems[0].Description = Description;
        _selectedItems[0].Completed = Completed;
        await _database.EditTodo(_selectedItems[0]);
        _selectedItems.Remove(_selectedItems[0]);
        if (_selectedItems.Count != 0)
            _mainWindow.Content = new EditItemViewModel(_mainWindow, _selectedItems, _database);
        else
            _mainWindow.Content = new TodoListViewModel(_database, _mainWindow);
    }
}