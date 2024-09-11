using Avalonia.Controls;
using XML_Cleaner.ViewModel;

namespace XML_Cleaner;

public partial class MainWindow : Window
{
    private DialogWindow _dialogWindow;

    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainWindowViewModel();

        _dialogWindow = new();
    }

    protected override void OnClosing(WindowClosingEventArgs e)
    {
        _dialogWindow.Close();
        base.OnClosing(e);
    }

    public void AddElements_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        // use ShowDialog instead?
        _dialogWindow.ShowDialog(this);
    }

    public void RemoveElements_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int index = ExtraNodes.SelectedIndex;

        if (index != -1) ExtraNodes.Items.RemoveAt(index);
    }
}