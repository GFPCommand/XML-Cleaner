using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.XPath;

namespace XML_Cleaner;

public partial class MainWindow : Window
{
    public ObservableCollection<Element> Element { get; }

    public MainWindow()
    {
        InitializeComponent();

        var people = new List<Element> 
            {
                new ("1", "2", "3"),
                new ("4", "5", "6"),
                new ("7", "8", "9")
            };
            Element = new ObservableCollection<Element>(people);
    }

    private void SaveButton_onClick(object sender, RoutedEventArgs e) {
        
    }

    private void SaveAsButton_onClick(object sender, RoutedEventArgs e) {

    }
}