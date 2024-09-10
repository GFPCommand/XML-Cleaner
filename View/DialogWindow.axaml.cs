using Avalonia.Controls;
using System;
using XML_Cleaner.ViewModel;

namespace XML_Cleaner;

public partial class DialogWindow : Window
{
    public DialogWindow()
    {
        InitializeComponent();

        DataContext = new DialogWindowViewModel();
    }

	public void HideDialogWindow_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
        Hide();
	}
}