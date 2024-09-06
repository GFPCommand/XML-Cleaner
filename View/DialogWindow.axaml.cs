using Avalonia.Controls;
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