using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using ReactiveUI;
using TodoList.App.Models;

namespace TodoList.App.ViewModels;

public class ChangeItemsViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainWindow;
    private readonly Database _database;

    private ObservableCollection<Todo> _todos = new();

    public ChangeItemsViewModel(Database db, MainWindowViewModel mainWindow)
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

    private void NavigateToEditItem()
    {
        _mainWindow.Content = new EditItemViewModel(_mainWindow, _selectedItems, _database);
    }
}