using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using XML_Cleaner.CodeAnalyzer;
using XML_Cleaner.ViewModel;

namespace XML_Cleaner;

public partial class DialogWindow : Window
{
    private DialogWindowViewModel _viewModel;

    private LexerAnalyzer _analyzer;

    public DialogWindow()
    {
        InitializeComponent();

        _viewModel = new();

        DataContext = _viewModel;
    }

    private void LoadElementsList_Click(object sender, RoutedEventArgs e)
    {
        string? rootNodeName = RootNode.Text;
        string? value = InputField.Text;

        if (string.IsNullOrWhiteSpace(rootNodeName) || string.IsNullOrWhiteSpace(value)) 
        {
            ClearInputFields();

            Debug.WriteLine("Empty");

            return;
        }

        // get split strings from input
        foreach (var i in value.Split(';'))
        {
            _analyzer.AddLexemToList(i);
        }

        _analyzer.Analyzer();

        ClearInputFields();
    }

	private void HideDialogWindow_Click(object sender, RoutedEventArgs e)
	{
        ClearInputFields();
	}

    private void ModesList_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (ModesList is null) return;

        _viewModel.IsFileLoadable = ModesList.SelectedIndex == 1;
	}

    private void ClearInputFields()
    {
        InputField.Clear();
        RootNode.Clear();

        Close();
    }
}