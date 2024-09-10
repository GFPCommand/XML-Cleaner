using Avalonia.Controls;
using System;
using System.Diagnostics;
using XML_Cleaner.ViewModel;

namespace XML_Cleaner;

public partial class DialogWindow : Window
{
    public DialogWindow()
    {
        InitializeComponent();

        DataContext = new DialogWindowViewModel();
    }

    public void LoadElementsList_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //parse input field

        string? value = InputField.Text;

        Debug.WriteLine(value);

        ClearInputFields();

        Hide();
    }

	public void HideDialogWindow_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
        ClearInputFields();
        Hide();
	}

    private void ClearInputFields()
    {
        InputField.Clear();
        RootNode.Clear();
    }
}