using TodoList.App.Models;
using ReactiveUI;

namespace TodoList.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object _content;
        
        public MainWindowViewModel(Database db)
        {
            Content = new TodoListViewModel(db, this);
        }

        public object Content
        {
            get => _content; 
            set => this.RaiseAndSetIfChanged(ref _content, value); 
        }
    }
}
