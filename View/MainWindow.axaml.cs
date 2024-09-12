using Avalonia.Controls;
using XML_Cleaner.ViewModel;

namespace XML_Cleaner;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainWindowViewModel();
    }

    public async void AddElements_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DialogWindow _dialogWindow = new();
        await _dialogWindow.ShowDialog(this);
    }

    public void RemoveElements_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int index = ExtraNodes.SelectedIndex;

        if (index > -1) ExtraNodes.Items.RemoveAt(index);
    }
}