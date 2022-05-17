using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TodoList.App.Views;

public partial class DeleteItemView : UserControl
{
    public DeleteItemView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}