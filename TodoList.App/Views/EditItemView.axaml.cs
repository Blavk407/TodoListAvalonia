using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TodoList.App.Views;

public partial class EditItemView : UserControl
{
    public EditItemView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}