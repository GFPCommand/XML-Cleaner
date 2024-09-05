using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using XML_Cleaner.ViewModel;

namespace XML_Cleaner;

public partial class DialogWindow : Window
{
    public DialogWindow()
    {
        InitializeComponent();

        DataContext = new DialogWindowViewModel();
    }
}