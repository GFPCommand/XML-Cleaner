using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;
using XML_Cleaner.ViewModel;

namespace XML_Cleaner;

public partial class DialogWindow : Window
{
    private DialogWindowViewModel _viewModel;

    public DialogWindow()
    {
        InitializeComponent();

        _viewModel = new();

        DataContext = _viewModel;
    }

    private void LoadElementsList_Click(object sender, RoutedEventArgs e)
    {
        //parse input field

        string? value = InputField.Text;

        Debug.WriteLine(value);

        ClearInputFields();
    }

	private void HideDialogWindow_Click(object sender, RoutedEventArgs e)
	{
        ClearInputFields();
	}

    private void ModesList_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (ModesList is null) return;

		switch (ModesList.SelectedIndex)
		{
			case 0:
				break;
			case 1:
				_viewModel.IsFileLoadable = true;
				break;
			case 2:
				_viewModel.IsFileLoadable = false;
				break;
			default:
				break;
		}
	}

    private void ClearInputFields()
    {
        InputField.Clear();
        RootNode.Clear();

        Hide();
    }
}