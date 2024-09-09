using Avalonia.Controls;
using XML_Cleaner.ViewModel;

namespace XML_Cleaner;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainWindowViewModel(this);
    }
}