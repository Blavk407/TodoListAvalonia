using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using ReactiveUI;
using TodoList.App.Models;

namespace TodoList.App.ViewModels;

public class TodoListViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainWindow;
    private readonly Database _database;

    private ObservableCollection<Todo> _todos = new();

    public TodoListViewModel(Database db, MainWindowViewModel mainWindow)
    {
        _mainWindow = mainWindow;
        _database = db;
        var observable = db.GetItems().ToObservable().ObserveOn(RxApp.MainThreadScheduler);
        observable.Subscribe(x => Items = new(x));
    }

    public TodoListViewModel()
    {
        _mainWindow = null!;
        _database = null!;
    }

    public ObservableCollection<Todo> Items
    {
        get => _todos;
        set => this.RaiseAndSetIfChanged(ref _todos, value);
    }

    public void NavigateToAddItem()
    {
        _mainWindow.Content = new AddItemViewModel(_mainWindow, _database);
    }

    public void TodoCompleted(Todo sender)
    {
        _ = _database.EditTodo(sender);
    }

    public void NavigateToChangeItems()
    {
        _mainWindow.Content = new ChangeItemsViewModel(_database, _mainWindow);
    }

    public void NavigateToDeleteItem()
    {
        _mainWindow.Content = new DeleteItemViewModel(_database, _mainWindow);
    }
}