using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TodoList.App.Views;

public partial class ChangeItemsView : UserControl
{
    public ChangeItemsView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}