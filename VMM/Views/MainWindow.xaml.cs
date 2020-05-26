using System.Windows;
using MahApps.Metro.Controls;
using VMM.Services;
using VMM.ViewModels;

namespace VMM.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ProtocolLoaderService protocolLoaderService = new ProtocolLoaderService();
            DataContext = new MainViewModel(protocolLoaderService);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ((MainViewModel) DataContext).FillDefaultValues();
        }
    }
}