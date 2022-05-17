using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using ReactiveUI;
using TodoList.App.Models;

namespace TodoList.App.ViewModels;

public class DeleteItemViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainWindow;
    private readonly Database _database;

    private ObservableCollection<Todo> _todos = new();

    public DeleteItemViewModel(Database db, MainWindowViewModel mainWindow)
    {
        _mainWindow = mainWindow;
        _database = db;
        var observable = db.GetItems().ToObservable().ObserveOn(RxApp.MainThreadScheduler);
        observable.Subscribe(x => Items = new(x));
    }

    private ObservableCollection<Todo> Items
    {
        get => _todos;
        set => this.RaiseAndSetIfChanged(ref _todos, value);
    }

    private List<Todo> _selectedItems = new List<Todo>();

    private void AddToSelectedItems(Todo sender)
    {
        _selectedItems.Add(sender);
    }

    private async void DeleteItems()
    {
        for (int i = 0; i < _selectedItems.Count; i++)
            await _database.DeleteTodo(_selectedItems[i]);
        _mainWindow.Content = new TodoListViewModel(_database, _mainWindow);
    }
}