using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using TodoList.App.ViewModels;

namespace TodoList.App.Views;

public partial class AddItemView : UserControl
{
    public AddItemView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void DescriptionTextBox_OnKeyUp(object? sender, KeyEventArgs e)
    {
        if (DataContext is not null)
        {
            var viewModel = (AddItemViewModel)DataContext;
            viewModel.DescriptionInput();
        }
    }
}
