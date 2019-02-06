using SageAufbaukursCSharp.ServiceImplementations;
using SageAufbaukursCSharp.ViewModels;
using System.Windows;


namespace SageAufbaukursCSharp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }
    }
}
